using System;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Threading.Tasks;
using System.Collections.Generic;

using TALOREAL;

namespace GameOfLife {

    public delegate void PropertyChanged(object changedTo);

    public static class Config {

        private static Timer Timer = new Timer();
        public const int MinSpeed = 1, MaxSpeed = 1000;
        public static Universe Universe = new Universe();

        public static event EventHandler ForceRedraw;

        /// <summary>
        /// Initializes the timer and resets the universe.
        /// </summary>
        static Config() {
            Timer.Interval = 300;
            Timer.Interval = Interval;
            Timer.Enabled = false;
            Timer.Tick += Universe.Timer_Tick;
            ResetUniverse();
        }

        /// <summary>
        /// Is the universe evolving?
        /// </summary>
        public static bool Running {
            get { return Timer.Enabled; } 
            set { 
                Timer.Enabled = value;
                ForceRedraw?.Invoke(null, null);
            } 
        }

        /// <summary>
        /// Get or Set the generation number to stop at.
        /// </summary>
        public static int RunTo {
            get {
                bool worked = Settings.GetValue("runTo", out int value);
                return worked ? value : -1;
            }
            set => Settings.SetValue("runTo", value);
        }

        /// <summary>
        /// The universe's size.
        /// </summary>
        public static Size UniverseSize {
            get { return Universe.Size; }
            set { 
                Universe.Size = value;
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// The color of the grid.
        /// </summary>
        public static KnownColor GridColor {
            get {
                if (!Settings.GetValue("gridClr", out int val)) {
                    val = 35; // KnownColor.Black;
                }
                return (KnownColor)val;
            }
            set { 
                Settings.SetValue("gridClr", (int)value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// The color of the grid every 10 cells.
        /// </summary>
        public static KnownColor Gridx10Color {
            get {
                if (!Settings.GetValue("gridx10Clr", out int val)) {
                    val = 35; // KnownColor.Black;
                }
                return (KnownColor)val;
            }
            set {
                Settings.SetValue("gridx10Clr", (int)value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// The color of inactive cells.
        /// </summary>
        public static KnownColor InactiveColor {
            get {
                if (!Settings.GetValue("inactiveClr", out int val)) {
                    val = 164; //KnownColor.White;
                }
                return (KnownColor)val;
            }
            set { 
                Settings.SetValue("inactiveClr", (int)value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// The color of active cells.
        /// </summary>
        public static KnownColor ActiveColor {
            get {
                if (!Settings.GetValue("activeClr", out int val)) {
                    val = 78;
                }
                return (KnownColor)val;
            }
            set { 
                Settings.SetValue("activeClr", (int)value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// The interval (ms) that the universe attempts to refresh at.
        /// </summary>
        public static int Interval {
            get {
                if (!Settings.GetValue("interval", out int val)) {
                    val = Timer.Interval;
                    Settings.SetValue("interval", val);
                    ForceRedraw?.Invoke(null, null);
                }
                else if (val != Timer.Interval) {
                    val = val > MaxSpeed ? MaxSpeed : val;
                    val = val < MinSpeed ? MinSpeed : val;
                    Timer.Interval = val;
                    Settings.SetValue("interval", val);
                    ForceRedraw?.Invoke(null, null);
                }
                return val;
            }
            set {
                //limit the interval to between minSpeed (50) and maxSpeed (1000).
                value = value > MaxSpeed ? MaxSpeed : value;
                value = value < MinSpeed ? MinSpeed : value;
                Timer.Interval = value;
                Settings.SetValue("interval", value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// The random seed the universe uses.
        /// </summary>
        public static int RandomSeed {
            get {
                if (!Settings.GetValue("seed", out int val)) {
                    Settings.SetValue("seed", val);
                }
                return val;
            }
            set { 
                Settings.SetValue("seed", value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// Should the universe draw the HUD?
        /// </summary>
        public static bool DisplayHUD {
            get { return Settings.GetValue("HUD", out bool HUD) == false ? true : HUD; }
            set { 
                Settings.SetValue("HUD", value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// Should the universe draw the grid?
        /// </summary>
        public static bool DisplayGrid {
            get { return Settings.GetValue("Grid", out bool grid) == false ? true : grid; }
            set { 
                Settings.SetValue("Grid", value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// Should the universe draw active neighbor counts?
        /// </summary>
        public static bool DisplayCounts {
            get { return Settings.GetValue("Counts", out bool counts) == false ? true : counts; }
            set { 
                Settings.SetValue("Counts", value);
                ForceRedraw?.Invoke(null, null);
            }
        }

        /// <summary>
        /// Resets the universe to "factory" condition at current size.
        /// </summary>
        public static void ResetUniverse() {
            bool widthed = Settings.GetValue("width", out int width);
            bool heighted = Settings.GetValue("height", out int height);
            UniverseSize = (widthed && heighted) ? new Size(width, height) :
                 new Size(Universe.DefaultWidth, Universe.DefaultHeight);
            for (int x = 0; x < Universe.Width; x++) {
                for (int y = 0; y < Universe.Height; y++) {
                    Universe.SetCell(x, y, false);
                }
            }
            Universe.Generation = 0;
        }

    }
}
