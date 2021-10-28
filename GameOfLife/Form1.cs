using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using TALOREAL;

namespace GameOfLife {

    public partial class Form1 : Form {

        // The universe array
        bool[,] universe = new bool[30, 30];

        #region Drawing Colors
        KnownColor GridColor {
            get {
                if (!Settings.GetValue("gridClr", out int val)) {
                    val = 35; // KnownColor.Black;
                }
                return (KnownColor)val;
            }
            set { Settings.SetValue("gridClr", (int)value); }
        }

        KnownColor InactiveColor {
            get {
                if (!Settings.GetValue("inactiveClr", out int val)) {
                    val = 164; //KnownColor.White;
                }
                return (KnownColor)val;
            }
            set { Settings.SetValue("inactiveClr", (int)value); }
        }

        KnownColor ActiveColor {
            get {
                if (!Settings.GetValue("activeClr", out int val)) {
                    val = 78; // KnownColor.Gray;
                }
                return (KnownColor)val;
            }
            set { Settings.SetValue("activeClr", (int)value); }
        }
        #endregion

        // The Timer class
        Timer timer = new Timer();

        // Generations
        int Generations = 0;

        const int minSpeed = 100, maxSpeed = 1000;

        int Interval {
            get {
                if (!Settings.GetValue("interval", out int val)) {
                    val = timer.Interval;
                    ToggleSpeedButtons();
                }
                else if (val != timer.Interval) {
                    val = (val > maxSpeed ? maxSpeed : val) < minSpeed ? minSpeed : val;
                    Settings.SetValue("interval", val);
                    timer.Interval = val;
                    ToggleSpeedButtons();
                }
                return val;
            }
            set {
                //limit the interval to between minSpeed (100) and maxSpeed (1000).
                value = (value > maxSpeed ? maxSpeed : value) < minSpeed ? minSpeed : value;
                Settings.SetValue("interval", value);
                timer.Interval = value;
                ToggleSpeedButtons();
            }
        }

        int RandomSeed {
            get {
                if (!Settings.GetValue("seed", out int val)) {
                    Settings.SetValue("seed", val);
                }
                return val;
            } 
            set { Settings.SetValue("seed", value); }
        }

        Size UniverseSize {
            get {
                if (!Settings.GetValue("width", out int width)) {
                    width = universe.GetLength(0);
                }
                if (!Settings.GetValue("height", out int height)) {
                    height = universe.GetLength(1);
                }
                if (width != universe.GetLength(0) || height != universe.GetLength(1)) {
                    UpdateUniverseSize(new Size(width, height));
                }
                return new Size(universe.GetLength(0), universe.GetLength(1)); 
            }
            set {
                bool sameWidth = value.Width == universe.GetLength(0);
                bool sameHeight = value.Height == universe.GetLength(1);
                if (sameWidth && sameHeight) {
                    Settings.SetValue("width", value.Width);
                    Settings.SetValue("height", value.Height);
                    return;
                }
                UpdateUniverseSize(value); 
            }
        }

        bool Toroidal { 
            get {
                if (!Settings.GetValue("toroidal", out bool toroidal)) {
                    toroidal = toroidalToolStripMenuItem.Checked;
                    Settings.SetValue("toroidal", toroidal);
                }
                else if (toroidalToolStripMenuItem.Checked != toroidal) { 
                    toroidalToolStripMenuItem.Checked = toroidal; 
                }
                return toroidal;
            }
            set {
                Settings.SetValue("toroidal", value);
                toroidalToolStripMenuItem.Checked = value;
            }
        }


