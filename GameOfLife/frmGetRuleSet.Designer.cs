
namespace GameOfLife
{
    partial class frmGetRuleSet
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.okBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.off1nud = new System.Windows.Forms.NumericUpDown();
            this.on1nud = new System.Windows.Forms.NumericUpDown();
            this.on2nud = new System.Windows.Forms.NumericUpDown();
            this.off2nud = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.on3nud = new System.Windows.Forms.NumericUpDown();
            this.off3nud = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.on4nud = new System.Windows.Forms.NumericUpDown();
            this.off4nud = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.on5nud = new System.Windows.Forms.NumericUpDown();
            this.off5nud = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.on6nud = new System.Windows.Forms.NumericUpDown();
            this.off6nud = new System.Windows.Forms.NumericUpDown();
            this.label9 = new System.Windows.Forms.Label();
            this.on7nud = new System.Windows.Forms.NumericUpDown();
            this.off7nud = new System.Windows.Forms.NumericUpDown();
            this.label10 = new System.Windows.Forms.Label();
            this.on8nud = new System.Windows.Forms.NumericUpDown();
            this.off8nud = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.off1nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on1nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on2nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.off2nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on3nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.off3nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on4nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.off4nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on5nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.off5nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on6nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.off6nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on7nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.off7nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.on8nud)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.off8nud)).BeginInit();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cancelBtn.Location = new System.Drawing.Point(179, 275);
            this.cancelBtn.MaximumSize = new System.Drawing.Size(75, 23);
            this.cancelBtn.MinimumSize = new System.Drawing.Size(75, 23);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 3;
            this.cancelBtn.Text = "Cancel";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // okBtn
            // 
            this.okBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.okBtn.Location = new System.Drawing.Point(12, 275);
            this.okBtn.MaximumSize = new System.Drawing.Size(75, 23);
            this.okBtn.MinimumSize = new System.Drawing.Size(75, 23);
            this.okBtn.Name = "okBtn";
            this.okBtn.Size = new System.Drawing.Size(75, 23);
            this.okBtn.TabIndex = 2;
            this.okBtn.Text = "Ok";
            this.okBtn.UseVisualStyleBackColor = true;
            this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
            // 
            // label1
            // 
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 58);
            this.label1.TabIndex = 4;
            this.label1.Text = "Values are percent chances a cell will be on next generation";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(107, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "If already on";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(184, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "If already off";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "If 1 on neighbor";
            // 
            // off1nud
            // 
            this.off1nud.Location = new System.Drawing.Point(187, 70);
            this.off1nud.Name = "off1nud";
            this.off1nud.Size = new System.Drawing.Size(65, 20);
            this.off1nud.TabIndex = 9;
            this.off1nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // on1nud
            // 
            this.on1nud.Location = new System.Drawing.Point(110, 70);
            this.on1nud.Name = "on1nud";
            this.on1nud.Size = new System.Drawing.Size(65, 20);
            this.on1nud.TabIndex = 10;
            this.on1nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // on2nud
            // 
            this.on2nud.Location = new System.Drawing.Point(110, 96);
            this.on2nud.Name = "on2nud";
            this.on2nud.Size = new System.Drawing.Size(65, 20);
            this.on2nud.TabIndex = 13;
            this.on2nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.on2nud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // off2nud
            // 
            this.off2nud.Location = new System.Drawing.Point(187, 96);
            this.off2nud.Name = "off2nud";
            this.off2nud.Size = new System.Drawing.Size(65, 20);
            this.off2nud.TabIndex = 12;
            this.off2nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "If 2 on neighbors";
            // 
            // on3nud
            // 
            this.on3nud.Location = new System.Drawing.Point(110, 122);
            this.on3nud.Name = "on3nud";
            this.on3nud.Size = new System.Drawing.Size(65, 20);
            this.on3nud.TabIndex = 16;
            this.on3nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.on3nud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // off3nud
            // 
            this.off3nud.Location = new System.Drawing.Point(187, 122);
            this.off3nud.Name = "off3nud";
            this.off3nud.Size = new System.Drawing.Size(65, 20);
            this.off3nud.TabIndex = 15;
            this.off3nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.off3nud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(9, 124);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "If 3 on neighbors";
            // 
            // on4nud
            // 
            this.on4nud.Location = new System.Drawing.Point(110, 148);
            this.on4nud.Name = "on4nud";
            this.on4nud.Size = new System.Drawing.Size(65, 20);
            this.on4nud.TabIndex = 19;
            this.on4nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // off4nud
            // 
            this.off4nud.Location = new System.Drawing.Point(187, 148);
            this.off4nud.Name = "off4nud";
            this.off4nud.Size = new System.Drawing.Size(65, 20);
            this.off4nud.TabIndex = 18;
            this.off4nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(9, 150);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "If 4 on neighbors";
            // 
            // on5nud
            // 
            this.on5nud.Location = new System.Drawing.Point(110, 174);
            this.on5nud.Name = "on5nud";
            this.on5nud.Size = new System.Drawing.Size(65, 20);
            this.on5nud.TabIndex = 22;
            this.on5nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // off5nud
            // 
            this.off5nud.Location = new System.Drawing.Point(187, 174);
            this.off5nud.Name = "off5nud";
            this.off5nud.Size = new System.Drawing.Size(65, 20);
            this.off5nud.TabIndex = 21;
            this.off5nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 176);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(86, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "If 5 on neighbors";
            // 
            // on6nud
            // 
            this.on6nud.Location = new System.Drawing.Point(110, 200);
            this.on6nud.Name = "on6nud";
            this.on6nud.Size = new System.Drawing.Size(65, 20);
            this.on6nud.TabIndex = 25;
            this.on6nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // off6nud
            // 
            this.off6nud.Location = new System.Drawing.Point(187, 200);
            this.off6nud.Name = "off6nud";
            this.off6nud.Size = new System.Drawing.Size(65, 20);
            this.off6nud.TabIndex = 24;
            this.off6nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(9, 202);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "If 6 on neighbors";
            // 
            // on7nud
            // 
            this.on7nud.Location = new System.Drawing.Point(110, 226);
            this.on7nud.Name = "on7nud";
            this.on7nud.Size = new System.Drawing.Size(65, 20);
            this.on7nud.TabIndex = 28;
            this.on7nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // off7nud
            // 
            this.off7nud.Location = new System.Drawing.Point(187, 226);
            this.off7nud.Name = "off7nud";
            this.off7nud.Size = new System.Drawing.Size(65, 20);
            this.off7nud.TabIndex = 27;
            this.off7nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 228);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(86, 13);
            this.label10.TabIndex = 26;
            this.label10.Text = "If 7 on neighbors";
            // 
            // on8nud
            // 
            this.on8nud.Location = new System.Drawing.Point(110, 252);
            this.on8nud.Name = "on8nud";
            this.on8nud.Size = new System.Drawing.Size(65, 20);
            this.on8nud.TabIndex = 31;
            this.on8nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // off8nud
            // 
            this.off8nud.Location = new System.Drawing.Point(187, 252);
            this.off8nud.Name = "off8nud";
            this.off8nud.Size = new System.Drawing.Size(65, 20);
            this.off8nud.TabIndex = 30;
            this.off8nud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(9, 254);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "If 8 on neighbors";
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Location = new System.Drawing.Point(107, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(144, 45);
            this.label12.TabIndex = 32;
            this.label12.Text = "Conways Game of Life: 100% if 3, 100% if 2 and on, 0% otherwise";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(95, 275);
            this.button1.MaximumSize = new System.Drawing.Size(75, 23);
            this.button1.MinimumSize = new System.Drawing.Size(75, 23);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 33;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmGetRuleSet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(263, 310);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.on8nud);
            this.Controls.Add(this.off8nud);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.on7nud);
            this.Controls.Add(this.off7nud);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.on6nud);
            this.Controls.Add(this.off6nud);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.on5nud);
            this.Controls.Add(this.off5nud);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.on4nud);
            this.Controls.Add(this.off4nud);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.on3nud);
            this.Controls.Add(this.off3nud);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.on2nud);
            this.Controls.Add(this.off2nud);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.on1nud);
            this.Controls.Add(this.off1nud);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.okBtn);
            this.Name = "frmGetRuleSet";
            this.Text = "Change Rule Set";
            ((System.ComponentModel.ISupportInitialize)(this.off1nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on1nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on2nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.off2nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on3nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.off3nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on4nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.off4nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on5nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.off5nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on6nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.off6nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on7nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.off7nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.on8nud)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.off8nud)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Button okBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown off1nud;
        private System.Windows.Forms.NumericUpDown on1nud;
        private System.Windows.Forms.NumericUpDown on2nud;
        private System.Windows.Forms.NumericUpDown off2nud;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown on3nud;
        private System.Windows.Forms.NumericUpDown off3nud;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown on4nud;
        private System.Windows.Forms.NumericUpDown off4nud;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown on5nud;
        private System.Windows.Forms.NumericUpDown off5nud;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown on6nud;
        private System.Windows.Forms.NumericUpDown off6nud;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.NumericUpDown on7nud;
        private System.Windows.Forms.NumericUpDown off7nud;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.NumericUpDown on8nud;
        private System.Windows.Forms.NumericUpDown off8nud;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button button1;
    }
}