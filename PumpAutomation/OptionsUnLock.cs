    using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace PumpAutomation
{
    public partial class OptionsUnLock : Form
    {
        Options _Options;
        int count = 1;

        public OptionsUnLock(Options _Options_)
        {
            InitializeComponent();
            this._Options = _Options_;
            _Options.TopMost = false;
            this.TopMost = true;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter )
           {
              
                if (_Options.UnlockCode(textBox1.Text))
                {
                    lbl_staus.Text = "Correct";
                    _Options.TopMost = true;
                    this.TopMost = false;
                    this.Close();       
                }
                 if (count > 2)
                 {
                     _Options.TopMost = true;
                     this.TopMost = false;
                     this.Close();
                 }
                 count++;
                 textBox1.Clear();
                 lbl_staus.Text = "Wrong";
           }          
        }


    }
}
