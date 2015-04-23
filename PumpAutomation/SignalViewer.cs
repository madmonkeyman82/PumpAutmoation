using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PumpAutomation
{
    public partial class SignalViewer : Form
    {

        #region GUI Delegate Declarations
        //public delegate void GUIDelegate(string paramString, DateTime datetime);
        public delegate void GUIDelegate(Control control, string text );
        public delegate void GUIDelegateCoils(BitArray coils);
        #endregion

        private Core SingletonPls = Core.Instance;
        // Logger Variable
        private Logger SingletonLogger = Logger.Instance;
        private Timer timer = new Timer();

        public SignalViewer()
        {
            InitializeComponent();
            dataGridViewCoils.Rows.Add(1024);
            SetupTimer();
           
        }

        ~SignalViewer()
        {
            
            timer.Stop();
        }

        private void SetupTimer()
        {
            timer.Interval = 100;
            timer.Tick += timer_Tick;
            timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            if (tabC_SigViewer.SelectedTab == tabC_SigViewer.TabPages["tabPContSens"])
            {
                //Contamination sensor mA
                double mA = (double)SingletonPls._PlcVariables.MBConSensmA / 256;
                DoGUIUpdate(txt_pls_partical_ma, Math.Round(mA, 2).ToString());
            }

            else if (tabC_SigViewer.SelectedTab == tabC_SigViewer.TabPages["tabPCore"])
            {
                // Core -> Modbus -> thred preformancespeed
                DoGUIUpdate(txt_MbSpeed, SingletonPls.ModbusPreformance.ToString());
            }

            else if (tabC_SigViewer.SelectedTab == tabC_SigViewer.TabPages["tabP_Coils"])
            {
                DoGUIUpdateCoils(SingletonPls.ModbusCoilArray);
            }

        }

        #region Delegate Functions

        public void DoGUIUpdate(Control control, string text)
        {
            if (this.InvokeRequired)
            {
                GUIDelegate delegateMethod = new GUIDelegate(this.DoGUIUpdate);
                this.Invoke(delegateMethod, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        public void DoGUIUpdateCoils(BitArray coils)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateCoils delegateMethod = new GUIDelegateCoils(this.DoGUIUpdateCoils);
                this.Invoke(delegateMethod, new object[] { coils });
            }
            else
            {
                int l = coils.Length;
                for (int i = 0; i < l; i++)
                {
                    //string[] row = new string[] { i.ToString(), coils[i].ToString() };
                    //dataGridViewCoils.Rows.Add(row);
 
                        dataGridViewCoils.Rows[i].SetValues(i.ToString(), coils[i].ToString());          
                }
            }
        }

        #endregion

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            this.Hide();
            e.Cancel = true;

            return;
        }
    }
}
