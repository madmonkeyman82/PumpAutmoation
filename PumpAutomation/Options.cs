using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Timers;
using System.IO.Ports;

namespace PumpAutomation
{
    public partial class Options : Form
    {
        public Options()
        {
            InitializeComponent();
            this.Activated += Options_Activated;
            hidden = false;
            
        }

        #region  Public`s

        public bool UnlockCode(string code)
        {
            if (code == "tess")
            {
                tbc_options.Enabled = true;
                btn_lock.Text = "Lock";
                return true;
            }
            else
            {
                tbc_options.Enabled = false;
                btn_lock.Text = "UnLock";
                return false;
            }
        }

        #endregion

        #region Private`s

        private void Settings_Load(object sender, EventArgs e)
        {
            LoadListboxes();
            this.TopMost = true;


            tbc_options.Enabled = false;
#if DEBUG

            tbc_options.Enabled = true;

#endif
            Loadsettings(); 
        }

        private bool hidden = true;

        private void Options_Activated(object sender, EventArgs e)
        {
            if (hidden)
            {
               
                Loadsettings();
            }
           
        }

        #endregion

        #region Settings Load

        private void Loadsettings()
        {
            cb_modbusmode.Checked = Properties.Settings.Default.ComMode;
            cb_Ports.Text = Properties.Settings.Default.comPort;
            cb_Baudrate.Text = Properties.Settings.Default.Baudrate.ToString();
            cb_parity.Text = Properties.Settings.Default.Parity;
            cb_timeout.Text = Properties.Settings.Default.TimeOut.ToString();
            cb_protocol.Text = Properties.Settings.Default.Protocol;
            cb_databits.Text = Properties.Settings.Default.Databits.ToString();
            cb_timeout.Text = Properties.Settings.Default.GuiUpdatetime.ToString();
            cb_GuiUpdateTime.Text = Properties.Settings.Default.GuiUpdatetime.ToString();
            cb_plc_fast_cycle_delay.Text = Properties.Settings.Default.PlcUpdatetimeFastCylce.ToString();
            cb_plc_slow_cycle_delay.Text = Properties.Settings.Default.PlcUpdatetimeSlowCylce.ToString();
            txt_oil_temp_high.Text = Properties.Settings.Default.OilHighTemp.ToString();
            txt_oil_temp_low.Text = Properties.Settings.Default.OilLowTemp.ToString();
            txt_oil_volume_high.Text = Properties.Settings.Default.OilHighVolume.ToString();
            txt_oil_volume_low.Text = Properties.Settings.Default.OilLowVolume.ToString();
            txt_oil_water_warn.Text = Properties.Settings.Default.OilWaterWarn.ToString();
            txt_oil_water_Alarm.Text = Properties.Settings.Default.OilWaterAlarm.ToString();
            txt_tfilter_warn_press.Text = Properties.Settings.Default.TFilterWarn.ToString();
            txt_tfilter_alarm_press.Text = Properties.Settings.Default.TFilterAlam.ToString();
            txt_Rfilter_warn_press.Text = Properties.Settings.Default.RFilterWarm.ToString();
            txt_Rfilter_alarm_press.Text = Properties.Settings.Default.RFilterAlarm.ToString();
            cb_logginerval.Text = Properties.Settings.Default.LogToDBInterval.ToString();
            tb_plcPort.Text = Properties.Settings.Default.PlcIpPort.ToString();
            tb_plcip.Text = Properties.Settings.Default.PlcIP;

        }
       
       

        #endregion

        #region Settings Save

        private void SaveSettings()
        {
            //GUI / HMI
            Properties.Settings.Default.ComMode = cb_modbusmode.Checked;
            Properties.Settings.Default.PlcIpPort = Convert.ToInt32(tb_plcPort.Text);
            Properties.Settings.Default.PlcIP = tb_plcip.Text;
            Properties.Settings.Default.comPort = cb_Ports.Text;
            Properties.Settings.Default.Baudrate = Convert.ToInt32(cb_Baudrate.Text);
            Properties.Settings.Default.Parity = cb_parity.Text;
            Properties.Settings.Default.TimeOut = Convert.ToInt32(cb_timeout.Text);
            Properties.Settings.Default.Protocol = cb_protocol.Text;
            Properties.Settings.Default.Databits = Convert.ToInt32(cb_databits.Text);
            Properties.Settings.Default.GuiUpdatetime = Convert.ToInt32(cb_GuiUpdateTime.Text);
            Properties.Settings.Default.PlcUpdatetimeFastCylce = Convert.ToInt32(cb_plc_fast_cycle_delay.Text);
            Properties.Settings.Default.PlcUpdatetimeSlowCylce = Convert.ToInt32(cb_plc_slow_cycle_delay.Text);

            //Process
            Properties.Settings.Default.OilHighTemp = Convert.ToInt32(txt_oil_temp_high.Text);
             Properties.Settings.Default.OilLowTemp = Convert.ToInt32(txt_oil_temp_low.Text);
             Properties.Settings.Default.OilHighVolume = Convert.ToInt32(txt_oil_volume_high.Text);
             Properties.Settings.Default.OilLowVolume = Convert.ToInt32(txt_oil_volume_low.Text);
             Properties.Settings.Default.OilWaterWarn = Convert.ToInt32(txt_oil_water_warn.Text);
             Properties.Settings.Default.OilWaterAlarm = Convert.ToInt32(txt_oil_water_Alarm.Text);
             Properties.Settings.Default.TFilterWarn = Convert.ToDouble(txt_tfilter_warn_press.Text);
             Properties.Settings.Default.TFilterAlam = Convert.ToDouble(txt_tfilter_alarm_press.Text);
             Properties.Settings.Default.RFilterWarm = Convert.ToDouble(txt_Rfilter_warn_press.Text);
             Properties.Settings.Default.RFilterAlarm = Convert.ToDouble(txt_Rfilter_alarm_press.Text);

             //Rapport
             Properties.Settings.Default.LogToDBInterval = Convert.ToInt32(cb_logginerval.Text);

            Properties.Settings.Default.Save();
        }


