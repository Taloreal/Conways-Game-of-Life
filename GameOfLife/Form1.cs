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

        static frmCustomizeColors GetColors = new frmCustomizeColors();


        public Form1() {
            InitializeComponent();
            hudMenuItem.Checked = Config.DisplayHUD;
            gridMenuItem.Checked = Config.DisplayGrid;
            countsMenuItem.Checked = Config.DisplayCounts;
            toroidalMenuItem.Checked = Config.Universe.GetBoundaryType(false);

            Config.ForceRedraw += ForceRedraw;
            Config.Universe.ForceRedraw += ForceRedraw;

            ToggleSpeedButtons();
            ForceRedraw(null, null);
        }

        private void UniverseDrawn(object changedTo) {
            if ((changedTo is Bitmap) == false) { return; }
            Bitmap bmp = (Bitmap)changedTo;
            Graphics gx = graphicsPanel1.CreateGraphics();
            gx.DrawImage(bmp, 0, 0, graphicsPanel1.Width, graphicsPanel1.Height);
            gx.Dispose();
        }

        private void graphicsPanel1_Paint(object sender, PaintEventArgs e) {
            //UniverseDrawn(Config.Universe.Draw());
            Bitmap bmp = Config.Universe.DrawUniverse();
            e.Graphics.DrawImage(bmp, 0, 0, graphicsPanel1.Width, graphicsPanel1.Height);
        }

        private void graphicsPanel1_MouseClick(object sender, MouseEventArgs e) {
            // If the left mouse button was clicked
            if (e.Button == MouseButtons.Left) {
                // Calculate the width and height of each cell in pixels
                float cellWidth = graphicsPanel1.ClientSize.Width / (float)Config.Universe.Width;
                float cellHeight = graphicsPanel1.ClientSize.Height / (float)Config.Universe.Height;

                // Calculate the cell that was clicked in
                // CELL X = MOUSE X / CELL WIDTH
                int x = (int)(e.X / cellWidth);
                // CELL Y = MOUSE Y / CELL HEIGHT
                int y = (int)(e.Y / cellHeight);

                // Toggle the cell's state
                Config.Universe.ToggleCell(x, y);

                // Tell Windows you need to repaint
                graphicsPanel1.Invalidate();
            }
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Toggles the timer and changes the tooltip button's icon.
        /// </summary>
        private void startStopToolStripButton_Click(object sender, EventArgs e) {
            Config.Running = !Config.Running;
            startStopToolStripButton.Image = (Config.Running) ?
                global::GameOfLife.Properties.Resources.Pause :
                global::GameOfLife.Properties.Resources.Start;
        }

        /// <summary>
        /// Slows down the timer's interval.
        /// </summary>
        private void slowerToolStripButton_Click(object sender, EventArgs e) {
            Config.Interval *= 2;
            ToggleSpeedButtons();
        }

        /// <summary>
        /// Speeds up the timer's interval.
        /// </summary>
        private void fasterToolStripButton_Click(object sender, EventArgs e) {
            Config.Interval /= 2;
            ToggleSpeedButtons();
        }

        /// <summary>
        /// Toggles the speed buttons and updates the interval displayed.
        /// </summary>
        private void ToggleSpeedButtons() {
            fasterToolStripButton.Enabled = Config.Interval > Config.MinSpeed;
            slowerToolStripButton.Enabled = Config.Interval < Config.MaxSpeed;
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Reset the universe and stop the timer.
        /// </summary>
        private void newToolStripButton_Click(object sender, EventArgs e) {
            PauseSim();
            Config.ResetUniverse();
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
            toroidalMenuItem.Checked = !toroidalMenuItem.Checked;
            Config.Universe.SetBoundaryType(toroidalMenuItem.Checked);
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Reload settings from last time app opened.
        /// </summary>
        private void reloadToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings.LoadSettings();
            bool worked = Settings.GetValue("width", out int width);
            width = worked ? width : Config.Universe.Width;
            worked = Settings.GetValue("height", out int height);
            height = worked ? height : Config.Universe.Height;
            Config.UniverseSize = new Size(width, height);
            worked = Settings.GetValue("interval", out int interval);
            Config.Interval = worked ? interval : Config.Interval;
            worked = Settings.GetValue("seed", out int seed);
            Config.RandomSeed = worked ? seed : Config.RandomSeed;
            worked = Settings.GetValue("toroidal", out bool toro);
            Config.Universe.SetBoundaryType(worked ? toro : Config.Universe.GetBoundaryType(false));
            worked = Settings.GetValue("gridClr", out int clr);
            Config.GridColor = worked ? (KnownColor)clr : Config.GridColor;
            worked = Settings.GetValue("inactiveClr", out clr);
            Config.InactiveColor = worked ? (KnownColor)clr : Config.InactiveColor;
            worked = Settings.GetValue("activeClr", out clr);
            Config.ActiveColor = worked ? (KnownColor)clr : Config.ActiveColor;
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Reset all settings to defaults.
        /// </summary>
        private void resetToolStripMenuItem_Click(object sender, EventArgs e) {
            Settings.Clear();
            Config.UniverseSize = new Size(30, 30);
            Config.Interval = 300;
            Config.RandomSeed = 0;
            Config.Universe.SetBoundaryType(false);
            Config.GridColor = KnownColor.Black;
            Config.InactiveColor = KnownColor.White;
            Config.ActiveColor = KnownColor.Gray;
        }

        /// <summary>
        /// Pauses the simulation.
        /// </summary>
        private void PauseSim() {
            Config.Running = false;
            startStopToolStripButton.Image = global::GameOfLife.Properties.Resources.Start;
            ForceRedraw(null, null);
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
                Size usize = Config.UniverseSize;
                StreamWriter writer = new StreamWriter(dlg.FileName);
                writer.WriteLine("!This is my comment.");
                for (int y = 0; y < usize.Height; y++) {
                    string row = "";
                    for (int x = 0; x < usize.Width; x++) {
                        row += Config.Universe.GetState(x, y) ? "O" : ".";
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
                Config.UniverseSize = new Size(maxWidth, maxHeight);
                for (int y = 0; y < rows.Count; y++) {
                    for (int x = 0; x < rows[y].Length; x++) {
                        //cell is only alive if '0'
                        Config.Universe.SetCell(x, y, rows[y][x] == 'O');
                    }
                }
                Config.Universe.Generation = 0;
            }
        }

        /// <summary>
        /// Force the graphics panel to redraw.
        /// </summary>
        private void ForceRedraw(object sender, EventArgs e) {
            if (sender != null && sender is ToolStripMenuItem) {
                ToolStripMenuItem item = (ToolStripMenuItem)sender;
                item.Checked = !item.Checked;
                if (item.Name.ToLower().Contains("hud")) { 
                    Config.DisplayHUD = item.Checked; 
                }
                if (item.Name.ToLower().Contains("grid")) { 
                    Config.DisplayGrid = item.Checked; 
                }
                if (item.Name.ToLower().Contains("count")) { 
                    Config.DisplayCounts = item.Checked; 
                }
            }
            hudMenuItem.Checked = Config.DisplayHUD;
            gridMenuItem.Checked = Config.DisplayGrid;
            countsMenuItem.Checked = Config.DisplayCounts;
            toroidalMenuItem.Checked = Config.Universe.GetBoundaryType(false);
            toolStripStatusAlive.Text = "Alive = " + Config.Universe.CountAlive() + ", ";
            toolStripStatusSeed.Text = "Random Seed = " + Config.RandomSeed + ", ";
            toolStripStatusLabelInterval.Text = "Interval = " + Config.Interval + " ms, ";
            toolStripStatusLabelGenerations.Text = "Generations = " + 
                Config.Universe.Generation.ToString() + ", ";
            graphicsPanel1.Invalidate();
            //Config.Universe.DrawUniverse();
        }

        private void changeRandomizerSeedToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            frmNumberInput getSeed = new frmNumberInput("Change Seed",
                "New Seed: ", false);
            if (getSeed.ShowDialog() == DialogResult.OK) {
                Config.RandomSeed = getSeed.Input;
            }
            ForceRedraw(null, null);
        }

        private void setRandomizerSeedToTimeToolStripMenuItem_Click(object sender, EventArgs e) {
            Config.RandomSeed = (int)DateTime.Now.TimeOfDay.TotalMilliseconds;
            ForceRedraw(null, null);
        }

        private void randomizeToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            Random rng = new Random(Config.RandomSeed);
            for (int x = 0; x < Config.Universe.Width; x++) {
                for (int y = 0; y < Config.Universe.Height; y++) {
                    Config.Universe.SetCell(x, y, rng.Next(0, 100) % 2 == 1);
                }
            }
            Config.Universe.Generation = 0;
        }

        private void resizeToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            frmGetNewSize resizer = new frmGetNewSize();
            if (resizer.ShowDialog() == DialogResult.OK) {
                Config.UniverseSize = new Size(resizer.NewWidth, resizer.NewHeight);
            }
            ForceRedraw(null, null);
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            frmNumberInput getInterval = new frmNumberInput("Change Interval",
                "Generation interval: ");
            if (getInterval.ShowDialog() == DialogResult.OK) {
                Config.Interval = getInterval.Input;
            }
            ForceRedraw(null, null);
        }

        private void customizeToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            GetColors.ChooseColor(Config.GridColor, Config.ActiveColor, Config.InactiveColor);
            if (GetColors.DialogResult == DialogResult.OK) {
                Config.GridColor = GetColors.GridColor;
                Config.ActiveColor = GetColors.ActiveColor;
                Config.InactiveColor = GetColors.InactiveColor;
            }
            ForceRedraw(null, null);
        }
    }
}