        public Form1() {
            InitializeComponent();

            Toroidal = Toroidal;

            // Generate new universe if settings specify a size.
            bool widthed = Settings.GetValue("width", out int width);
            bool heighted = Settings.GetValue("height", out int height);
            UniverseSize = (widthed && heighted) ? new Size(width, height) :
                 new Size(universe.GetLength(0), universe.GetLength(1));

            // Setup the timer
            timer.Interval = 300; // default
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running

            ToggleSpeedButtons();
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Recreates the universe with a new size, preserves what data possible.
        /// </summary>
        /// <param name="size">The new size of the universe.</param>
        private void UpdateUniverseSize(Size size) {
            bool[,] sketch = new bool[size.Width, size.Height];
            for (int x = 0; x < size.Width && x < universe.GetLength(0); x++) {
                for (int y = 0; y < size.Height && y < universe.GetLength(1); y++) {
                    sketch[x, y] = universe[x, y];
                }
            }
            Settings.SetValue("width", size.Width);
            Settings.SetValue("height", size.Height);
            universe = sketch;
        }

        // Calculate the next generation of cells
        private void NextGeneration() {
            int width = universe.GetLength(0), height = universe.GetLength(1);
            bool[,] next = new bool[width, height];
            for (int x = 0; x < width; x++) {
                for (int y = 0; y < height; y++) {
                    int actives = GetNeighborsActive(x, y);
                    next[x, y] = GetNextGenerationState(GetState(x, y), actives);
                }
            }
            universe = next;

            // Increment generation count
            Generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = 
                "Generations = " + Generations.ToString() + ", ";
            UpdateAliveStatus();
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
        /// Gets the cell's next state.
        /// </summary>
        /// <param name="active">Is it currently on or off?</param>
        /// <param name="neighborsOn">How many neighbors are active right now?</param>
        /// <returns>The new state for the cell.</returns>
        private bool GetNextGenerationState(bool active, int neighborsOn) {
            return ((neighborsOn == 3) || (active && neighborsOn > 1 && neighborsOn < 4));
        }

        /// <summary>
        /// Get the alive or dead state of a particular cell.
        /// </summary>
        /// <param name="x">The x position of the cell.</param>
        /// <param name="y">The y position of the cell.</param>
        /// <returns>The alive or dead state of the cell.</returns>
        private bool GetState(int x, int y) {
            while (x < 0 && Toroidal) { x += universe.GetLength(0); }
            while (x >= universe.GetLength(0) && Toroidal) { x -= universe.GetLength(0); }
            while (y < 0 && Toroidal) { y += universe.GetLength(1); }
            while (y >= universe.GetLength(1) && Toroidal) { y -= universe.GetLength(1); }
            if (x < 0 || x >= universe.GetLength(0)) { return false; }
            if (y < 0 || y >= universe.GetLength(1)) { return false; }
            return universe[x, y];
        }

        // The event called by the timer every Interval milliseconds.
        private void Timer_Tick(object sender, EventArgs e) {
            NextGeneration();
            graphicsPanel1.Invalidate();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e) {
            // Calculate the width and height of each cell in pixels
            // CELL WIDTH = WINDOW WIDTH / NUMBER OF CELLS IN X
            int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
            // CELL HEIGHT = WINDOW HEIGHT / NUMBER OF CELLS IN Y
            int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

            // A Pen for drawing the grid lines (color, width)
            Pen gridPen = new Pen(Color.FromKnownColor(GridColor), 1);
            Font drawFont = new Font(FontFamily.GenericSansSerif, cellWidth / 4.0f);
            Brush gridBrush = new SolidBrush(Color.FromKnownColor(GridColor));

            // A Brush for filling living cells interiors (color)
            Brush liveBrush = new SolidBrush(Color.FromKnownColor(ActiveColor));
            Brush deadBrush = new SolidBrush(Color.FromKnownColor(InactiveColor));

            // Iterate through the universe in the y, top to bottom
            for (int y = 0; y < universe.GetLength(1); y++) {
                // Iterate through the universe in the x, left to right
                for (int x = 0; x < universe.GetLength(0); x++) {
                    // A rectangle to represent each cell in pixels
                    Rectangle cellRect = Rectangle.Empty;
                    cellRect.X = x * cellWidth;
                    cellRect.Y = y * cellHeight;
                    cellRect.Width = cellWidth;
                    cellRect.Height = cellHeight;

                    // Fill the cell with alive or dead brush.
                    e.Graphics.FillRectangle(universe[x, y] == true ? 
                        liveBrush : deadBrush, cellRect);
                    int neighborsOn = GetNeighborsActive(x, y);
                    if (neighborsOn > 0 && neighborCountsToolStripMenuItem.Checked) {
                        e.Graphics.DrawString(neighborsOn.ToString(),
                            drawFont, gridBrush, cellRect);
                    }

                    // Outline the cell with a pen
                    if (gridToolStripMenuItem.Checked) {
                        e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                    }
                }
            }
            // Cleaning up pens and brushes
            liveBrush.Dispose();
            deadBrush.Dispose();
            gridBrush.Dispose();
            gridPen.Dispose();
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e) {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left) {
                // Calculate the width and height of each cell in pixels
                int cellWidth = graphicsPanel1.ClientSize.Width / universe.GetLength(0);
                int cellHeight = graphicsPanel1.ClientSize.Height / universe.GetLength(1);

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = e.X / cellWidth;
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = e.Y / cellHeight;

                // Toggle the cell's state
                universe[x, y] = !universe[x, y];

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
            UpdateAliveStatus();
        }

        /// <summary>
        /// Toggles the timer and changes the tooltip button's icon.
        /// </summary>
        private void startStopToolStripButton_Click(object sender, EventArgs e) {
            timer.Enabled = !timer.Enabled;
            startStopToolStripButton.Image = (timer.Enabled) ?
                global::GameOfLife.Properties.Resources.Pause :
                global::GameOfLife.Properties.Resources.Start;
        }

        /// <summary>
        /// Slows down the timer's interval.
        /// </summary>
        private void slowerToolStripButton_Click(object sender, EventArgs e) {
            Interval += 100;
            ToggleSpeedButtons();
        }

        /// <summary>
        /// Speeds up the timer's interval.
        /// </summary>
        private void fasterToolStripButton_Click(object sender, EventArgs e) {
            Interval -= 100;
            ToggleSpeedButtons();
        }

        /// <summary>
        /// Toggles the speed buttons and updates the interval displayed.
        /// </summary>
        private void ToggleSpeedButtons() {
            fasterToolStripButton.Enabled = Interval > minSpeed;
            slowerToolStripButton.Enabled = Interval < maxSpeed;
            toolStripStatusLabelInterval.Text = "Interval = " + Interval + " ms, ";
        }

        /// <summary>
        /// Reset the universe and stop the timer.
        /// </summary>
        private void newToolStripButton_Click(object sender, EventArgs e) {
            universe = new bool[universe.GetLength(0), universe.GetLength(1)];
            PauseSim();
        }

        /// <summary>
        /// Force the application to close.
        /// </summary>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            Application.Exit();
        }

        /// <summary>
        /// Change boundary rules and force redraw.
        /// </summary>
        private void toroidalToolStripMenuItem_Click(object sender, EventArgs e) {
            Toroidal = !toroidalToolStripMenuItem.Checked;
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Reload settings from last time app opened.
        /// </summary>
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e) {
            if (Settings.ReloadSettings()) {
                bool worked = Settings.GetValue("width", out int width);
                width = worked ? width : universe.GetLength(0);
                worked = Settings.GetValue("height", out int height);
                height = worked ? height : universe.GetLength(1);
                UniverseSize = new Size(width, height);
                worked = Settings.GetValue("interval", out int interval);
                Interval = worked ? interval : Interval;
                worked = Settings.GetValue("seed", out int seed);
                RandomSeed = worked ? seed : RandomSeed;
                worked = Settings.GetValue("toroidal", out bool toro);
                Toroidal = worked ? toro : Toroidal;
                worked = Settings.GetValue("gridClr", out int clr);
                GridColor = worked ? (KnownColor)clr : GridColor;
                worked = Settings.GetValue("inactiveClr", out clr);
                InactiveColor = worked ? (KnownColor)clr : InactiveColor;
                worked = Settings.GetValue("activeClr", out clr);
                ActiveColor = worked ? (KnownColor)clr : ActiveColor;
                ForceRedraw(null, null);
            }
        }

        /// <summary>
        /// Reset all settings to defaults.
        /// </summary>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings.Clear();
            UniverseSize = new Size(30, 30);
            Interval = 300;
            RandomSeed = 0;
            Toroidal = false;
            GridColor = KnownColor.Black;
            InactiveColor = KnownColor.White;
            ActiveColor = KnownColor.Gray;
            ForceRedraw(null, null);
        }

