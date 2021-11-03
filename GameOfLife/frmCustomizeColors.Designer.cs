
namespace GameOfLife
{
    partial class frmCustomizeColors
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grdClrLbl = new System.Windows.Forms.Label();
            this.activeClrLbl = new System.Windows.Forms.Label();
            this.inactiveClrLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.gridCB = new System.Windows.Forms.ComboBox();
            this.activeCB = new System.Windows.Forms.ComboBox();
            this.inactiveCB = new System.Windows.Forms.ComboBox();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.SuspendLayout();
            // 
            // grdClrLbl
            // 
            this.grdClrLbl.AutoSize = true;
            this.grdClrLbl.Location = new System.Drawing.Point(16, 11);
            this.grdClrLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.grdClrLbl.Name = "grdClrLbl";
            this.grdClrLbl.Size = new System.Drawing.Size(80, 17);
            this.grdClrLbl.TabIndex = 0;
            this.grdClrLbl.Text = "Grid Color: ";
            // 
            // activeClrLbl
            // 
            this.activeClrLbl.AutoSize = true;
            this.activeClrLbl.Location = new System.Drawing.Point(16, 59);
            this.activeClrLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.activeClrLbl.Name = "activeClrLbl";
            this.activeClrLbl.Size = new System.Drawing.Size(91, 17);
            this.activeClrLbl.TabIndex = 1;
            this.activeClrLbl.Text = "Active Color: ";
            // 
            // inactiveClrLbl
            // 
            this.inactiveClrLbl.AutoSize = true;
            this.inactiveClrLbl.Location = new System.Drawing.Point(16, 107);
            this.inactiveClrLbl.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.inactiveClrLbl.Name = "inactiveClrLbl";
            this.inactiveClrLbl.Size = new System.Drawing.Size(101, 17);
            this.inactiveClrLbl.TabIndex = 2;
            this.inactiveClrLbl.Text = "Inactive Color: ";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(99, 159);
            this.cancelBtn.Margin = new System.Windows.Forms.Padding(4);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(77, 28);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(16, 159);
            this.okBtn.Margin = new System.Windows.Forms.Padding(4);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(77, 28);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // gridCB
            // 
            this.gridCB.FormattingEnabled = true;
            this.gridCB.Location = new System.Drawing.Point(16, 31);
            this.gridCB.Margin = new System.Windows.Forms.Padding(4);
            this.gridCB.Name = "gridCB";
            this.gridCB.Size = new System.Drawing.Size(159, 24);
            this.gridCB.TabIndex = 8;
            this.gridCB.SelectedIndexChanged += new System.EventHandler(this.gridDUD_SelectedItemChanged);
            // 
            // activeCB
            // 
            this.activeCB.FormattingEnabled = true;
            this.activeCB.Location = new System.Drawing.Point(16, 79);
            this.activeCB.Margin = new System.Windows.Forms.Padding(4);
            this.activeCB.Name = "activeCB";
            this.activeCB.Size = new System.Drawing.Size(159, 24);
            this.activeCB.TabIndex = 9;
            this.activeCB.SelectedIndexChanged += new System.EventHandler(this.activeDUD_SelectedItemChanged);
            // 
            // inactiveCB
            // 
            this.inactiveCB.FormattingEnabled = true;
            this.inactiveCB.Location = new System.Drawing.Point(16, 126);
            this.inactiveCB.Margin = new System.Windows.Forms.Padding(4);
            this.inactiveCB.Name = "inactiveCB";
            this.inactiveCB.Size = new System.Drawing.Size(159, 24);
            this.inactiveCB.TabIndex = 10;
            this.inactiveCB.SelectedIndexChanged += new System.EventHandler(this.inactiveDUD_SelectedItemChanged);
            // 
            // frmCustomizeColors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(189, 199);
            this.ControlBox = false;
            this.Controls.Add(this.inactiveCB);
            this.Controls.Add(this.activeCB);
            this.Controls.Add(this.gridCB);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.inactiveClrLbl);
            this.Controls.Add(this.activeClrLbl);
            this.Controls.Add(this.grdClrLbl);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "frmCustomizeColors";
            this.Text = "Change Colors";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label grdClrLbl;
        private System.Windows.Forms.Label activeClrLbl;
        private System.Windows.Forms.Label inactiveClrLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.ComboBox gridCB;
        private System.Windows.Forms.ComboBox activeCB;
        private System.Windows.Forms.ComboBox inactiveCB;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}