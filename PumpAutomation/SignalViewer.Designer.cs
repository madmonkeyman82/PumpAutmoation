namespace PumpAutomation
{
    partial class SignalViewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignalViewer));
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.txt_pls_partical_ma = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_MbSpeed = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tabC_SigViewer = new System.Windows.Forms.TabControl();
            this.tabPContSens = new System.Windows.Forms.TabPage();
            this.tabPCore = new System.Windows.Forms.TabPage();
            this.tabP_Coils = new System.Windows.Forms.TabPage();
            this.dataGridViewCoils = new System.Windows.Forms.DataGridView();
            this.Column_Coil = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column_Coil_status = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox6.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabC_SigViewer.SuspendLayout();
            this.tabPContSens.SuspendLayout();
            this.tabPCore.SuspendLayout();
            this.tabP_Coils.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoils)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox6.Controls.Add(this.txt_pls_partical_ma);
            this.groupBox6.Controls.Add(this.label1);
            resources.ApplyResources(this.groupBox6, "groupBox6");
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.TabStop = false;
            // 
            // txt_pls_partical_ma
            // 
            resources.ApplyResources(this.txt_pls_partical_ma, "txt_pls_partical_ma");
            this.txt_pls_partical_ma.Name = "txt_pls_partical_ma";
            this.txt_pls_partical_ma.ReadOnly = true;
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txt_MbSpeed);
            this.groupBox1.Controls.Add(this.label2);
            resources.ApplyResources(this.groupBox1, "groupBox1");
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.TabStop = false;
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // txt_MbSpeed
            // 
            resources.ApplyResources(this.txt_MbSpeed, "txt_MbSpeed");
            this.txt_MbSpeed.Name = "txt_MbSpeed";
            this.txt_MbSpeed.ReadOnly = true;
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // tabC_SigViewer
            // 
            this.tabC_SigViewer.Controls.Add(this.tabPContSens);
            this.tabC_SigViewer.Controls.Add(this.tabPCore);
            this.tabC_SigViewer.Controls.Add(this.tabP_Coils);
            resources.ApplyResources(this.tabC_SigViewer, "tabC_SigViewer");
            this.tabC_SigViewer.Name = "tabC_SigViewer";
            this.tabC_SigViewer.SelectedIndex = 0;
            // 
            // tabPContSens
            // 
            this.tabPContSens.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPContSens.Controls.Add(this.groupBox6);
            resources.ApplyResources(this.tabPContSens, "tabPContSens");
            this.tabPContSens.Name = "tabPContSens";
            // 
            // tabPCore
            // 
            this.tabPCore.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabPCore.Controls.Add(this.groupBox1);
            resources.ApplyResources(this.tabPCore, "tabPCore");
            this.tabPCore.Name = "tabPCore";
            // 
            // tabP_Coils
            // 
            this.tabP_Coils.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.tabP_Coils.Controls.Add(this.dataGridViewCoils);
            resources.ApplyResources(this.tabP_Coils, "tabP_Coils");
            this.tabP_Coils.Name = "tabP_Coils";
            // 
            // dataGridViewCoils
            // 
            this.dataGridViewCoils.AllowUserToAddRows = false;
            this.dataGridViewCoils.AllowUserToDeleteRows = false;
            this.dataGridViewCoils.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCoils.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column_Coil,
            this.Column_Coil_status});
            resources.ApplyResources(this.dataGridViewCoils, "dataGridViewCoils");
            this.dataGridViewCoils.Name = "dataGridViewCoils";
            this.dataGridViewCoils.ReadOnly = true;
            // 
            // Column_Coil
            // 
            resources.ApplyResources(this.Column_Coil, "Column_Coil");
            this.Column_Coil.Name = "Column_Coil";
            this.Column_Coil.ReadOnly = true;
            // 
            // Column_Coil_status
            // 
            resources.ApplyResources(this.Column_Coil_status, "Column_Coil_status");
            this.Column_Coil_status.Name = "Column_Coil_status";
            this.Column_Coil_status.ReadOnly = true;
            // 
            // SignalViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.Controls.Add(this.tabC_SigViewer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignalViewer";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.TopMost = true;
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabC_SigViewer.ResumeLayout(false);
            this.tabPContSens.ResumeLayout(false);
            this.tabPCore.ResumeLayout(false);
            this.tabP_Coils.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCoils)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TextBox txt_pls_partical_ma;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_MbSpeed;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabControl tabC_SigViewer;
        private System.Windows.Forms.TabPage tabPContSens;
        private System.Windows.Forms.TabPage tabPCore;
        private System.Windows.Forms.TabPage tabP_Coils;
        private System.Windows.Forms.DataGridView dataGridViewCoils;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Coil;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column_Coil_status;
    }
}