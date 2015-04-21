namespace PumpAutomation
{
    partial class LoggViewer
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
            this.rtxt_plslogger = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // rtxt_plslogger
            // 
            this.rtxt_plslogger.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.rtxt_plslogger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rtxt_plslogger.Location = new System.Drawing.Point(0, 0);
            this.rtxt_plslogger.Name = "rtxt_plslogger";
            this.rtxt_plslogger.ReadOnly = true;
            this.rtxt_plslogger.Size = new System.Drawing.Size(741, 382);
            this.rtxt_plslogger.TabIndex = 0;
            this.rtxt_plslogger.Text = "";
            // 
            // LoggViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(741, 382);
            this.Controls.Add(this.rtxt_plslogger);
            this.Location = new System.Drawing.Point(700, 600);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoggViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Logger Viewer";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtxt_plslogger;
    }
}