using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife {

    public partial class frmGetRuleSet : Form {

        /// <summary>
        /// Generates a new GetRuleSet dialogue box.
        /// </summary>
        public frmGetRuleSet() {
            InitializeComponent();
            GetCurrentRules();
        }

        /// <summary>
        /// Gets the current rules the universe evolves by.
        /// </summary>
        private void GetCurrentRules() {
            on1nud.Value = Config.Rules[true, 1]; off1nud.Value = Config.Rules[false, 1];
            on2nud.Value = Config.Rules[true, 2]; off2nud.Value = Config.Rules[false, 2];
            on3nud.Value = Config.Rules[true, 3]; off3nud.Value = Config.Rules[false, 3];
            on4nud.Value = Config.Rules[true, 4]; off4nud.Value = Config.Rules[false, 4];
            on5nud.Value = Config.Rules[true, 5]; off5nud.Value = Config.Rules[false, 5];
            on6nud.Value = Config.Rules[true, 6]; off6nud.Value = Config.Rules[false, 6];
            on7nud.Value = Config.Rules[true, 7]; off7nud.Value = Config.Rules[false, 7];
            on8nud.Value = Config.Rules[true, 8]; off8nud.Value = Config.Rules[false, 8];
        }

        /// <summary>
        /// Resets the ruleset selected to "Conway's Game of Life".
        /// </summary>
        private void button1_Click(object sender, EventArgs e) {
            on1nud.Value = 0; off1nud.Value = 0;
            on2nud.Value = 100; off2nud.Value = 0;
            on3nud.Value = 100; off3nud.Value = 100;
            on4nud.Value = 0; off4nud.Value = 0;
            on5nud.Value = 0; off5nud.Value = 0;
            on6nud.Value = 0; off6nud.Value = 0;
            on7nud.Value = 0; off7nud.Value = 0;
            on8nud.Value = 0; off8nud.Value = 0;
        }

        /// <summary>
        /// Closes the dialogue box without doing anything.
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Updates the universe evolution rules and closes the dialogue box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okBtn_Click(object sender, EventArgs e) {
            Config.Rules[true, 1] = (int)on1nud.Value; Config.Rules[false, 1] = (int)off1nud.Value;
            Config.Rules[true, 2] = (int)on2nud.Value; Config.Rules[false, 2] = (int)off2nud.Value;
            Config.Rules[true, 3] = (int)on3nud.Value; Config.Rules[false, 3] = (int)off3nud.Value;
            Config.Rules[true, 4] = (int)on4nud.Value; Config.Rules[false, 4] = (int)off4nud.Value;
            Config.Rules[true, 5] = (int)on5nud.Value; Config.Rules[false, 5] = (int)off5nud.Value;
            Config.Rules[true, 6] = (int)on6nud.Value; Config.Rules[false, 6] = (int)off6nud.Value;
            Config.Rules[true, 7] = (int)on7nud.Value; Config.Rules[false, 7] = (int)off7nud.Value;
            Config.Rules[true, 8] = (int)on8nud.Value; Config.Rules[false, 8] = (int)off8nud.Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
