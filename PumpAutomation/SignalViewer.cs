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
    public partial class SignalViewer : Form
    {

        #region GUI Delegate Declarations
        //public delegate void GUIDelegate(string paramString, DateTime datetime);
        public delegate void GUIDelegate(Control control, string text );
        #endregion

        private Core SingletonPls = Core.Instance;
        // Logger Variable
        private Logger SingletonLogger = Logger.Instance;
        private Timer timer = new Timer();

        public SignalViewer()
        {
            InitializeComponent();
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
            double mA = (double)SingletonPls._PlcVariables.MBConSensmA / 256;
            DoGUIUpdate(txt_pls_partical_ma, Math.Round(mA, 2).ToString());
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
