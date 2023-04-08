namespace RiotDNS.Updater
{
    partial class RiotDNSUpdater
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
            this.sLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sLbl
            // 
            this.sLbl.AutoSize = true;
            this.sLbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.25F);
            this.sLbl.Location = new System.Drawing.Point(46, 28);
            this.sLbl.Name = "sLbl";
            this.sLbl.Size = new System.Drawing.Size(227, 26);
            this.sLbl.TabIndex = 0;
            this.sLbl.Text = "UPDATE COMPLETE";
            // 
            // RiotDNSUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(322, 88);
            this.Controls.Add(this.sLbl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "RiotDNSUpdater";
            this.Text = "RiotDNS Updater";
            this.Load += new System.EventHandler(this.RiotDNSUpdater_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label sLbl;
    }
}

