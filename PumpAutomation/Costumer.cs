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
    public partial class Costumer : Form
    {

        #region Variables

        Main _Main;
        const string info = "Fyll inn info here....";

        #endregion

        #region Constructor


        public Costumer(Main _Main)
        {
            InitializeComponent();
            this._Main = _Main;
            this.TopMost = true;
            this.KeyDown += Costumer_KeyDown;
            txt_Costumer.GotFocus += txt_Costumer_GotFocus;
            txt_Costumer.Click += txt_Costumer_Click;
            
        }

        void txt_Costumer_Click(object sender, EventArgs e)
        {
            txt_Costumer.SelectAll();
        }

        void Costumer_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            }
        }

        void txt_Costumer_GotFocus(object sender, EventArgs e)
        {
            
            txt_Costumer.Select(0, txt_Costumer.Text.Length);
        }

        #endregion

        #region Click Handles


        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                saveCostumer();
            }
            else if (e.KeyCode == Keys.Escape)
            {
                this.Hide();
            } 
   
        }


        private void btn_save_Click(object sender, EventArgs e)
        {

            saveCostumer();
        }

        #endregion

        #region Privates
        
        private void saveCostumer()
        {
            if (txt_Costumer.TextLength != 0 && !txt_Costumer.Text.Contains(info))
            {
                _Main.SetCostumerToDB(txt_Costumer.Text);
                _Main.DataBaseLogger.SetSessionId(true);
                this.Hide();
            }
            else
            {
                txt_Costumer.Text = info;
            }
        }

        #endregion
    }
}
