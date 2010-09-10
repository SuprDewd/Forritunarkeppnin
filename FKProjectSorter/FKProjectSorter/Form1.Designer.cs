namespace FKProjectSorter
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components;

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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.txtDest = new System.Windows.Forms.TextBox();
            this.btnDone = new System.Windows.Forms.Button();
            this.udNum = new System.Windows.Forms.NumericUpDown();
            this.fbDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSource.Location = new System.Drawing.Point(12, 12);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(460, 20);
            this.txtSource.TabIndex = 0;
            this.txtSource.Text = "Click me...";
            this.txtSource.Click += new System.EventHandler(this.txtSource_Click);
            // 
            // txtDest
            // 
            this.txtDest.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDest.Location = new System.Drawing.Point(12, 38);
            this.txtDest.Name = "txtDest";
            this.txtDest.Size = new System.Drawing.Size(460, 20);
            this.txtDest.TabIndex = 1;
            this.txtDest.Text = "Click me...";
            this.txtDest.Click += new System.EventHandler(this.txtDest_Click);
            // 
            // btnDone
            // 
            this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDone.Location = new System.Drawing.Point(397, 64);
            this.btnDone.Name = "btnDone";
            this.btnDone.Size = new System.Drawing.Size(75, 23);
            this.btnDone.TabIndex = 3;
            this.btnDone.Text = "Done";
            this.btnDone.UseVisualStyleBackColor = true;
            this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
            // 
            // udNum
            // 
            this.udNum.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.udNum.Location = new System.Drawing.Point(336, 66);
            this.udNum.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.udNum.Name = "udNum";
            this.udNum.Size = new System.Drawing.Size(55, 20);
            this.udNum.TabIndex = 4;
            this.udNum.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.udNum.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 95);
            this.Controls.Add(this.udNum);
            this.Controls.Add(this.btnDone);
            this.Controls.Add(this.txtDest);
            this.Controls.Add(this.txtSource);
            this.MaximumSize = new System.Drawing.Size(500, 133);
            this.MinimumSize = new System.Drawing.Size(227, 133);
            this.Name = "Form1";
            this.Text = "FKProjectSorter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.TextBox txtDest;
        private System.Windows.Forms.Button btnDone;
        private System.Windows.Forms.NumericUpDown udNum;
        private System.Windows.Forms.FolderBrowserDialog fbDialog;
    }
}

