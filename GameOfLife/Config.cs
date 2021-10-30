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
        public const int MinSpeed = 100, MaxSpeed = 1000;
        public static Universe Universe = new Universe();

        public static event PropertyChanged IntervalChanged;

        static Config() {
            Timer.Interval = 300;
            Timer.Interval = Interval;
            Timer.Enabled = false;
            Timer.Tick += Universe.Timer_Tick;
            ResetUniverse();
        }

        public static bool Running {
            get { return Timer.Enabled; } 
            set { Timer.Enabled = value; } 
        }

        public static Size UniverseSize {
            get { return Universe.Size; }
            set { Universe.Size = value; }
        }

        public static KnownColor GridColor {
            get {
                if (!Settings.GetValue("gridClr", out int val)) {
                    val = 35; // KnownColor.Black;
                }
                return (KnownColor)val;
            }
            set { 
                Settings.SetValue("gridClr", (int)value);
                Universe.DrawUniverse();
            }
        }

        public static KnownColor InactiveColor {
            get {
                if (!Settings.GetValue("inactiveClr", out int val)) {
                    val = 164; //KnownColor.White;
                }
                return (KnownColor)val;
            }
            set { 
                Settings.SetValue("inactiveClr", (int)value);
                Universe.DrawUniverse();
            }
        }

        public static KnownColor ActiveColor {
            get {
                if (!Settings.GetValue("activeClr", out int val)) {
                    val = 78;
                }
                return (KnownColor)val;
            }
            set { 
                Settings.SetValue("activeClr", (int)value);
                Universe.DrawUniverse();
            }
        }
        public static int Interval {
            get {
                if (!Settings.GetValue("interval", out int val)) {
                    val = Timer.Interval;
                    IntervalChanged?.Invoke(val);
                }
                else if (val != Timer.Interval) {
                    val = (val > MaxSpeed ? MaxSpeed : val) < MinSpeed ? MinSpeed : val;
                    Settings.SetValue("interval", val);
                    Timer.Interval = val;
                    IntervalChanged?.Invoke(val);
                }
                return val;
            }
            set {
                //limit the interval to between minSpeed (100) and maxSpeed (1000).
                value = (value > MaxSpeed ? MaxSpeed : value) < MinSpeed ? MinSpeed : value;
                Settings.SetValue("interval", value);
                Timer.Interval = value;
                IntervalChanged?.Invoke(value);
            }
        }

        public static int RandomSeed {
            get {
                if (!Settings.GetValue("seed", out int val)) {
                    Settings.SetValue("seed", val);
                }
                return val;
            }
            set { Settings.SetValue("seed", value); }
        }

        public static bool DisplayHUD {
            get { return Settings.GetValue("HUD", out bool HUD) == false ? true : HUD; }
            set { Settings.SetValue("HUD", value); Universe.DrawUniverse(); }
        }

        public static bool DisplayGrid {
            get { return Settings.GetValue("Grid", out bool grid) == false ? true : grid; }
            set { Settings.SetValue("Grid", value); Universe.DrawUniverse(); }
        }

        public static bool DisplayCounts {
            get { return Settings.GetValue("Counts", out bool counts) == false ? true : counts; }
            set { Settings.SetValue("Counts", value); Universe.DrawUniverse(); }
        }

        public static void ResetUniverse() {
            Universe = new Universe();
            Size uSize = Universe.Size;
            bool widthed = Settings.GetValue("width", out int width);
            bool heighted = Settings.GetValue("height", out int height);
            UniverseSize = (widthed && heighted) ? new Size(width, height) :
                 new Size(Universe.Width, Universe.Height);
        }

    }
}