        private void PauseSim() {
            timer.Enabled = false;
            startStopToolStripButton.Image = global::GameOfLife.Properties.Resources.Start;
            graphicsPanel1.Invalidate();
            UpdateAliveStatus();
        }

        /// <summary>
        /// Save a universe to a file.
        /// </summary>
        private void saveToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            SaveFileDialog dlg = new SaveFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2; dlg.DefaultExt = "cells";
            if (DialogResult.OK == dlg.ShowDialog()) {
                Size usize = UniverseSize;
                StreamWriter writer = new StreamWriter(dlg.FileName);
                writer.WriteLine("!This is my comment.");
                for (int y = 0; y < usize.Height; y++) {
                    string row = "";
                    for (int x = 0; x < usize.Width; x++) {
                        row += universe[x, y] ? "0" : ".";
                    }
                    writer.WriteLine(row);
                }
                writer.Close();
            }
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Load a universe from a file.
        /// </summary>
        private void openToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All Files|*.*|Cells|*.cells";
            dlg.FilterIndex = 2;
            if (DialogResult.OK == dlg.ShowDialog()) {
                StreamReader reader = new StreamReader(dlg.FileName);
                int maxWidth = 0;
                int maxHeight = 0;
                //read each line and store in a list.
                List<string> rows = new List<string>();
                while (!reader.EndOfStream) {
                    string row = reader.ReadLine();
                    if (row.Length == 0 || row[0] == '!') { continue; }
                    rows.Add(row);
                    maxWidth = row.Length > maxWidth ? row.Length : maxWidth;
                    maxHeight += 1;
                }
                reader.Close(); //read file only once and close ASAP
                //recreate the file's universe.
                universe = new bool[maxWidth, maxHeight];
                for (int y = 0; y < rows.Count; y++) {
                    for (int x = 0; x < rows[y].Length; x++) {
                        //cell is only alive if '0'
                        universe[x, y] = rows[y][x] == '0';
                    }
                }
            }
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Force the graphics panel to redraw.
        /// </summary>
        private void ForceRedraw(object sender, EventArgs e) {
            if (sender != null && sender is ToolStripMenuItem) {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                item.Checked = !item.Checked;
            }
            toolStripStatusSeed.Text = "Random Seed = " + RandomSeed + ", ";
            graphicsPanel1.Invalidate();
            UpdateAliveStatus();
        }

