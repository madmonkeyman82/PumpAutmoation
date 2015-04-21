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
    public partial class LoggViewer : Form
    {

        #region GUI Delegate Declarations
        //public delegate void GUIDelegate(string paramString, DateTime datetime);
        public delegate void GUIDelegate(MessageToLog logitem);
        #endregion


        private Core SingletonPls = Core.Instance;
        // Logger Variable
        private Logger SingletonLogger = Logger.Instance;
        private Timer timer = new Timer();
        private List<MessageToLog> logg = new List<MessageToLog>();
        private int CurrentLogLine = 0;


        public LoggViewer()
        {
            InitializeComponent();
            SetupTimer();
          //rtxt_plslogger.BackColor = Color.Gray;
        }

        ~LoggViewer()
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
            logg = SingletonLogger.Logg;

            for (int i = CurrentLogLine; i < logg.Count; i++)
            {
                DoGUIUpdate(logg[i]);
            }
            CurrentLogLine = logg.Count;
        }

        #region Delegate Functions

        public void DoGUIUpdate(MessageToLog logitem)
        {
            if (this.InvokeRequired)
            {
                GUIDelegate delegateMethod = new GUIDelegate(this.DoGUIUpdate);
                this.Invoke(delegateMethod, new object[] { logitem });
            }
            else
            {
                Color color = new Color();
                switch (logitem.logtype)
                {
                    case LogType.Alarm:
                        {
                            color = Color.Red;
                            break;
                        }
                    case LogType.Error:
                        {
                            color = Color.Red;
                            break;
                        }
                   case LogType.Info:
                        {
                            color = Color.Green;
                            break;
                        }
                   case LogType.Warning:
                        {
                            color = Color.Blue;
                            break;
                        }
                }

                String TextOut = DateTime.Now + " ---> " + logitem.logmodule.ToString() + " ---> " + logitem.message;

                RichTextBoxExtensions.AppendText(rtxt_plslogger, TextOut, color, true);
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

    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color, bool AddNewLine = false)
        {
            try
            {
                if (AddNewLine)
                {
                    text += Environment.NewLine;
                }

                box.SelectionStart = box.TextLength;
                box.SelectionLength = 0;

                box.SelectionColor = color;
                box.AppendText(text);
                box.SelectionColor = box.ForeColor;
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.ToString() + "ups...");
            }

        }
    }


}

/*
 * TODO: Create a timer that poll the log from the Pls Singleton -- FINISH
 */
