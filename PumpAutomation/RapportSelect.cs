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
    public partial class RapportSelect : Form
    {
        #region contructor

         Rapport _Rapport;

         LogDataSet LogDataSet;
         LogDataSetTableAdapters.LoggingTableAdapter LoggingTableAdapter;

        public RapportSelect(Rapport _Rapport_)
        {
            InitializeComponent();

            this._Rapport = _Rapport_;
            _Rapport.TopMost = false;
            this.TopMost = true;
            DataSet myDataSet = new DataSet();
            

            this.LogDataSet = new PumpAutomation.LogDataSet();
            //this.LoggingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoggingTableAdapter = new PumpAutomation.LogDataSetTableAdapters.LoggingTableAdapter();
            this.LoggingTableAdapter.ClearBeforeFill = true;

            cb_Costumer.SelectedIndexChanged += cb_Costumer_SelectedIndexChanged;
        }

            #endregion

        #region Click handles
        
        void btn_cancel_Click(object sender, EventArgs e)
        {
            _Rapport.CloseRapportForm();
            this.Hide();
        }

        void btn_Ok_Click(object sender, EventArgs e)
        {

            _Rapport.CreateRepport(Convert.ToInt32(cb_SessionId.Text));
            _Rapport.Show();
            _Rapport.TopMost = true;
            this.TopMost = false;
            this.Hide();
        }

        #endregion

        #region FormLoad

        void RapportSelect_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'LogDataSet.Logging' table. You can move, or remove it, as needed.

            this.LoggingTableAdapter.Fill(this.LogDataSet.Logging);


            foreach (DataTable table in LogDataSet.Tables)
            {

                foreach (DataRow dr in table.Rows)
                {
                    string test = dr["Costumer"].ToString();

                    if (!cb_Costumer.Items.Contains(test))
                    {
                        cb_Costumer.Items.Add(test);
                    }

                }
            }

            if (cb_Costumer.Items.Count > 0)
            {
                cb_Costumer.SelectedItem = 0;
                cb_Costumer.Update();
            }


        }       

        #endregion

        #region Combobox events

        void cb_Costumer_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.LoggingTableAdapter.FillBy1(this.LogDataSet.Logging, cb_Costumer.Text);

            foreach (DataTable table in LogDataSet.Tables)
            {

                foreach (DataRow dr in table.Rows)
                {
                    string test = dr["SessionId"].ToString();

                    if (!cb_SessionId.Items.Contains(test))
                    {
                        cb_SessionId.Items.Add(test);
                    }

                }
            }

            if (cb_SessionId.Items.Count > 0)
            {
                cb_SessionId.SelectedItem = 0;
                cb_SessionId.Update();
            }
        }
   
        #endregion
    }
}
