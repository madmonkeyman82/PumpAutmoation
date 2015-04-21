namespace PumpAutomation
{
    partial class RapportSelect
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
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.cb_Costumer = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cb_SessionId = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(8, 139);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(69, 41);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(81, 139);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(69, 41);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Avbryt";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // cb_Costumer
            // 
            this.cb_Costumer.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Costumer.FormattingEnabled = true;
            this.cb_Costumer.Location = new System.Drawing.Point(12, 34);
            this.cb_Costumer.Name = "cb_Costumer";
            this.cb_Costumer.Size = new System.Drawing.Size(138, 24);
            this.cb_Costumer.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kunde";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "Sesjon";
            // 
            // cb_SessionId
            // 
            this.cb_SessionId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SessionId.FormattingEnabled = true;
            this.cb_SessionId.Location = new System.Drawing.Point(12, 95);
            this.cb_SessionId.Name = "cb_SessionId";
            this.cb_SessionId.Size = new System.Drawing.Size(138, 24);
            this.cb_SessionId.TabIndex = 4;
            // 
            // RapportSelect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(164, 198);
            this.ControlBox = false;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cb_SessionId);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cb_Costumer);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_Ok);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "RapportSelect";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Velg Kunde og  Sesjon";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.RapportSelect_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ComboBox cb_Costumer;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cb_SessionId;
    }
}