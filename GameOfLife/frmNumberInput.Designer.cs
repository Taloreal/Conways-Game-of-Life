
namespace GameOfLife
{
    partial class frmNumberInput
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
            this.promptLbl = new System.Windows.Forms.Label();
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.inputTbx = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.inputTbx)).BeginInit();
            this.SuspendLayout();
            // 
            // promptLbl
            // 
            this.promptLbl.AutoSize = true;
            this.promptLbl.Location = new System.Drawing.Point(12, 9);
            this.promptLbl.Name = "promptLbl";
            this.promptLbl.Size = new System.Drawing.Size(39, 13);
            this.promptLbl.TabIndex = 0;
            this.promptLbl.Text = "prompt";
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(64, 51);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(48, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Location = new System.Drawing.Point(12, 51);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(48, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // inputTbx
            // 
            this.inputTbx.Location = new System.Drawing.Point(12, 25);
            this.inputTbx.Maximum = new decimal(new int[] {
            2000000000,
            0,
            0,
            0});
            this.inputTbx.Minimum = new decimal(new int[] {
            2000000000,
            0,
            0,
            -2147483648});
            this.inputTbx.Name = "inputTbx";
            this.inputTbx.Size = new System.Drawing.Size(100, 20);
            this.inputTbx.TabIndex = 4;
            // 
            // frmNumberInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(129, 88);
            this.ControlBox = false;
            this.Controls.Add(this.inputTbx);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Controls.Add(this.promptLbl);
            this.MaximumSize = new System.Drawing.Size(145, 127);
            this.MinimumSize = new System.Drawing.Size(145, 127);
            this.Name = "frmNumberInput";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "frmNumberInput";
            ((System.ComponentModel.ISupportInitialize)(this.inputTbx)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label promptLbl;
        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.NumericUpDown inputTbx;
    }
}