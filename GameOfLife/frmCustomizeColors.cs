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

        /// <summary>
        /// The grid's color.
        /// </summary>
        public KnownColor GridColor { get; private set; }

        /// <summary>
        /// The grid x10's color.
        /// </summary>
        public KnownColor GridX10Color { get; private set; }

        /// <summary>
        /// The active cells' color.
        /// </summary>
        public KnownColor ActiveColor { get; private set; }

        /// <summary>
        /// The inactive cells' color.
        /// </summary>
        public KnownColor InactiveColor { get; private set; }

        /// <summary>
        /// Creates a new dialogue box for choosing colors.
        /// </summary>
        public frmCustomizeColors() {
            InitializeComponent();
            GenerateColors();
        }

        /// <summary>
        /// Set's the combo boxes to current colors and shows the dialogue box.
        /// </summary>
        /// <param name="grid">The grid color to show.</param>
        /// <param name="act">The active color to show.</param>
        /// <param name="inact">The inactive color to show.</param>
        public void ChooseColor(KnownColor grid, KnownColor gridx10, KnownColor act, KnownColor inact) {
            GridColor = grid;
            GridX10Color = gridx10;
            ActiveColor = act;
            InactiveColor = inact;
            gridCB.SelectedIndex = gridCB.Items.IndexOf(grid.ToString());
            gridx10CB.SelectedIndex = gridx10CB.Items.IndexOf(gridx10.ToString());
            activeCB.SelectedIndex = activeCB.Items.IndexOf(act.ToString());
            inactiveCB.SelectedIndex = inactiveCB.Items.IndexOf(inact.ToString());
            this.ShowDialog();
        }

        /// <summary>
        /// Generates all of the known colors and adds them to the combo boxes.
        /// </summary>
        private void GenerateColors() {
            List<string> clrs = new List<string>();
            foreach (KnownColor clr in Enum.GetValues(typeof(KnownColor))) {
                if (clr == KnownColor.Transparent) { continue; }
                clrs.Add(clr.ToString());
            }
            gridCB.Items.AddRange(clrs.ToArray());
            gridx10CB.Items.AddRange(clrs.ToArray());
            activeCB.Items.AddRange(clrs.ToArray());
            inactiveCB.Items.AddRange(clrs.ToArray());
        }

        /// <summary>
        /// Converts a string to a KnownColor.
        /// </summary>
        /// <param name="str">The string to convert.</param>
        /// <param name="defaulted">The KnownColor to default to if can't convert.</param>
        /// <returns>The KnownColor from string.</returns>
        private KnownColor StringToKnownColor(string str, KnownColor defaulted) {
            foreach (KnownColor clr in Enum.GetValues(typeof(KnownColor))) {
                if (clr.ToString() == str) { return clr; }
            }
            return defaulted;
        }

        /// <summary>
        /// Closes the dialogue box with the OK state.
        /// </summary>
        private void okBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.OK;
            this.Hide();
        }

        /// <summary>
        /// Closes the dialogue box without doing anything.
        /// </summary>
        private void cancelBtn_Click(object sender, EventArgs e) {
            this.DialogResult = DialogResult.Cancel;
            this.Hide();
        }

        /// <summary>
        /// Updates the user's choice of grid color.
        /// </summary>
        private void gridDUD_SelectedItemChanged(object sender, EventArgs e) {
            GridColor = StringToKnownColor((string)gridCB.SelectedItem, GridColor);
        }

        /// <summary>
        /// Updates the user's choice of grid x10 color.
        /// </summary>
        private void gridx10DUD_SelectedItemChanged(object sender, EventArgs e) {
            GridX10Color = StringToKnownColor((string)gridx10CB.SelectedItem, GridColor);
        }

        /// <summary>
        /// Updates the user's choice of active color.
        /// </summary>
        private void activeDUD_SelectedItemChanged(object sender, EventArgs e) {
            ActiveColor = StringToKnownColor((string)activeCB.SelectedItem, ActiveColor);
        }

        /// <summary>
        /// Updates the user's choice of inactive color.
        /// </summary>
        private void inactiveDUD_SelectedItemChanged(object sender, EventArgs e) {
            InactiveColor = StringToKnownColor((string)
                inactiveCB.SelectedItem, InactiveColor);
        }
    }
}
