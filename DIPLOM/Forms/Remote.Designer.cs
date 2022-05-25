namespace DIPLOM
{
    partial class Remote
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.CloseRemoteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ScreenShotToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.image_remote = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_remote)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CloseRemoteToolStripMenuItem,
            this.ScreenShotToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // CloseRemoteToolStripMenuItem
            // 
            this.CloseRemoteToolStripMenuItem.Name = "CloseRemoteToolStripMenuItem";
            this.CloseRemoteToolStripMenuItem.Size = new System.Drawing.Size(185, 25);
            this.CloseRemoteToolStripMenuItem.Text = "Закрыть подключение";
            this.CloseRemoteToolStripMenuItem.Click += new System.EventHandler(this.CloseRemoteToolStripMenuItem_Click);
            // 
            // ScreenShotToolStripMenuItem
            // 
            this.ScreenShotToolStripMenuItem.Name = "ScreenShotToolStripMenuItem";
            this.ScreenShotToolStripMenuItem.Size = new System.Drawing.Size(96, 25);
            this.ScreenShotToolStripMenuItem.Text = "Скриншот";
            // 
            // image_remote
            // 
            this.image_remote.Dock = System.Windows.Forms.DockStyle.Fill;
            this.image_remote.Location = new System.Drawing.Point(0, 29);
            this.image_remote.Name = "image_remote";
            this.image_remote.Size = new System.Drawing.Size(800, 421);
            this.image_remote.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.image_remote.TabIndex = 2;
            this.image_remote.TabStop = false;
            // 
            // Remote
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.image_remote);
            this.Controls.Add(this.menuStrip1);
            this.Name = "Remote";
            this.Text = "Remote";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Remote_FormClosing);
            this.Load += new System.EventHandler(this.Remote_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.image_remote)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem CloseRemoteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ScreenShotToolStripMenuItem;
        private System.Windows.Forms.PictureBox image_remote;
    }
}