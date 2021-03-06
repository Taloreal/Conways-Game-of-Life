
namespace GameOfLife
{
    partial class frmGetNewSize
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
            this.okBtn = new System.Windows.Forms.Button();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.widthLbl = new System.Windows.Forms.Label();
            this.heightLbl = new System.Windows.Forms.Label();
            this.widthTbx = new System.Windows.Forms.NumericUpDown();
            this.heightTbx = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.widthTbx)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTbx)).BeginInit();
            this.SuspendLayout();
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 51);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 0;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(93, 51);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 1;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // widthLbl
            // 
            this.widthLbl.AutoSize = true;
            this.widthLbl.Location = new System.Drawing.Point(12, 9);
            this.widthLbl.Name = "widthLbl";
            this.widthLbl.Size = new System.Drawing.Size(38, 13);
            this.widthLbl.TabIndex = 2;
            this.widthLbl.Text = "Width:";
            // 
            // heightLbl
            // 
            this.heightLbl.AutoSize = true;
            this.heightLbl.Location = new System.Drawing.Point(90, 9);
            this.heightLbl.Name = "heightLbl";
            this.heightLbl.Size = new System.Drawing.Size(41, 13);
            this.heightLbl.TabIndex = 4;
            this.heightLbl.Text = "Height:";
            // 
            // widthTbx
            // 
            this.widthTbx.Location = new System.Drawing.Point(12, 25);
            this.widthTbx.Margin = new System.Windows.Forms.Padding(2);
            this.widthTbx.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.widthTbx.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.widthTbx.Name = "widthTbx";
            this.widthTbx.Size = new System.Drawing.Size(75, 20);
            this.widthTbx.TabIndex = 6;
            this.widthTbx.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // heightTbx
            // 
            this.heightTbx.Location = new System.Drawing.Point(93, 25);
            this.heightTbx.Margin = new System.Windows.Forms.Padding(2);
            this.heightTbx.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.heightTbx.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.heightTbx.Name = "heightTbx";
            this.heightTbx.Size = new System.Drawing.Size(75, 20);
            this.heightTbx.TabIndex = 7;
            this.heightTbx.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // frmGetNewSize
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(180, 83);
            this.ControlBox = false;
            this.Controls.Add(this.heightTbx);
            this.Controls.Add(this.widthTbx);
            this.Controls.Add(this.heightLbl);
            this.Controls.Add(this.widthLbl);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.MaximumSize = new System.Drawing.Size(196, 122);
            this.MinimumSize = new System.Drawing.Size(196, 122);
            this.Name = "frmGetNewSize";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Resize Universe";
            ((System.ComponentModel.ISupportInitialize)(this.widthTbx)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.heightTbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label widthLbl;
        private System.Windows.Forms.Label heightLbl;
        private System.Windows.Forms.NumericUpDown widthTbx;
        private System.Windows.Forms.NumericUpDown heightTbx;
    }
}