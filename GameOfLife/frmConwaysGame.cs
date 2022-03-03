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

    public partial class frmConwaysGame : Form {

        /// <summary>
        /// Only generate the KnownColors list once by reusing the same form.
        /// </summary>
        static frmCustomizeColors GetColors = new frmCustomizeColors();

        /// <summary>
        /// Creates a new window to play Game of Life in.
        /// </summary>
        public frmConwaysGame() {
            InitializeComponent();
            graphicsPanel1.ContextMenuStrip = graphicsPanelContextMenu;
            hudMenuItem.Checked = Config.DisplayHUD;
            gridMenuItem.Checked = Config.DisplayGrid;
            countsMenuItem.Checked = Config.DisplayCounts;
            hudContext.Checked = hudMenuItem.Checked;
            gridContext.Checked = gridMenuItem.Checked;
            countsContext.Checked = countsMenuItem.Checked;
            toroidalMenuItem.Checked = Config.Universe.GetBoundaryType(false);

            Config.ForceRedraw += ForceRedraw;
            Config.Universe.ForceRedraw += ForceRedraw;

            ToggleSpeedButtons();
            ForceRedraw(null, null);
            this.Icon = Icon.FromHandle(global::GameOfLife.Properties.Resources.icon.GetHicon());
        }

        /// <summary>
        /// Drawthe universe from a bitmap. (DEPRECATED: 11/03/2021)
        /// </summary>
        /// <param name="changedTo"></param>
        private void UniverseDrawn(object changedTo) {
            if ((changedTo is Bitmap) == false) { return; }
            Bitmap bmp = (Bitmap)changedTo;
            Graphics gx = graphicsPanel1.CreateGraphics();
            gx.DrawImage(bmp, 0, 0, graphicsPanel1.Width, graphicsPanel1.Height);
            gx.Dispose();
        }

        /// <summary>
        /// Redraw the universe when graphics panel is painted.
        /// </summary>
        private void graphicsPanel1_Paint(object sender, PaintEventArgs e) {
            //UniverseDrawn(Config.Universe.Draw());
            Bitmap bmp = Config.Universe.DrawUniverse();
            e.Graphics.DrawImage(bmp, 0, 0, graphicsPanel1.Width, graphicsPanel1.Height);
        }

        /// <summary>
        /// Toggle a cell if left click.
        /// </summary>
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
            worked = Settings.GetValue("pauseOnStable", out bool pausable);
            Config.PauseWhenStable = worked ? pausable : true;
            worked = Settings.GetValue("gridClr", out int clr);
            Config.GridColor = worked ? (KnownColor)clr : Config.GridColor;
            worked = Settings.GetValue("gridx10Clr", out clr);
            Config.Gridx10Color = worked ? (KnownColor)clr : Config.Gridx10Color;
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
            Config.PauseWhenStable = true;
            Config.GridColor = KnownColor.Black;
            Config.Gridx10Color = KnownColor.Black;
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
                List<string> rows = new List<string>();
                while (!reader.EndOfStream) {
                    string row = reader.ReadLine();
                    if (row.Length == 0 || row[0] == '!') { continue; }
                    rows.Add(row);
                    maxWidth = row.Length > maxWidth ? row.Length : maxWidth;
                }
                reader.Close();
                Config.UniverseSize = new Size(maxWidth, rows.Count);
                for (int y = 0; y < rows.Count; y++) {
                    for (int x = 0; x < rows[y].Length; x++) {
                        Config.Universe.SetCell(x, y, rows[y][x] == 'O');
                    }
                }
                Config.Universe.Generation = 0;
            }
        }

        /// <summary>
        /// Updates display options then redraws the universe.
        /// </summary>
        /// <param name="sender">The context item or menu item for the display option.</param>
        private void ChangeDisplayOption(object sender, EventArgs e) {
            if (sender != null && sender is ToolStripMenuItem){
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
            ForceRedraw(sender, e);
        }

        /// <summary>
        /// Force the graphics panel to redraw and display universe info.
        /// </summary>
        private void ForceRedraw(object sender, EventArgs e) {
            RedrawMenuItems();
            RedrawToolStrips();
            graphicsPanel1.Invalidate();
        }

        /// <summary>
        /// Redraws the menu items.
        /// </summary>
        private void RedrawMenuItems() {
            hudMenuItem.Checked = Config.DisplayHUD;
            gridMenuItem.Checked = Config.DisplayGrid;
            countsMenuItem.Checked = Config.DisplayCounts;
            hudContext.Checked = hudMenuItem.Checked;
            gridContext.Checked = gridMenuItem.Checked;
            countsContext.Checked = countsMenuItem.Checked;
            toroidalMenuItem.Checked = Config.Universe.GetBoundaryType(false);
            startStopToolStripButton.Image = (Config.Running) ?
                global::GameOfLife.Properties.Resources.Pause :
                global::GameOfLife.Properties.Resources.Start;
            fasterToolStripButton.Enabled = Config.Interval > Config.MinSpeed;
            slowerToolStripButton.Enabled = Config.Interval < Config.MaxSpeed;
        }

        /// <summary>
        /// Redraws the toolstrip.
        /// </summary>
        private void RedrawToolStrips() {
            toolStripStatusAlive.Text = "Alive = " + Config.Universe.CountAlive() + ", ";
            toolStripStatusSeed.Text = "Random Seed = " + Config.RandomSeed + ", ";
            toolStripStatusLabelInterval.Text = "Interval = " + Config.Interval + " ms, ";
            toolStripStatusLabelGenerations.Text = "Generations = " +
                Config.Universe.Generation.ToString() + ", ";
        }

        /// <summary>
        /// Prompt the user to change the random seed.
        /// </summary>
        private void changeRandomizerSeedToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            frmNumberInput getSeed = new frmNumberInput("Change Seed",
                "New Seed: ", false);
            if (getSeed.ShowDialog() == DialogResult.OK) {
                Config.RandomSeed = getSeed.Input;
            }
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Set the random seed to current time.
        /// </summary>
        private void setRandomizerSeedToTimeToolStripMenuItem_Click(object sender, EventArgs e) {
            Config.RandomSeed = (int)DateTime.Now.TimeOfDay.TotalMilliseconds;
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Randomize the universe.
        /// </summary>
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

        /// <summary>
        /// Prompt the user to resize the universe.
        /// </summary>
        private void resizeToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            frmGetNewSize resizer = new frmGetNewSize();
            if (resizer.ShowDialog() == DialogResult.OK) {
                Config.UniverseSize = new Size(resizer.NewWidth, resizer.NewHeight);
            }
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Prompt the user to change the interval.
        /// </summary>
        private void optionsToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            frmNumberInput getInterval = new frmNumberInput("Change Interval",
                "Generation interval: ");
            if (getInterval.ShowDialog() == DialogResult.OK) {
                Config.Interval = getInterval.Input;
            }
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Prompt the user to change the GUI colors.
        /// </summary>
        private void customizeToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            GetColors.ChooseColor(Config.GridColor, Config.Gridx10Color,
                Config.ActiveColor, Config.InactiveColor);
            if (GetColors.DialogResult == DialogResult.OK) {
                Config.GridColor = GetColors.GridColor;
                Config.Gridx10Color = GetColors.GridX10Color;
                Config.ActiveColor = GetColors.ActiveColor;
                Config.InactiveColor = GetColors.InactiveColor;
            }
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Makes the universe calculate the next generation.
        /// </summary>
        private void nextToolStripButton_Click(object sender, EventArgs e) {
            Config.Universe.NextGeneration();
        }

        /// <summary>
        /// Has the user choose a generation to run to in a dialogue box.
        /// </summary>
        private void runToToolStripMenuItem_Click(object sender, EventArgs e) {
            PauseSim();
            frmNumberInput getRunTo = new frmNumberInput("Stop at",
                "Run To: ", false);
            if (getRunTo.ShowDialog() == DialogResult.OK) {
                Config.RunTo = getRunTo.Input;
            }
            ForceRedraw(null, null);
        }

        /// <summary>
        /// Displays a dialogue box offering to the user to change the rules.
        /// </summary>
        private void changeEvolutionRulesToolStripMenuItem_Click(object sender, EventArgs e) {
            frmGetRuleSet rules = new frmGetRuleSet();
            if (rules.ShowDialog() == DialogResult.OK) {
                ForceRedraw(null, null);
            }
        }

        private void pauseWhenStableToolStripMenuItem_Click(object sender, EventArgs e) {
            Config.PauseWhenStable = pauseWhenStableToolStripMenuItem.Checked;
        }
    }
}
