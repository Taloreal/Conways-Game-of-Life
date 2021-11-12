using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

using TALOREAL;

namespace GameOfLife {

    public class Universe {

        private int _Generation = 0;

        /// <summary>
        /// The current generation number.
        /// </summary>
        public int Generation { 
            get { return _Generation; } 
            set {
                _Generation = value;
                ForceRedraw?.Invoke(_Generation, null);
            } 
        }

        //the default size
        public const int DefaultWidth = 30;
        public const int DefaultHeight = 30;

        private bool[,] universe = new bool[DefaultWidth, DefaultHeight];

        /// <summary>
        /// The universe's current width.
        /// </summary>
        public int Width => universe.GetLength(0);

        /// <summary>
        /// The universe's current height.
        /// </summary>
        public int Height => universe.GetLength(1);

        public event EventHandler ForceRedraw;
        public event PropertyChanged SizeChanged;

        /// <summary>
        /// The size of the universe.
        /// </summary>
        public Size Size {
            get {
                bool widthed = Settings.GetValue("width", out int width);
                bool heighted = Settings.GetValue("height", out int height);
                if (widthed == false || heighted == false) {
                    width = Width; height = Height;
                }
                if (width != Width || height != Height) {
                    UpdateUniverseSize(new Size(width, height));
                }
                return new Size(Width, Height);
            }
            set {
                bool sameWidth = value.Width == Width;
                bool sameHeight = value.Height == Height;
                if (sameWidth && sameHeight) {
                    Settings.SetValue("width", value.Width);
                    Settings.SetValue("height", value.Height);
                    return;
                }
                UpdateUniverseSize(value);
                ForceRedraw?.Invoke(Size, null);
            }
        }

        /// <summary>
        /// Calculate the next generation of the universe when timer ticks.
        /// </summary>
        public void Timer_Tick(object sender, EventArgs e) {
            NextGeneration();
        }

        /// <summary>
        /// Gets the boundary type for the universe, either Toroidal (true) or Finite (false).
        /// </summary>
        /// <param name="menuState">Is the current menu set to toroidal?</param>
        /// <returns>The boundary type currently in use.</returns>
        public bool GetBoundaryType(bool menuState) {
            bool fetched = Settings.GetValue("toroidal", out bool toroidal);
            if (!fetched) {
                toroidal = menuState;
                Settings.SetValue("toroidal", menuState);
                ForceRedraw?.Invoke(null, null);
            }
            return toroidal;
        }

        /// <summary>
        /// Sets the current boundary type for the universe.
        /// </summary>
        /// <param name="changeTo">What to change it to?</param>
        public void SetBoundaryType(bool changeTo) {
            Settings.SetValue("toroidal", changeTo);
            ForceRedraw?.Invoke(null, null);
        }

