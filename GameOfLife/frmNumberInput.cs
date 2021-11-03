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

    public partial class frmNumberInput : Form {

        /// <summary>
        /// The user's input.
        /// </summary>
        public int Input { get; private set; }

        private bool OnlyPositives = true;

        /// <summary>
        /// Creates a new window with which to request a number from the user.
        /// </summary>
        /// <param name="title">The title of the window.</param>
        /// <param name="prompt">The prompt for the user.</param>
        /// <param name="onlyPositives">Can the user enter only positive numbers?</param>
        public frmNumberInput(string title, string prompt, bool onlyPositives = true) {
            OnlyPositives = onlyPositives;
            InitializeComponent();
            this.Text = title;
            this.promptLbl.Text = prompt;
            inputTbx.Minimum = onlyPositives ? 1 : inputTbx.Minimum;
        }

        /// <summary>
        /// Closes the dialogue box with the OK state.
        /// </summary>
        private void okBtn_Click(object sender, EventArgs e) {
            int input = (int)inputTbx.Value;
            if (input < 1 && OnlyPositives) {
                MessageBox.Show("Must enter a positive integer!");
                return;
            }
            this.DialogResult = DialogResult.OK;
            Input = input;
            this.Close();
        }

        /// <summary>
        /// Closes the dialogue box without doing anything.
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
