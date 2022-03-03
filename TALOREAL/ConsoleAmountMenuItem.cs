using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TALOREAL {

    public class ConsoleAmountMenuItem : ConsoleMenuItem {

        public int Minimum { get; private set; } = 0;

        public int Maximum { get; private set; } = 10;

        private int _Value = 0;
        public int Value { 
            get { return _Value; }
            set {
                if (value > Maximum) { value = Maximum; }
                if (value < Minimum) { value = Minimum; }
                _Value = value;
            }
        }

        public ConsoleAmountMenuItem(string text) : base(text) { }

        public ConsoleAmountMenuItem SetValidRange(int min, int max, int defaultValue = 0) {
            if (min > max) {
                Value = max;
                max = min;
                min = Value;
            }
            defaultValue = defaultValue < min ? min : defaultValue;
            defaultValue = defaultValue > max ? max : defaultValue;
            Minimum = min;
            Maximum = max;
            Value = defaultValue;
            return this;
        }

        public int GetPercentage() {
            int size = Maximum - Minimum;
            int filled = Value - Minimum;
            return (int)Math.Round((double)filled / size * 100, 0);
        }
    }
}