        /// <summary>
        /// Calculate the next generation of cells.
        /// </summary>
        public void NextGeneration() {
            bool same = true;
            bool[,] next = new bool[Width, Height];
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    int actives = GetNeighborsActive(x, y);
                    next[x, y] = GetNextGenerationState(GetState(x, y), actives);
                    if (same && next[x, y] != universe[x, y]) {
                        same = false;
                    }
                }
            }
            universe = next;
            // Increment generation count
            Generation++;
            int end = Config.RunTo;
            if (same || Generation == end) {
                if (Generation == end) {
                    Config.RunTo = -1;
                }
                Config.Running = false; 
            }
        }

        /// <summary>
        /// Get the number of active neighbors.
        /// </summary>
        /// <param name="x">The x position of the cell.</param>
        /// <param name="y">The y position of the cell.</param>
        /// <returns>The number of neighbors active.</returns>
        private int GetNeighborsActive(int x, int y) {
            int actives = GetState(x - 1, y - 1) ? 1 : 0;
            actives += GetState(   x,     y - 1) ? 1 : 0;
            actives += GetState(   x + 1, y - 1) ? 1 : 0;
            actives += GetState(   x - 1, y    ) ? 1 : 0;
            actives += GetState(   x + 1, y    ) ? 1 : 0;
            actives += GetState(   x - 1, y + 1) ? 1 : 0;
            actives += GetState(   x,     y + 1) ? 1 : 0;
            actives += GetState(   x + 1, y + 1) ? 1 : 0;
            return actives;
        }

        /// <summary>
        /// Get the alive or dead state of a particular cell.
        /// </summary>
        /// <param name="x">The x position of the cell.</param>
        /// <param name="y">The y position of the cell.</param>
        /// <returns>The alive or dead state of the cell.</returns>
        public bool GetState(int x, int y) {
            bool toroidal = GetBoundaryType(false); //<- assume a finite universe if not set
            while (x < 0 && toroidal) { x += Width; }
            while (x >= Width && toroidal) { x -= Width; }
            while (y < 0 && toroidal) { y += Height; }
            while (y >= Height && toroidal) { y -= Height; }
            if (x < 0 || x >= Width) { return false; }
            if (y < 0 || y >= Height) { return false; }
            return universe[x, y];
        }

        /// <summary>
        /// Recreates the universe with a new size, preserves what data possible.
        /// </summary>
        /// <param name="size">The new size of the universe.</param>
        private void UpdateUniverseSize(Size size) {
            bool[,] sketch = new bool[size.Width, size.Height];
            for (int x = 0; x < size.Width && x < Width; x++) {
                for (int y = 0; y < size.Height && y < Height; y++) {
                    sketch[x, y] = universe[x, y];
                }
            }
            Settings.SetValue("width", size.Width);
            Settings.SetValue("height", size.Height);
            universe = sketch;
            SizeChanged?.Invoke(size);
        }

        /// <summary>
        /// Gets the cell's next state.
        /// </summary>
        /// <param name="active">Is it currently on or off?</param>
        /// <param name="neighborsOn">How many neighbors are active right now?</param>
        /// <returns>The new state for the cell.</returns>
        public static bool GetNextGenerationState(bool active, int neighborsOn) {
            return Config.Rules.RollTheDice(active, neighborsOn);
        }

        /// <summary>
        /// Draws the number of active neighbors for the current cell.
        /// </summary>
        /// <param name="gx">The graphics object to draw on.</param>
        /// <param name="drawFont">The font to draw in.</param>
        /// <param name="gridBrush">The brush to draw with.</param>
        /// <param name="rct">The rectangle to draw in.</param>
        /// <param name="x">The x position of the cell.</param>
        /// <param name="y">The y position of the cell.</param>
        private void DrawCounts(Graphics gx, Font drawFont, Brush gridBrush, Rectangle rct, int x, int y) {
            int count = GetNeighborsActive(x, y);
            if (count > 0) {
                gx.DrawString(count.ToString(),
                    drawFont, gridBrush, rct);
            }
        }

        /// <summary>
        /// Draws the HUD.
        /// </summary>
        /// <param name="gx">The graphics object to draw on.</param>
        /// <param name="imgSize">The size of the universe's image.</param>
        private void DrawHUD(Graphics gx, Size imgSize) {
            Rectangle hudRect = new Rectangle(
                imgSize.Width / 200, imgSize.Height / 2,
                imgSize.Width / 3, (imgSize.Height / 2) - 30);
            Bitmap bmp = new Bitmap(350, 200);
            Graphics nestedGx = Graphics.FromImage(bmp);
            Font drawFont = new Font(FontFamily.GenericSansSerif, 13f);
            Brush drawBrush = new SolidBrush(Color.FromArgb(160,
                Color.FromKnownColor(KnownColor.Red)));
            nestedGx.DrawString("Generation: " + Generation, drawFont,
                drawBrush, new Point(10, 135));
            nestedGx.DrawString("Cell Count: " + CountAlive(), drawFont,
                drawBrush, new Point(10, 150));
            string bound = GetBoundaryType(false) ? "Toroidal" : "Finite";
            nestedGx.DrawString("Boundary Type: " + bound, drawFont,
                drawBrush, new Point(10, 165));
            nestedGx.DrawString("Universe Size: { Width = " + Width + ", Height = " + Height + " }",
                drawFont, drawBrush, new Point(10, 180));
            nestedGx.Dispose();
            gx.DrawImage(bmp, hudRect);
        }

        /// <summary>
        /// Draws the grid on the graphics object.
        /// </summary>
        /// <param name="gx">The graphics object to draw on.</param>
        /// <param name="cellWidth">The width of each cell.</param>
        /// <param name="cellHeight">The height of each cell.</param>
        private void DrawGrid(Graphics gx, int cellWidth, int cellHeight) {
            Rectangle cellRect = Rectangle.Empty;
            Pen gridPen = new Pen(Color.FromKnownColor(Config.GridColor), 1);
            Pen gridx10Pen = new Pen(Color.FromKnownColor(Config.Gridx10Color), 5);
            //draw the normal grid
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    cellRect.X = x * cellWidth; cellRect.Width = cellWidth; 
                    cellRect.Y = y * cellHeight; cellRect.Height = cellHeight;
                    gx.DrawRectangle(gridPen, cellRect.X, cellRect.Y,
                        cellRect.Width, cellRect.Height);
                }
            }
            //draw the x10 grid.
            for (int x = 0; x < Width; x += 10) {
                for (int y = 0; y < Height; y += 10) {
                    cellRect.X = x * cellWidth; cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth * 10; cellRect.Height = cellHeight * 10;
                    gx.DrawRectangle(gridx10Pen, cellRect.X, cellRect.Y,
                        cellRect.Width, cellRect.Height);
                }
            }
            gridx10Pen.Dispose();
            gridPen.Dispose();
        }

        /// <summary>
        /// Draws the universe.
        /// </summary>
        /// <returns>A bitmap drawing of the universe.</returns>
        public Bitmap DrawUniverse() {
            int cellWidth = 30, cellHeight = 30;
            Bitmap bmp = new Bitmap(cellWidth * Width, cellHeight * Height);
            Graphics gx = Graphics.FromImage(bmp);

            // A Pen for drawing the grid lines (color, width)
            Font drawFont = new Font(FontFamily.GenericSansSerif, cellWidth / 2.0f);
            Brush gridBrush = new SolidBrush(Color.FromKnownColor(Config.GridColor));

            // A Brush for filling living cells interiors (color)
            Brush liveBrush = new SolidBrush(Color.FromKnownColor(Config.ActiveColor));
            Brush deadBrush = new SolidBrush(Color.FromKnownColor(Config.InactiveColor));

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < Height; y++) {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < Width; x++) {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth; cellRect.Width = cellWidth;
                    cellRect.Y = y * cellHeight; cellRect.Height = cellHeight;

                    // Fill the cell with alive or dead brush.
                    gx.FillRectangle(universe[x, y] == true ?
                        liveBrush : deadBrush, cellRect);
                    if (Config.DisplayCounts) { 
                        DrawCounts(gx, drawFont, gridBrush, cellRect, x, y); 
                    }
                }
            }
            if (Config.DisplayGrid) { DrawGrid(gx, cellWidth, cellHeight); }
            if (Config.DisplayHUD) { DrawHUD(gx, bmp.Size); }

            // Cleaning up pens and brushes
            liveBrush.Dispose();
            deadBrush.Dispose();
            gridBrush.Dispose();
            drawFont.Dispose();
            gx.Dispose();
            return bmp;
        }

        /// <summary>
        /// Toggles a cell's state.
        /// </summary>
        /// <param name="x">The x position of the cell.</param>
        /// <param name="y">The y position of the cell.</param>
        public void ToggleCell(int x, int y) {
            if (x < 0 || y < 0) { return; }
            if (x >= Width || y >= Height) { return; }
            universe[x, y] = !universe[x, y];
        }

        /// <summary>
        /// Sets the individual cell's state.
        /// </summary>
        /// <param name="x">The x position of the cell.</param>
        /// <param name="y">The y position of the cell.</param>
        /// <param name="state">The state to change the cell to.</param>
        public void SetCell(int x, int y, bool state) {
            if (x < 0 || y < 0) { return; }
            if (x >= Width || y >= Height) { return; }
            universe[x, y] = state;
        }

        /// <summary>
        /// Counts the number of "alive" cells.
        /// </summary>
        /// <returns>The number of "alive" cells.</returns>
        public int CountAlive() {
            int alive = 0;
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    alive += universe[x, y] ? 1 : 0;
                }
            }
            return alive;
        }
    }
}
