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

    public partial class frmCustomizeColors : Form {

        public KnownColor GridColor { get; private set; }
        public KnownColor ActiveColor { get; private set; }
        public KnownColor InactiveColor { get; private set; }


        public frmCustomizeColors() {
            InitializeComponent();
            GenerateColors();
        }

        public void ChooseColor(KnownColor grid, KnownColor act, KnownColor inact) {
            GridColor = grid;
            ActiveColor = act;
            InactiveColor = inact;
            gridCB.SelectedIndex = gridCB.Items.IndexOf(grid.ToString());
            activeCB.SelectedIndex = activeCB.Items.IndexOf(act.ToString());
            inactiveCB.SelectedIndex = inactiveCB.Items.IndexOf(inact.ToString());
            this.ShowDialog();
        }

        private void GenerateColors() {
            List<string> clrs = new List<string>();
            foreach (KnownColor clr in Enum.GetValues(typeof(KnownColor))) {
                if (clr == KnownColor.Transparent) { continue; }
                clrs.Add(clr.ToString());
            }
            gridCB.Items.AddRange(clrs.ToArray());
            activeCB.Items.AddRange(clrs.ToArray());
            inactiveCB.Items.AddRange(clrs.ToArray());
        }

        private KnownColor StringToKnownColor(string str, KnownColor defaulted) {
            foreach (KnownColor clr in Enum.GetValues(typeof(KnownColor))) {
                if (clr.ToString() == str) { return clr; }
            }
            return defaulted;
        }

        private void okBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        private void gridDUD_SelectedItemChanged(object sender, EventArgs e) {
            GridColor = StringToKnownColor((string)gridCB.SelectedItem, GridColor);
        }

        private void activeDUD_SelectedItemChanged(object sender, EventArgs e) {
            ActiveColor = StringToKnownColor((string)activeCB.SelectedItem, ActiveColor);
        }

        private void inactiveDUD_SelectedItemChanged(object sender, EventArgs e) {
            InactiveColor = StringToKnownColor((string)
                inactiveCB.SelectedItem, InactiveColor);
        }
    }
}
