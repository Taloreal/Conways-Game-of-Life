using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GameOfLife
{
    public partial class frmNumberInput : Form
    {

        public int Input { get; private set; }

        private bool OnlyPositives = true;

        public frmNumberInput(string title, string prompt, bool onlyPositives = true)
        {
            OnlyPositives = onlyPositives;
            InitializeComponent();
            this.Text = title;
            this.promptLbl.Text = prompt;
        }

        private void okBtn_Click(object sender, EventArgs e) {
            if (!int.TryParse(inputTbx.Text, out int input)) {
                MessageBox.Show("Must enter an integer!");
                return;
            }
            if (input < 1 && OnlyPositives) {
                MessageBox.Show("Must enter a positive integer!");
                return;
            }
            this.DialogResult = DialogResult.OK;
            Input = input;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
