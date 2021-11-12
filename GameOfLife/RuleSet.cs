using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using TALOREAL;

namespace GameOfLife
{
    public class RuleSet {

        private static Random RNG = new Random();

        public int this[bool state, int neighbors] {
            get {
                string key = state.ToString() + neighbors;
                bool worked = Settings.GetValue(key, out int chance);
                if (worked == false || chance < 0 || chance > 100) {
                    chance = (neighbors == 3 || (state && neighbors == 2)) ? 100 : 0;
                    Settings.SetValue(key, chance);
                }
                return chance;
            }
            set {
                value = value < 0 ? 0 : value;
                value = value > 100 ? 100 : value;
                string key = state.ToString() + neighbors;
                Settings.SetValue(key, value);
            }
        }

        public bool RollTheDice(bool state, int neighbors) {
            int chance = this[state, neighbors];
            int rolled = RNG.Next(0, 100);
            return rolled < chance;
        }
    }
}
