﻿using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

using TALOREAL;

namespace GameOfLife {

    public class Universe {

        public int _Generation = 0;
        public int Generation { 
            get { return _Generation; } 
            set {
                _Generation = value;
                ForceRedraw?.Invoke(_Generation, null);
            } 
        }

        public const int DefaultWidth = 30;
        public const int DefaultHeight = 30;

        private bool[,] universe = new bool[DefaultWidth, DefaultHeight];
        public int Width => universe.GetLength(0);
        public int Height => universe.GetLength(1);

        public event EventHandler ForceRedraw;
        public event PropertyChanged SizeChanged;

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

        public void Timer_Tick(object sender, EventArgs e) {
            NextGeneration();
        }

        /// <summary>
        /// Gets the boundary type for the universe, either Toroidal or Finite.
        /// </summary>
        /// <param name="menuState">Is the current menu set to toroidal?</param>
        /// <returns>The boundary type currently in use.</returns>
        public bool GetBoundaryType(bool menuState) {
            bool fetched = Settings.GetValue("toroidal", out bool toroidal);
            if (!fetched) {
                Settings.SetValue("toroidal", menuState);
                toroidal = menuState;
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

        // Calculate the next generation of cells
        private void NextGeneration() {
            bool[,] next = new bool[Width, Height];
            for (int x = 0; x < Width; x++) {
                for (int y = 0; y < Height; y++) {
                    int actives = GetNeighborsActive(x, y);
                    next[x, y] = GetNextGenerationState(GetState(x, y), actives);
                }
            }
            universe = next;

            // Increment generation count
            Generation++;
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
        private bool GetNextGenerationState(bool active, int neighborsOn) {
            return ((neighborsOn == 3) || (active && neighborsOn > 1 && neighborsOn < 4));
        }

        public Bitmap Draw() {
            int cellWidth = 30, cellHeight = 30;
            Bitmap bmp = new Bitmap(cellWidth * Width, cellHeight * Height);
            Graphics gx = Graphics.FromImage(bmp);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(Color.FromKnownColor(Config.GridColor), 1);
            Font drawFont = new Font(FontFamily.GenericSansSerif, cellWidth / 4.0f);
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
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with alive or dead brush.
                    gx.FillRectangle(universe[x, y] == true ?
                        liveBrush : deadBrush, cellRect);
                    int neighborsOn = GetNeighborsActive(x, y);
                    if (neighborsOn > 0 && Config.DisplayCounts) {
                        gx.DrawString(neighborsOn.ToString(),
                            drawFont, gridBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    if (Config.DisplayGrid) {
                        gx.DrawRectangle(gridPen, cellRect.X, cellRect.Y,
                            cellRect.Width, cellRect.Height);
                    }
                }
            }
            // Cleaning up pens and brushes
            liveBrush.Dispose();
            deadBrush.Dispose();
            gridBrush.Dispose();
            gridPen.Dispose();
            gx.Dispose();
            return bmp;
        }

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

    }
}