        private void changeRandomizerSeedToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void setRandomizerSeedToTimeToolStripMenuItem_Click(object sender, EventArgs e) {
            RandomSeed = (int)DateTime.Now.TimeOfDay.TotalMilliseconds;
            ForceRedraw(null, null);
        }

        private void randomizeToolStripMenuItem_Click(object sender, EventArgs e) {
            Random rng = new Random(RandomSeed);
            for (int x = 0; x < universe.GetLength(0); x++) {
                for (int y = 0; y < universe.GetLength(1); y++) {
                    universe[x, y] = rng.Next(0, 100) % 2 == 1;
                }
            }
            ForceRedraw(null, null);
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e) {
            frmGetNewSize resizer = new frmGetNewSize();
            resizer.ShowDialog();
            if (resizer.DialogResult == DialogResult.OK) {
                UniverseSize = new Size(resizer.NewWidth, resizer.NewHeight);
            }
            ForceRedraw(null, null);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void changeUniverseSizeToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void UpdateAliveStatus() {
            int alive = 0;
            for (int x = 0; x < universe.GetLength(0); x++) {
                for (int y = 0; y < universe.GetLength(1); y++) {
                    if (universe[x, y]) { alive++; }
                }
            }
            toolStripStatusAlive.Text = "Alive = " + alive + ", ";
        }
    }
}
