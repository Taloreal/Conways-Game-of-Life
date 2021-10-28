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

    public partial class frmGetNewSize : Form {

        public int NewWidth { get; private set; }
        public int NewHeight { get; private set; }
        public bool Canceled { get; private set; }

        public frmGetNewSize() {
            InitializeComponent();
        }

        private void okBtn_Click(object sender, EventArgs e) {
            bool widthed = int.TryParse(widthTbx.Text, out int width);
            bool heighted = int.TryParse(heightTbx.Text, out int height);
            if (widthed == false || heighted == false || width < 1 || height < 1) {
                MessageBox.Show("Must enter positive integers!");
                return;
            }
            NewWidth = width;
            NewHeight = height;
            Canceled = false;
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e) {
            Canceled = true;
            this.Close();
        }
    }
}
