using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumpAutomation
{
    public partial class Rapport : Form
    {

        public Rapport()
        {
            InitializeComponent();
        }

        private void Rapport_Load(object sender, EventArgs e)
        {
            RapportSelect FormRapportSelect = new RapportSelect(this);
            FormRapportSelect.Show();
        }

        public void CreateRepport(int SessionId)
        {
            // TODO: This line of code loads data into the 'LogDataSet.Logging' table. You can move, or remove it, as needed.
            
            this.LoggingTableAdapter.FillBy(this.LogDataSet.Logging, SessionId);

            this.reportViewer1.RefreshReport();
        }

        public void CloseRapportForm()
        {
            this.Close();
        }
    }
}
