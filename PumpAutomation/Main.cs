using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;
using NextUI;
using NextUI.BaseUI;
using NextUI.Frame;
using NextUI.Component;
using System.Threading;
using PumpAutomation.Database;


namespace PumpAutomation
{
    public partial class Main : Form
    {

        #region Contructor
        public Main()
        {
            InitializeComponent();
            SetupTimes();
            DemoMode = true;
        }

        #region Timers

        void SetupTimes()
        {
            OneSecTimer = new System.Windows.Forms.Timer();
            OneSecTimer.Interval = 1000;
            OneSecTimer.Start();
            OneSecTimer.Tick += OneSecTimer_Tick;
        }

        void OneSecTimer_Tick(object sender, EventArgs e)
        {
            if (bOneSecToggler)
            {
                bOneSecToggler = false;
            }
            else
            {
                bOneSecToggler = true;
            }

        }
     
        #endregion

        #endregion

        #region Variables and Object

        //Private variables
        
        //Forms
            LoggViewer FormLoggViewer = null;
            Options FormOptions = null;
            AboutBox FormAboutbox = null;
            SignalViewer FormSignalViewer = null;
            Rapport FormRapport = null;
            Costumer FormCostumer = null;

        // GUI 


        //bool`s
            private volatile bool bStopUpdateGUIThread = false;
            private volatile bool bOneSecToggler = false;


            private bool _DemoMode = true;

        // String`s
            string sTab = "         ";
            string sDemo = "!!!!!!!!! DEMO MODE !!!!!!!";
            
        // Timers
            private System.Windows.Forms.Timer OneSecTimer;
     
        // Thread`s
            private Thread tThreadUpdateGUI;
            private Gauges _Gauges = new Gauges();

        // Plc Variables
           private Core SingletonCore = Core.Instance;

            // Logger Variable
             private Logger SingletonLogger = Logger.Instance;

        // Database 
           public DatabaseLog DataBaseLogger = new DatabaseLog();

        // Public Variables

        #endregion

        #region Load Settings


        #endregion

        #region Menustrip Click Handels

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if (FormAboutbox != null)
            {
                FormAboutbox.BringToFront();
                FormAboutbox.Show();
            }
            else
            {
                FormAboutbox = new AboutBox();
                FormAboutbox.Show();
            }
        }

