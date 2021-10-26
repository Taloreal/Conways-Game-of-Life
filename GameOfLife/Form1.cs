using System;
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
        bool[,] universe = new bool[5, 5];

        // Drawing colors
        Color gridColor = Color.Black;
        Color inactiveColor = Color.White;
        Color activeColor = Color.LightGray;

        // The Timer class
        Timer timer = new Timer();

        // Generation count
        int generations = 0;

        public Form1() {
            InitializeComponent();
            // Get color settings
            gridColor = Settings.GetValue("gridClr", out int clr) ?
                Color.FromKnownColor((KnownColor)clr) : gridColor;
            activeColor = Settings.GetValue("activeClr", out clr) ?
                Color.FromKnownColor((KnownColor)clr) : activeColor;
            inactiveColor = Settings.GetValue("inactiveClr", out clr) ?
                Color.FromKnownColor((KnownColor)clr) : inactiveColor;
            // Generate new universe if settings specify a size.
            universe = (Settings.GetValue("width", out int width) &&
                Settings.GetValue("height", out int height)) ?
                new bool[width, height] : universe;
            // Setup the timer
            timer.Interval = Settings.GetValue("interval", 
                out int interval) ? interval : 300; // milliseconds
            timer.Tick += Timer_Tick;
            timer.Enabled = false; // start timer running
            fasterToolStripButton.Enabled = Settings.GetValue("faster", 
                out bool faster) ? faster : true;
            slowerToolStripButton.Enabled = Settings.GetValue("slower", 
                out bool slower) ? slower : true;
            UpdateUIInterval();
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
            generations++;

            // Update status strip generations
            toolStripStatusLabelGenerations.Text = "Generations = " + generations.ToString();
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
        /// <param name="toroidal">Should the universe wrap around?</param>
        /// <returns>The alive or dead state of the cell.</returns>
        private bool GetState(int x, int y) {
            if (!Settings.GetValue("toroidal", out bool toroidal)) {
                Settings.SetValue("toroidal", toroidal);
            }
            while (x < 0 && toroidal) { x += universe.GetLength(0); }
            while (x >= universe.GetLength(0) && toroidal) { x -= universe.GetLength(0); }
            while (y < 0 && toroidal) { y += universe.GetLength(1); }
            while (y >= universe.GetLength(1) && toroidal) { y -= universe.GetLength(1); }
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
            Pen gridPen = new Pen(gridColor, 1);

            // A Brush for filling living cells interiors (color)
            Brush liveBrush = new SolidBrush(activeColor);
            Brush deadBrush = new SolidBrush(inactiveColor);

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
                    // Outline the cell with a pen
                    e.Graphics.DrawRectangle(gridPen, cellRect.X, cellRect.Y, cellRect.Width, cellRect.Height);
                }
            }
            // Cleaning up pens and brushes
            liveBrush.Dispose();
            deadBrush.Dispose();
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
            int interval = (Settings.GetValue("interval", out int pinterval) ?
                pinterval : timer.Interval) + 100;
            SaveIntervalSettings(interval);
        }

        /// <summary>
        /// Speeds up the timer's interval.
        /// </summary>
        private void fasterToolStripButton_Click(object sender, EventArgs e) {
            int interval = (Settings.GetValue("interval", out int pinterval) ?
                pinterval : timer.Interval) - 100;
            SaveIntervalSettings(interval);
        }

        /// <summary>
        /// Sets the timer's interval and save's the settings.
        /// </summary>
        /// <param name="interval">The new interval to use.</param>
        private void SaveIntervalSettings(int interval) {
            //limit the interval to between 100 to 1000.
            interval = (interval > 1000 ? 1000 : interval) < 100 ? 100 : interval;
            timer.Interval = interval;
            Settings.SetValue("interval", timer.Interval);
            fasterToolStripButton.Enabled = timer.Interval > 100;
            slowerToolStripButton.Enabled = timer.Interval < 1000;
            Settings.SetValue("faster", fasterToolStripButton.Enabled);
            Settings.SetValue("slower", slowerToolStripButton.Enabled);
            UpdateUIInterval();
        }

        private void UpdateUIInterval() {
            toolStripStatusLabelInterval.Text = "Interval = " + timer.Interval + " ms ";
        }

        /// <summary>
        /// Reset the universe and stop the timer.
        /// </summary>
        private void newToolStripButton_Click(object sender, EventArgs e) {
            timer.Enabled = false;
            startStopToolStripButton.Image = global::GameOfLife.Properties.Resources.Start;
            universe = new bool[universe.GetLength(0), universe.GetLength(1)];
            graphicsPanel1.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }
    }
}
