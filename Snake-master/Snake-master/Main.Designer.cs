namespace Snake
{
    partial class Main
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
            this.lblmenu = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lblmenu
            // 
            this.lblmenu.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblmenu.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblmenu.Location = new System.Drawing.Point(0, 0);
            this.lblmenu.Name = "lblmenu";
            this.lblmenu.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblmenu.Size = new System.Drawing.Size(300, 200);
            this.lblmenu.TabIndex = 0;
            this.lblmenu.Text = "Snake by Joe Hunter\r\n\r\nUse the arrow keys to move \r\n\r\n\r\nPress Enter to Play";
            this.lblmenu.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblmenu.Click += new System.EventHandler(this.label1_Click);
            // 
            // Snake
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 200);
            this.Controls.Add(this.lblmenu);
            this.MaximumSize = new System.Drawing.Size(316, 239);
            this.MinimumSize = new System.Drawing.Size(316, 239);
            this.Name = "Snake";
            this.Text = "Snake";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblmenu;
    }
}