        #endregion

        #region Load Listboxes
        private void LoadListboxes()
        {
            //Three to load - ports, baudrates, datetype.  Also set default textbox values:
            //1) Available Ports:
            string[] ports = SerialPort.GetPortNames();

            foreach (string port in ports)
            {
                cb_Ports.Items.Add(port);
            }
            cb_Ports.SelectedIndex = 0;

            //2) Baudrates:
            string[] baudrates = { "230400", "115200", "57600", "38400", "19200", "9600", "4800", "2400", "900", "600", "300" };

            foreach (string baudrate in baudrates)
            {
                cb_Baudrate.Items.Add(baudrate);
            }
            cb_Baudrate.SelectedIndex = 4;

            //3) Stop Bits:
            string[] stopbits = { StopBits.One.ToString(), StopBits.OnePointFive.ToString(), StopBits.Two.ToString(), StopBits.None.ToString() };

            foreach (string stopbits_ in stopbits)
            {
                cb_stopbits.Items.Add(stopbits_);
            }
            cb_stopbits.SelectedIndex = 0;

            //4) Parity:
            string[] partiys = { Parity.Even.ToString(), Parity.Mark.ToString(), Parity.None.ToString(), Parity.Odd.ToString(), Parity.Space.ToString() };

            foreach (string partiy in partiys)
            {
                cb_parity.Items.Add(partiy);
            }
            cb_parity.SelectedIndex = 3;

            //5) Protocol:

            string[] protocols = { "DirectNET", "ModbusRTU", "None" };

            foreach (string protocol in protocols)
            {
                cb_protocol.Items.Add(protocol);
                
            }
            cb_protocol.SelectedIndex = 1;

            //6) TimeOut:
            string[] timeouts = { "10", "50", "100", "200", "300", "500", "800", "1000", "1500", "5000", "10000" };

            foreach (string timeout in timeouts)
            {
                cb_timeout.Items.Add(timeout);
            }
            cb_timeout.SelectedIndex = 7;

            //7) Databits:
            string[] databits = { "7","8" };

            foreach (string databit in databits)
            {
                cb_databits.Items.Add(databit);
            }
            cb_databits.SelectedIndex = 0;

            //8) GuiUpdateTime:
            string[] GuiUpdateTime = {"10", "50", "100", "500", "800", "1000", "1500" };

            foreach (string times in GuiUpdateTime)
            {
                cb_GuiUpdateTime.Items.Add(times);
            }
            cb_GuiUpdateTime.SelectedIndex = 0;

            //9) PlcUpdateSlowCycleDelay:
            string[] PlcUpdateSlowCycleDelay = { "5", "10", "50", "100", "200", "500", "800", "1000" };

            foreach (string times in PlcUpdateSlowCycleDelay)
            {
                cb_plc_slow_cycle_delay.Items.Add(times);
            }
            cb_plc_slow_cycle_delay.SelectedIndex = 0;

            //10) PlcUpdateFastCycleDelay:
            string[] PlcUpdateFastCycleDelay = { "5", "10", "50", "100", "200", "500", "800", "1000" };

            foreach (string times in PlcUpdateFastCycleDelay)
            {
                cb_plc_fast_cycle_delay.Items.Add(times);
            }
            cb_plc_fast_cycle_delay.SelectedIndex = 0;

            //11) LoggerIntervalTime:
            string[] LoggingIntervalTime = { "1", "2", "5", "60", "120", "600", "800", "3600" };

            foreach (string times in LoggingIntervalTime)
            {
                cb_logginerval.Items.Add(times);
            }
            cb_logginerval.SelectedIndex = 3;



        }
        #endregion

        #region Click Handles
        private void btn_save_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void btn_lock_Click(object sender, EventArgs e)
        {
            if (!tbc_options.Enabled)
            {
                OptionsUnLock FormUnlock = new OptionsUnLock(this);
                this.TopMost = false;
                FormUnlock.Show();
            }
            else
            {
                tbc_options.Enabled = false;
                btn_lock.Text = "UnLock";
            }

        }


        #endregion

        #region Overides

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            hidden = true;
            this.Hide();
            e.Cancel = true;

            return;
        }

        #endregion
   


    }
}
