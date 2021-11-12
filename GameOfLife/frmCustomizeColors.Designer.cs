
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
            this.gridx10CB = new System.Windows.Forms.ComboBox();
            this.grdx10ClrLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // grdClrLbl
            // 
            this.grdClrLbl.AutoSize = true;
            this.grdClrLbl.Location = new System.Drawing.Point(12, 9);
            this.grdClrLbl.Name = "grdClrLbl";
            this.grdClrLbl.Size = new System.Drawing.Size(59, 13);
            this.grdClrLbl.TabIndex = 0;
            this.grdClrLbl.Text = "Grid Color: ";
            // 
            // activeClrLbl
            // 
            this.activeClrLbl.AutoSize = true;
            this.activeClrLbl.Location = new System.Drawing.Point(12, 48);
            this.activeClrLbl.Name = "activeClrLbl";
            this.activeClrLbl.Size = new System.Drawing.Size(70, 13);
            this.activeClrLbl.TabIndex = 1;
            this.activeClrLbl.Text = "Active Color: ";
            // 
            // inactiveClrLbl
            // 
            this.inactiveClrLbl.AutoSize = true;
            this.inactiveClrLbl.Location = new System.Drawing.Point(139, 49);
            this.inactiveClrLbl.Name = "inactiveClrLbl";
            this.inactiveClrLbl.Size = new System.Drawing.Size(78, 13);
            this.inactiveClrLbl.TabIndex = 2;
            this.inactiveClrLbl.Text = "Inactive Color: ";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(138, 91);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(58, 23);
            this.cancelBtn.TabIndex = 7;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(74, 91);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(58, 23);
            this.okBtn.TabIndex = 6;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // gridCB
            // 
            this.gridCB.FormattingEnabled = true;
            this.gridCB.Location = new System.Drawing.Point(12, 25);
            this.gridCB.Name = "gridCB";
            this.gridCB.Size = new System.Drawing.Size(120, 21);
            this.gridCB.TabIndex = 8;
            this.gridCB.SelectedIndexChanged += new System.EventHandler(this.gridDUD_SelectedItemChanged);
            // 
            // activeCB
            // 
            this.activeCB.FormattingEnabled = true;
            this.activeCB.Location = new System.Drawing.Point(12, 64);
            this.activeCB.Name = "activeCB";
            this.activeCB.Size = new System.Drawing.Size(120, 21);
            this.activeCB.TabIndex = 9;
            this.activeCB.SelectedIndexChanged += new System.EventHandler(this.activeDUD_SelectedItemChanged);
            // 
            // inactiveCB
            // 
            this.inactiveCB.FormattingEnabled = true;
            this.inactiveCB.Location = new System.Drawing.Point(139, 64);
            this.inactiveCB.Name = "inactiveCB";
            this.inactiveCB.Size = new System.Drawing.Size(120, 21);
            this.inactiveCB.TabIndex = 10;
            this.inactiveCB.SelectedIndexChanged += new System.EventHandler(this.inactiveDUD_SelectedItemChanged);
            // 
            // gridx10CB
            // 
            this.gridx10CB.FormattingEnabled = true;
            this.gridx10CB.Location = new System.Drawing.Point(139, 25);
            this.gridx10CB.Name = "gridx10CB";
            this.gridx10CB.Size = new System.Drawing.Size(120, 21);
            this.gridx10CB.TabIndex = 12;
            this.gridx10CB.SelectedIndexChanged += new System.EventHandler(this.gridx10DUD_SelectedItemChanged);
            // 
            // grdx10ClrLbl
            // 
            this.grdx10ClrLbl.AutoSize = true;
            this.grdx10ClrLbl.Location = new System.Drawing.Point(139, 9);
            this.grdx10ClrLbl.Name = "grdx10ClrLbl";
            this.grdx10ClrLbl.Size = new System.Drawing.Size(79, 13);
            this.grdx10ClrLbl.TabIndex = 11;
            this.grdx10ClrLbl.Text = "Grid x10 Color: ";
            // 
            // frmCustomizeColors
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(272, 122);
            this.ControlBox = false;
            this.Controls.Add(this.gridx10CB);
            this.Controls.Add(this.grdx10ClrLbl);
            this.Controls.Add(this.inactiveCB);
            this.Controls.Add(this.activeCB);
            this.Controls.Add(this.gridCB);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.inactiveClrLbl);
            this.Controls.Add(this.activeClrLbl);
            this.Controls.Add(this.grdClrLbl);
            this.MaximumSize = new System.Drawing.Size(288, 161);
            this.MinimumSize = new System.Drawing.Size(288, 161);
            this.Name = "frmCustomizeColors";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
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
        private System.Windows.Forms.ComboBox gridx10CB;
        private System.Windows.Forms.Label grdx10ClrLbl;
    }
}