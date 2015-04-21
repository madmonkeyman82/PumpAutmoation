namespace PumpAutomation
{
    partial class Rapport
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
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.LogDataSet = new PumpAutomation.LogDataSet();
            this.LoggingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoggingTableAdapter = new PumpAutomation.LogDataSetTableAdapters.LoggingTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.LogDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.LoggingBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "PumpAutomation.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(915, 603);
            this.reportViewer1.TabIndex = 0;
            // 
            // LogDataSet
            // 
            this.LogDataSet.DataSetName = "LogDataSet";
            this.LogDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // LoggingBindingSource
            // 
            this.LoggingBindingSource.DataMember = "Logging";
            this.LoggingBindingSource.DataSource = this.LogDataSet;
            // 
            // LoggingTableAdapter
            // 
            this.LoggingTableAdapter.ClearBeforeFill = true;
            // 
            // Rapport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.ClientSize = new System.Drawing.Size(915, 603);
            this.Controls.Add(this.reportViewer1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Rapport";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Rapport";
            this.Load += new System.EventHandler(this.Rapport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.LogDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LoggingBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource LoggingBindingSource;
        private LogDataSet LogDataSet;
        private LogDataSetTableAdapters.LoggingTableAdapter LoggingTableAdapter;
    }
}