        private void signalViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormSignalViewer != null)
            {
                FormSignalViewer.BringToFront();
                FormSignalViewer.Show();
            }
            else
            {
                FormSignalViewer = new SignalViewer();
                FormSignalViewer.Show();
            }
        }


        private void genererRapportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormRapport != null)
            {
                FormRapport.BringToFront();
                FormRapport.Show();
            }
            else
            {
                FormRapport = new Rapport();
                FormRapport.Show();
            }
        
        }

        // TODO: make override so all threads exits grease fully. 
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormOptions != null)
            {
                FormOptions.BringToFront();
                FormOptions.Show();
            }
            else
            {
                FormOptions = new Options();
                FormOptions.Show();
            }
        }

        private void logToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormLoggViewer != null)
            {
                FormLoggViewer.BringToFront();
                FormLoggViewer.Show();
            }
            else
            {
                FormLoggViewer = new LoggViewer();
                FormLoggViewer.Show();
            }
        }

        private void kobleTilPLSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SingletonCore.IsPlcConnected)
            {
                try 
                {
                    SingletonCore.DisconnectFromPlc();
                 
                     kobleTilPLSToolStripMenuItem.Text = "Koble til";
                     toolStripStatusLabel1.Text = "FraKoblet Pls";
                              
                }
                catch (Exception ex)
                {
                    SingletonLogger.AddToLog("Failed to disconnect from PLC --> " + ex.ToString(), LogType.Error, LogModule.CORE);
                }
            }
            else
            {
                try
                {
                    if (SingletonCore.ConnectToPlc())
                    {
                        // Wait for plc variable update
                        Thread.Sleep(50);
                        if (SingletonCore.IsPlcConnected)
                        {
                            kobleTilPLSToolStripMenuItem.Text = "Koble fra";
                            toolStripStatusLabel1.Text = "Tilkoblet PLS";
                        }

                    }
                   
                }
                catch (Exception ex)
                {
                    SingletonLogger.AddToLog("Connection to PLC failed --> " + ex.ToString(), LogType.Error, LogModule.CORE);
                }
            }

        }

        private void simuleringsmodusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (SingletonCore.IsPlcConnected)
            {
                SingletonCore.IsSimulationMode = true;
                if (!SingletonCore.IsSimulationMode)
                {
                    this.Text = "Pump Automation ----  SIMULERINGSMODUS"; 
                }
                else
                {
                    this.Text = "Pump Automation";
                }
            }
        }

        private void testToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           
        }

        private void startLoggingToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (DataBaseLogger.LoggingOn)
            {
                DataBaseLogger.LoggingOn = false;
             
                startLoggingToolStripMenuItem1.Text = "Start Logging";
                kundenavnToolStripMenuItem.Enabled = true;
            }
            else
            {
                DataBaseLogger.LoggingOn = true;
                startLoggingToolStripMenuItem1.Text = "Stop Logging";
                kundenavnToolStripMenuItem.Enabled = false;
            }
        }

        private void kundenavnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FormCostumer != null)
            {
                FormCostumer.BringToFront();
                FormCostumer.Show();
            }
            else
            {
                FormCostumer = new Costumer(this);
                FormCostumer.Show();
            }
        }

        #region Database & Logging

        public void SetCostumerToDB(string text)
        {
            DataBaseLogger.Costumer = text;
            startLoggingToolStripMenuItem1.Enabled = true;
        }

        #endregion


        #endregion

        #region StatusStrip

        #endregion

        #region ClicHandles

        #region Aggregat 1

        private void btn_aggregat1_start_Click(object sender, EventArgs e)
        {
            if (SingletonCore.IsPlcConnected)
            {
                if (SingletonCore._PlcVariables._MBPump1On)
                {
                    SingletonCore.WriteBoolValue(PLC.CPlcVariableDoMore.MBPump1Start, false);
                }
                else if (!SingletonCore._PlcVariables._MBPump1On)
                {
                    SingletonCore.WriteBoolValue(PLC.CPlcVariableDoMore.MBPump1Start, true);
                }
            }

        }

        //TODO
        private void btn_aggregat1_standby_Click(object sender, EventArgs e)
        {

        }

        private void btn_aggregat1_Stop_Click(object sender, EventArgs e)
        {
            if (SingletonCore.IsPlcConnected)
            {
                if (SingletonCore._PlcVariables._MBPump1On)
                {
                    SingletonCore.WriteBoolValue(PLC.CPlcVariableDoMore.MBPump1Start, false);
                }
                else if (!SingletonCore._PlcVariables._MBPump1On)
                {
                    SingletonCore.WriteBoolValue(PLC.CPlcVariableDoMore.MBPump1Start, true);
                }
            }
        }

        private void Pump1RegulatorSetPoint(object a, GaugeArgs e)
        {
            if (SingletonCore.IsPlcConnected)
            {
                float value = e.SPValue; 
                SingletonCore.WriteToRegister(PLC.VPlcVariable.MBFlowRegulator1SetPoint, (short)value);
            }
        }

 
        #endregion

        #region Aggregat 2

        //TODO
        private void btn_aggregat2_start_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void btn_aggregat2_standby_Click(object sender, EventArgs e)
        {

        }

        //TODO
        private void btn_aggregat2_Stop_Click(object sender, EventArgs e)
        {

        }

        private void Pump2RegulatorSetPoint(object a, GaugeArgs e)
        {

            if (SingletonCore.IsPlcConnected)
            {
                float value = e.SPValue;
                SingletonCore.WriteToRegister(PLC.VPlcVariable.MBFlowRegulator2SetPoint, (short)value);
            }
        }


        #endregion

        #endregion

        #region  Main Form load

        private void Main_Load(object sender, EventArgs e)
        {
            SingletonLogger.AddToLog("Loading GUI", LogType.Info, LogModule.GUI);
            //Load Gauges
            LoadGauges();
            LoadButtons();

            toolStripStatusLabel1.Text = "Klar";
            DoGUIButtonLable(this, "Pump Automation" + sTab + sDemo + sTab);
            SingletonLogger.AddToLog("GUI Loaded", LogType.Info, LogModule.GUI);

            SingletonLogger.AddToLog("Starting GUI Update Thread", LogType.Info, LogModule.GUI);
            StartGUIUpdateThread();
        }

        #region Load Gauges

        private void LoadGauges()
        {
            // Pump 1:
            _Gauges.Pump1(ref this.baseUI_pump1, ref this.baseUI2_pump1);
            _Gauges.Regulator1SP += Pump1RegulatorSetPoint;

            // Pump 2:
            _Gauges.Pump2(ref this.baseUI_pump2, ref this.baseUI2_pump2);
            _Gauges.Regulator2SP += Pump2RegulatorSetPoint;

            // Average :
            _Gauges.AverageGauge(ref this.baseUI_pumpAverageFlow);
        }

         #endregion
        
        #region Load Buttons

        private void LoadButtons()
        {
            //Pump1
            btn_aggregat1_start.Enabled = false;
            btn_aggregat1_start.BackColor = Color.Gray;
            btn_aggregat1_Stop.Enabled = false;
            btn_aggregat1_Stop.BackColor = Color.Gray;
            btn_aggregat1_standby.Enabled = false;
            btn_aggregat1_standby.BackColor = Color.Gray;

            //Pump2
            btn_aggregat2_start.Enabled = false;
            btn_aggregat2_start.BackColor = Color.Gray;
            btn_aggregat2_Stop.Enabled = false;
            btn_aggregat2_Stop.BackColor = Color.Gray;
            btn_aggregat2_standby.Enabled = false;
            btn_aggregat2_standby.BackColor = Color.Gray;
        }
        
        #endregion
        #endregion

        #region  GUI Update

        /// <summary>
        /// Called at app startup
        /// </summary>
        private void StartGUIUpdateThread()
        {
            tThreadUpdateGUI = new Thread(new ThreadStart(this.ThreadUpdateGui));
            tThreadUpdateGUI.IsBackground = true;
            tThreadUpdateGUI.Start();
        }


        /// <summary>
        /// This method does the sequential update of the Gui. Reading the core plc variables.
        /// </summary>
        public void ThreadUpdateGui()
        {
            SingletonLogger.AddToLog("GUI Update Thread has Started", LogType.Info, LogModule.GUI);

            bool firstrun = true;
            bool EndRun = false;

            while (!bStopUpdateGUIThread)
            {
               while (SingletonCore != null && SingletonCore.IsPlcConnected)
               {
                   if (firstrun)
                   { 
                       EnableButtons(); 
                       firstrun = false; 
                       EndRun = true;
                       DataBaseLogger.LoggingEnabled = true;
                   }

                        //Pump1
                       Aggregat1LabelUpdate();
                       Aggregat1ButtonsUpdate();
                       Aggregat1GaugeFlowUpdate();
                       Aggregat1GaugePressureUpdate();

                        //Pump2
                       Aggregat2GaugeFlowUpdate();
                       Aggregat2GaugePressureUpdate();
                       Aggregat2LabelUpdate();
                        
                        //Average
                       AverageGaugeUpdate();
                       AverageLabelUpdate(); 
                    
                       HeaderTextUpdate();

                       ContSensUpdate();

                       OilUpdate();
                      
                      Thread.Sleep(Properties.Settings.Default.GuiUpdatetime);  
                       
               }

               if (EndRun)
               { 
                   DisableButtons();
                   DisableTextBoxes();
                   EndRun = false;
                   firstrun = true;
                   DataBaseLogger.LoggingEnabled = false;
                   DoGUIButtonLable(this, "Pump Automation" + "!!!!!!!!! DEMO MODE !!!!!!!");
               }

                Thread.Sleep(10);
            }
            SingletonLogger.AddToLog("GUI Update Thread has Stopped", LogType.Warning, LogModule.GUI);
        }

        /// <summary>
        /// Called from update gui thread if plc is connected
        /// </summary>
        private void EnableButtons()
        {
            //pump1
            DoGUIButtonUpdate(btn_aggregat1_start, true, Color.Green);
            DoGUIButtonUpdate(btn_aggregat1_standby, true, Color.Orange);
            DoGUIButtonUpdate(btn_aggregat1_Stop, true, Color.Red);
            //Pump2
           // DoGUIButtonUpdate(btn_aggregat2_start, true, Color.Green);
           // DoGUIButtonUpdate(btn_aggregat2_standby, true, Color.Orange);
          //  DoGUIButtonUpdate(btn_aggregat2_Stop, true, Color.Red);
        }

        #endregion

        #region Main Form Update

        // Form
        private void HeaderTextUpdate()
        {
           
            string HeaderText = "Pump Automation" + sTab;
            

            HeaderText += SingletonCore._PlcVariables.PlcTime + sTab;

            if (SingletonCore._PlcVariables._MBSimulationMode)
            {
                HeaderText += " !!!!! SIMULATION MODE !!!!!" + sTab;
            }

            HeaderText += sDemo;

            DoGUIButtonLable(this, HeaderText);
        }

        //Aggregate 1
        private void Aggregat1GaugeFlowUpdate()
        {
            DoGuauge1FlowUpdate((int)SingletonCore._PlcVariables.MBFlow1);               
        }
        private void Aggregat1GaugePressureUpdate()
        {
            DoGuauge1PressureUpdate((int)SingletonCore._PlcVariables.MBPressure1);            
        }
        private void Aggregat1ButtonsUpdate()
        {
            if (SingletonCore._PlcVariables._MBPump1On)
            {
                DoGUIButtonUpdate(this.btn_aggregat1_start, false);
            }
            else
            {
                DoGUIButtonUpdate(this.btn_aggregat1_start, true);
            }

            //if (SingletonCore._PlcVariables._A1_Bypass)
            //{
            //    DoGUIButtonUpdate(this.btn_aggregat1_standby, false);
            //}
            //else
            //{
            //    DoGUIButtonUpdate(this.btn_aggregat1_standby, true);
            //}

            if (SingletonCore._PlcVariables._MBPump1On)
            {
                DoGUIButtonUpdate(this.btn_aggregat1_Stop, true);
            }
            else
            {
                DoGUIButtonUpdate(this.btn_aggregat1_Stop, false);
            }
        }
        private void Aggregat1LabelUpdate()
        {
            // Ag1 Pressure (bar)
            DoGUITxtBox(txt_aggregat1_pressure, Color.Black, Color.DarkGray, SingletonCore._PlcVariables.MBPressure1.ToString());
            DoGUITxtBox(txt_aggregat1_Flow, Color.Black, Color.DarkGray, SingletonCore._PlcVariables.MBFlow1.ToString());

            #region TFilter
            
                // Warning
            if (SingletonCore._PlcVariables.T_Filter1 >= Properties.Settings.Default.TFilterWarn && SingletonCore._PlcVariables.T_Filter1 < Properties.Settings.Default.TFilterAlam)
            {
               
              if (bOneSecToggler)
                { DoGUITxtBox(txt_aggregat1_T1_Filter, Color.Black, Color.BlueViolet, SingletonCore._PlcVariables.T_Filter1.ToString()); }
                else
                { DoGUITxtBox(txt_aggregat1_T1_Filter, Color.BlueViolet, Color.Black, SingletonCore._PlcVariables.T_Filter1.ToString()); }
            }
            // Alarm Level
            else if (SingletonCore._PlcVariables.T_Filter1 >= Properties.Settings.Default.TFilterAlam)
            {
                if (bOneSecToggler)
                { DoGUITxtBox(txt_aggregat1_T1_Filter, Color.Black, Color.Red, SingletonCore._PlcVariables.T_Filter1.ToString()); }
                else
                { DoGUITxtBox(txt_aggregat1_T1_Filter, Color.Red, Color.Black, SingletonCore._PlcVariables.T_Filter1.ToString()); }
            }
             // Normal Value
            else
            {
                  DoGUITxtBox(txt_aggregat1_T1_Filter, Color.Black, Color.DarkGray, SingletonCore._PlcVariables.T_Filter1.ToString());
            }

             #endregion
            // _TF1_Warning
            //if (SingletonCore._PlcVariables._TF1_Warning)
            //{ DoGUIButtonLable(txt_aggregat1_T1_Filter, "ALARM"); }
            //else { DoGUIButtonLable(txt_aggregat1_T1_Filter, "OK"); }

            //TempAg1
          //  DoGUIButtonLable(txt_aggregat1_temp, (SingletonCore._PlcVariables.Ag1Temp).ToString());

        }

        //Aggregate 2
        private void Aggregat2GaugeFlowUpdate()
        {
            DoGuauge2FlowUpdate((int)SingletonCore._PlcVariables.MBFlow2);
        }
        private void Aggregat2GaugePressureUpdate()
        {
            DoGuauge2PressureUpdate((int)SingletonCore._PlcVariables.MBPressure2);
        }
        private void Aggregat2LabelUpdate()
        {
            // Ag1 Pressure (bar)
            DoGUITxtBox(txt_aggregat2_pressure, Color.Black, Color.DarkGray, SingletonCore._PlcVariables.MBPressure2.ToString());
            DoGUITxtBox(txt_aggregat2_Flow, Color.Black, Color.DarkGray, SingletonCore._PlcVariables.MBFlow2.ToString());
            DoGUITxtBox(txt_aggregat2_T1_Filter, Color.Black, Color.DarkGray, SingletonCore._PlcVariables.T_Filter2.ToString());

            #region TFilter

            // Warning
            if (SingletonCore._PlcVariables.T_Filter2 >= Properties.Settings.Default.TFilterWarn && SingletonCore._PlcVariables.T_Filter2 < Properties.Settings.Default.TFilterAlam)
            {

                if (bOneSecToggler)
                { DoGUITxtBox(txt_aggregat2_T1_Filter, Color.Black, Color.BlueViolet, SingletonCore._PlcVariables.T_Filter2.ToString()); }
                else
                { DoGUITxtBox(txt_aggregat2_T1_Filter, Color.BlueViolet, Color.Black, SingletonCore._PlcVariables.T_Filter2.ToString()); }
            }
            // Alarm Level
            else if (SingletonCore._PlcVariables.T_Filter2 >= Properties.Settings.Default.TFilterAlam)
            {
                if (bOneSecToggler)
                { DoGUITxtBox(txt_aggregat2_T1_Filter, Color.Black, Color.Red, SingletonCore._PlcVariables.T_Filter2.ToString()); }
                else
                { DoGUITxtBox(txt_aggregat2_T1_Filter, Color.Red, Color.Black, SingletonCore._PlcVariables.T_Filter2.ToString()); }
            }
            // Normal Value
            else
            {
                DoGUITxtBox(txt_aggregat2_T1_Filter, Color.Black, Color.DarkGray, SingletonCore._PlcVariables.T_Filter2.ToString());
            }

            #endregion

            // _TF1_Warning
            //if (SingletonCore._PlcVariables._TF1_Warning)
            //{ DoGUIButtonLable(txt_aggregat1_T1_Filter, "ALARM"); }
            //else { DoGUIButtonLable(txt_aggregat1_T1_Filter, "OK"); }

            //TempAg1
            //  DoGUIButtonLable(txt_aggregat1_temp, (SingletonCore._PlcVariables.Ag1Temp).ToString());

        }

        //Average
        private void AverageGaugeUpdate()
        {
            float total = ((CircularFrame)(this.baseUI_pump1.Frame[0])).ScaleCollection[0].Pointer[0].Value +
                          ((CircularFrame)(this.baseUI_pump2.Frame[0])).ScaleCollection[0].Pointer[0].Value; 
            DoGuaugeAverageUpdate((int)total);
        }
        void AverageLabelUpdate()
        {
            #region Return Filter

            // Warning % level
            if (SingletonCore._PlcVariables.R_Filter >= Properties.Settings.Default.RFilterWarm && SingletonCore._PlcVariables.R_Filter < Properties.Settings.Default.RFilterAlarm)
            {
                if (bOneSecToggler)
                { DoGUITxtBox(txt_average_R_Filter, Color.Black, Color.BlueViolet, SingletonCore._PlcVariables.R_Filter.ToString()); }
                else
                { DoGUITxtBox(txt_average_R_Filter, Color.BlueViolet, Color.Black, SingletonCore._PlcVariables.R_Filter.ToString()); }

            }
            // Alarm Level
            else if (SingletonCore._PlcVariables.R_Filter >= Properties.Settings.Default.RFilterAlarm)
            {
                if (bOneSecToggler)
                { DoGUITxtBox(txt_average_R_Filter, Color.Black, Color.Red, SingletonCore._PlcVariables.R_Filter.ToString()); }
                else
                { DoGUITxtBox(txt_average_R_Filter, Color.Red, Color.Black, SingletonCore._PlcVariables.R_Filter.ToString()); }

            }
            // Normale Mode
            else
            {
                DoGUITxtBox(txt_average_R_Filter, Color.Black, Color.GreenYellow, SingletonCore._PlcVariables.R_Filter.ToString());
            }

            #endregion
        }

        //Contamination Sensor
        private void ContSensUpdate()
        {
            DoGUIButtonLable(txt_pls_a_4_um, SingletonCore._PlcVariables.MBConSens4.ToString());
            DoGUIButtonLable(txt_pls_b_6_um, SingletonCore._PlcVariables.MBConSens6.ToString());
            DoGUIButtonLable(txt_pls_c_14_um, SingletonCore._PlcVariables.MBConSens14.ToString());
            DoGUIButtonLable(txt_pls_d_21_um, SingletonCore._PlcVariables.MBConSens21.ToString());


            switch (SingletonCore._PlcVariables.MBConSensStaus)
            {
                case 5:
                    {
                        DoGUIButtonLable(txt_pls_partikkel_status, "OK");
                        break;
                    }
                case 6:
                    {
                       DoGUIButtonLable(txt_pls_partikkel_status, "Feil / Ikke klar"); 
                        break;
                    }
                case 7:
                    {
                        DoGUIButtonLable(txt_pls_partikkel_status, "Lav flow"); 
                        break;
                    }
                case 8:
                    {
                        DoGUIButtonLable(txt_pls_partikkel_status, " ISO <9.<8.<7");
                        break;
                    }
                case 9:
                    {
                        DoGUIButtonLable(txt_pls_partikkel_status, "No measured value");
                        break;
                    }
                default:
                        DoGUIButtonLable(txt_pls_partikkel_status, "Ukjent");
                        break;
            }

        }

        // Oil 
        private void OilUpdate()
        {
            #region Temp
            //Low Temp Blue
            if (SingletonCore._PlcVariables.MBOilTemp < Properties.Settings.Default.OilLowTemp)
            {
                if (bOneSecToggler)
                { DoGUITxtBox(txt_oil_temp, Color.Yellow, Color.Blue, SingletonCore._PlcVariables.MBOilTemp.ToString()); } 
                else
                {  DoGUITxtBox(txt_oil_temp, Color.Blue, Color.Yellow, SingletonCore._PlcVariables.MBOilTemp.ToString()); }
               
            } 
            // High Temp Red
            else if (SingletonCore._PlcVariables.MBOilTemp > Properties.Settings.Default.OilHighTemp)
            {

                if (bOneSecToggler)
                { DoGUITxtBox(txt_oil_temp, Color.Black, Color.Red, SingletonCore._PlcVariables.MBOilTemp.ToString()); }
                else
                { DoGUITxtBox(txt_oil_temp, Color.Red, Color.Black, SingletonCore._PlcVariables.MBOilTemp.ToString()); }
               
            }
            // Normale Temp Green
            else 
            {

                DoGUITxtBox(txt_oil_temp, Color.Black, Color.GreenYellow, SingletonCore._PlcVariables.MBOilTemp.ToString());
            }
            #endregion

            #region Water

            // Warning % level
            if (SingletonCore._PlcVariables.MBWaterContent >= Properties.Settings.Default.OilWaterWarn && SingletonCore._PlcVariables.MBWaterContent < Properties.Settings.Default.OilWaterAlarm)
            {
                if (bOneSecToggler)
                { DoGUITxtBox(txt_oil_watercontent, Color.Black, Color.BlueViolet, SingletonCore._PlcVariables.MBWaterContent.ToString()); }
                else
                { DoGUITxtBox(txt_oil_watercontent, Color.BlueViolet, Color.Black, SingletonCore._PlcVariables.MBWaterContent.ToString()); }
               
            } 
                // Alarm Level
            else if (SingletonCore._PlcVariables.MBWaterContent >= Properties.Settings.Default.OilWaterAlarm)
            {
                if (bOneSecToggler)
                { DoGUITxtBox(txt_oil_watercontent, Color.Black, Color.Red, SingletonCore._PlcVariables.MBWaterContent.ToString()); }
                else
                { DoGUITxtBox(txt_oil_watercontent, Color.Red, Color.Black, SingletonCore._PlcVariables.MBWaterContent.ToString()); }
      
            }
                // Normale Mode
            else
            {
                DoGUITxtBox(txt_oil_watercontent, Color.Black, Color.GreenYellow, SingletonCore._PlcVariables.MBWaterContent.ToString());
            }
            
            #endregion
        }

        #region Disabeling


        void DisableButtons()
        {
            //Pump1
            DoGUIButtonUpdate(btn_aggregat1_start, false, Color.Gray);
            DoGUIButtonUpdate(btn_aggregat1_standby, false, Color.Gray);
            DoGUIButtonUpdate(btn_aggregat1_Stop, false, Color.Gray);

            //Pump2
            DoGUIButtonUpdate(btn_aggregat2_start, false, Color.Gray);
            DoGUIButtonUpdate(btn_aggregat2_standby, false, Color.Gray);
            DoGUIButtonUpdate(btn_aggregat2_Stop, false, Color.Gray);
        }

        void DisableTextBoxes()
        {
            DoGUITxtBox(txt_oil_temp, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_oil_watercontent, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_aggregat1_pressure, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_aggregat1_Flow, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_aggregat2_pressure, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_aggregat2_Flow, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_aggregat1_T1_Filter, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_aggregat2_T1_Filter, Color.Black, Color.DarkGray, "-");

            DoGUITxtBox(txt_pls_a_4_um, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_pls_b_6_um, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_pls_c_14_um, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_pls_d_21_um, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_pls_partikkel_status, Color.Black, Color.DarkGray, "-");
            DoGUITxtBox(txt_average_R_Filter, Color.Black, Color.DarkGray, "-");
        }

        #endregion

        #endregion

        #region GUI Delegate Declarations
        //public delegate void GUIDelegate(string paramString, DateTime datetime);
        public delegate void GUIDelegateTxtBox(Control control, Color Forground, Color Background, string text);
        public delegate void GUIDelegateButtons(Control control, bool enabled);
        public delegate void GUIDelegateButtonsColor(Control control, bool enabled, Color color);
        public delegate void GUIDelegateLable(Control control, string text);
        public delegate void GUIDelegateGauge1Flow(int value);
        public delegate void GUIDelegateGauge1Pressure(int value);
        public delegate void GUIDelegateGauge2Flow(int value);
        public delegate void GUIDelegateGauge2Pressure(int value);
        public delegate void OnDrag(object sender, float value);

        #endregion

        #region Delegate Functions

        public void DoGUITxtBox(Control control, Color Forground, Color Background, string text)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateTxtBox delegateMethod = new GUIDelegateTxtBox(this.DoGUITxtBox);
                this.Invoke(delegateMethod, new object[] { control, Forground, Background, text });
            }
            else
            {
                control.Text = text;
                control.BackColor = Background;
                control.ForeColor = Forground;
            }
        }

        public void DoGUIButtonLable(Control control, string text)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateLable delegateMethod = new GUIDelegateLable(this.DoGUIButtonLable);
                this.Invoke(delegateMethod, new object[] { control, text });
            }
            else
            {
                control.Text = text;
            }
        }

        public void DoGUIButtonUpdate(Control control, bool enabled)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateButtons delegateMethod = new GUIDelegateButtons(this.DoGUIButtonUpdate);
                this.Invoke(delegateMethod, new object[] { control, enabled });
            }
            else
            {
                    control.Enabled = enabled;
            }
        }

        public void DoGUIButtonUpdate(Control control, bool enabled, Color color)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateButtonsColor delegateMethod = new GUIDelegateButtonsColor(this.DoGUIButtonUpdate);
                this.Invoke(delegateMethod, new object[] { control, enabled, color });
            }
            else
            {
                control.BackColor = color;
                control.Enabled = enabled;
            }
        }

        public void DoGuauge1FlowUpdate(int value)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateGauge1Flow delegateMethod = new GUIDelegateGauge1Flow(this.DoGuauge1FlowUpdate);
                this.Invoke(delegateMethod, new object[] { value });
            }
            else
            {
                ((CircularFrame)(this.baseUI_pump1.Frame[0])).ScaleCollection[0].Pointer[0].Value = value;
            }
        }

        public void DoGuauge1PressureUpdate(int value)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateGauge1Pressure delegateMethod = new GUIDelegateGauge1Pressure(this.DoGuauge1PressureUpdate);
                this.Invoke(delegateMethod, new object[] { value });
            }
            else
            {
                ((CircularFrame)(this.baseUI_pump1.Frame[1])).ScaleCollection[0].Pointer[0].Value = value;
            }
        }

        public void DoGuauge2FlowUpdate(int value)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateGauge2Flow delegateMethod = new GUIDelegateGauge2Flow(this.DoGuauge2FlowUpdate);
                this.Invoke(delegateMethod, new object[] { value });
            }
            else
            {
                ((CircularFrame)(this.baseUI_pump2.Frame[0])).ScaleCollection[0].Pointer[0].Value = value;
            }
        }

        public void DoGuauge2PressureUpdate(int value)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateGauge2Pressure delegateMethod = new GUIDelegateGauge2Pressure(this.DoGuauge2PressureUpdate);
                this.Invoke(delegateMethod, new object[] { value });
            }
            else
            {
                ((CircularFrame)(this.baseUI_pump2.Frame[1])).ScaleCollection[0].Pointer[0].Value = value;
            }
        }

        public void DoGuaugeAverageUpdate(int value)
        {
            if (this.InvokeRequired)
            {
                GUIDelegateGauge1Flow delegateMethod = new GUIDelegateGauge1Flow(this.DoGuaugeAverageUpdate);
                this.Invoke(delegateMethod, new object[] { value });
            }
            else
            {
                ((CircularFrame)(this.baseUI_pumpAverageFlow.Frame[0])).ScaleCollection[0].Pointer[0].Value = value;
            }
        }

        #endregion

        #region Overides

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);

            if (e.CloseReason == CloseReason.WindowsShutDown) return;

            // Confirm user wants to close
            switch (MessageBox.Show(this, "Vil du virkelig avslutte?", "Avslutter", MessageBoxButtons.YesNo))
            {
                case DialogResult.No:
                    e.Cancel = true;
                    break;
                default:

                    ClosePls();
                    CloseThreads();
                    CloseLogger();

                    break;
            }
        }

        private void ClosePls()
        {
            while (SingletonCore.IsPlcConnected)
            {
                SingletonCore.DisconnectFromPlc();
                Thread.Sleep(10);
            }
            //SingletonCore = null;
        }

        private void CloseThreads()
        {
            bStopUpdateGUIThread = true;

            while (tThreadUpdateGUI.IsAlive)
            {
                tThreadUpdateGUI.Abort();
                Thread.Sleep(10);
            }
        }

        private void CloseLogger()
        {
            SingletonLogger = null;
        }

        #endregion

        #region GET / SET
        public bool DemoMode
        {
            get
            {
                return _DemoMode;
            }

            set
            {
                if (value == true)
                {
                    sDemo = "!!!!!!!!! DEMO !!!!!!!!!!" + sTab;
                    _DemoMode = true;
                }
                else
                {
                    sDemo = "";
                    _DemoMode = false;
                }
            }
        }

        #endregion

        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SingletonCore.test();
        }


    }
}
