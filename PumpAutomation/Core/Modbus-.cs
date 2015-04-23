using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PumpAutomation;
using PumpAutomation.PLC;
using ModbusTCP;

namespace PumpAutomation
{
    class Modbus
    {

        #region Constructor / Deconstructor

        public Modbus()
        {
            StartUpdateModbus();
        }

        ~Modbus()
        {
            _IsClosing = true;
            _tThreadUpdateModbus.Abort();
            MBmaster.disconnect();
            if (MBmaster != null)
            {
                MBmaster.Dispose();
                MBmaster = null;
            }	
        }



        #endregion

        #region Private Vaibles

        //Modbus Commnunication class
        private ModbusTCP.Master MBmaster;


        // Logger Variable
        private Logger SingletonLogger = Logger.Instance;

        // Thread`s
        private Thread _tThreadUpdateModbus;

        //bool`s
        private bool _IsClosing = false;

        #endregion

        #region Thread

        private void StartUpdateModbus()
        {
            _tThreadUpdateModbus = new Thread(new ThreadStart(this.ThreadUpdateModbus));
            _tThreadUpdateModbus.IsBackground = true;
            _tThreadUpdateModbus.Name = "MODBUS UPDATE THREAD";
            _tThreadUpdateModbus.Start();

            Connect();
        }

        private void ThreadUpdateModbus()
        {
            while (!_IsClosing) 
            {
                int PrefCounter = 0;

                while (_IsConnected)
                {
                    int MsNow = DateTime.Now.Millisecond;

                    if (MBmaster.connected)
                    {
                        ReadCoils();
                        ReadHoldRegister();
                    }
                    else
                    {
                        _IsConnected = false;
                    }

                    _PreformanceTimeMs[PrefCounter] = Math.Abs((DateTime.Now.Millisecond - MsNow));

                    // ?: conditional operator.
                    //classify = (input > 0) ? "positive" : "negative";

                    if (PrefCounter >= 4)
                    { PrefCounter = 0; }
                    else
                    { PrefCounter++; }
                    

                } // end while _IsConnected
                Thread.Sleep(5);
            } // end while _IsClosing
        }

        #endregion  

        
        #region Modbus General

        // ------------------------------------------------------------------------
        // Connect
        // ------------------------------------------------------------------------
        public bool Connect()
        {
            if (!_IsConnected)
            {
                try
                {
                    // Create new modbus master and add event functions
                    MBmaster = new Master(_MoudbusIPAddress, _MoudbusPort);
                    MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                    MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                    // Show additional fields, enable watchdog
                    _IsConnected = true;
                    return true;
                }
                catch (SystemException ex)
                {
                    SingletonLogger.AddToLog("Modbus connction error: " + ex.Message, LogType.Error, LogModule.COM);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        // ------------------------------------------------------------------------
        // DisConnect
        // ------------------------------------------------------------------------
        public bool DisConnect()
        {
            if (MBmaster.connected)
            {
                try
                {
                    MBmaster.OnException -= MBmaster_OnException;
                    MBmaster.OnResponseData -= MBmaster_OnResponseData;
                    MBmaster.disconnect();

                    _IsConnected = false;
                    return true;
                }
                catch (SystemException ex)
                {
                    SingletonLogger.AddToLog("Modbus connction error: " + ex.Message, LogType.Error, LogModule.COM);
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        #endregion

        #region Modbus Read

        // ------------------------------------------------------------------------
        // Read coils
        // ------------------------------------------------------------------------
        private void ReadCoils()
        {
            byte[] byteCoilRegisterTemp = new byte[128];

            ushort ID = 1;

            byte UNIT = 0;

            MBmaster.ReadCoils(ID, UNIT, (ushort)0, (ushort)1023, ref byteCoilRegisterTemp);
            Buffer.BlockCopy(byteCoilRegisterTemp, 0, _CoilsData, 0, byteCoilRegisterTemp.Length);
        }



        // ------------------------------------------------------------------------
        // Read holding register
        // ------------------------------------------------------------------------
        private void ReadHoldRegister()
        {
            ushort ID = 3;
            byte UNIT = 0;
            
            //-------
            //Read all Holding Registers in sequence and block copy in to int16 register
            //0 - 99 
            //100 - 199
            //200 - 299
            //300 - 300

            //Check preformance timestamp
          //  DateTime timeStart = DateTime.Now;

            byte[] byteHoldingRegisterTemp = new byte[99];
            
            //0 - 99
            MBmaster.ReadHoldingRegister(ID, UNIT, (ushort)0, (ushort)99, ref byteHoldingRegisterTemp);
            Buffer.BlockCopy(byteHoldingRegisterTemp, 0, _RegisterData, 0, byteHoldingRegisterTemp.Length);

            //100 - 199
            MBmaster.ReadHoldingRegister(ID, UNIT, (ushort)100, (ushort)99, ref byteHoldingRegisterTemp);
            Buffer.BlockCopy(byteHoldingRegisterTemp, 0, _RegisterData, 199, byteHoldingRegisterTemp.Length);

            //200 - 299
            MBmaster.ReadHoldingRegister(ID, UNIT, (ushort)200, (ushort)99, ref byteHoldingRegisterTemp);
            Buffer.BlockCopy(byteHoldingRegisterTemp, 0, _RegisterData, 399, byteHoldingRegisterTemp.Length);

            //300 - 399
            MBmaster.ReadHoldingRegister(ID, UNIT, (ushort)300, (ushort)99, ref byteHoldingRegisterTemp);
            Buffer.BlockCopy(byteHoldingRegisterTemp, 0, _RegisterData, 598, byteHoldingRegisterTemp.Length);

            //Check preformnace end
            //TimeSpan performanceTime = (DateTime.Now - timeStart);
        }

        // ------------------------------------------------------------------------
        // Read start address
        // ------------------------------------------------------------------------
      /*
        private ushort ReadStartAdr()
        {

            
            // Convert hex numbers into decimal
            if (txtStartAdress.Text.IndexOf("0x", 0, txtStartAdress.Text.Length) == 0)
            {
                string str = txtStartAdress.Text.Replace("0x", "");
                ushort hex = Convert.ToUInt16(str, 16);
                return hex;
            }
            else
            {
                return Convert.ToUInt16(txtStartAdress.Text);
            }
             
        }
       * */
        #endregion

        #region OnResponse


        // ------------------------------------------------------------------------
        // Event for response data
        // ------------------------------------------------------------------------
        private void MBmaster_OnResponseData(ushort ID, byte unit, byte function, byte[] values)
        {
            // ------------------------------------------------------------------
            // Seperate calling threads
            //if (this.InvokeRequired)
            //{
             //   this.BeginInvoke(new Master.ResponseData(MBmaster_OnResponseData), new object[] { ID, unit, function, values });
              //  return;
           // }

            // ------------------------------------------------------------------------
            // Identify requested data
            switch (ID)
            {
                case 1:
                    SingletonLogger.AddToLog("Read coils", LogType.Info, LogModule.COM);
                    
                    break;
                case 2:
                    //grpData.Text = "Read discrete inputs";
                    //data = values;
                   
                    break;
                case 3:
                    SingletonLogger.AddToLog("Read holding register", LogType.Info, LogModule.COM);

                    //short[] sdata = new short[(int)Math.Ceiling(Convert.ToDouble(values.Length / 2))];
                    
                    Buffer.BlockCopy(values, 0, _RegisterData, 199, values.Length);

                    // _RegisterData = values;
                    
                    break;
                case 4:
                    //grpData.Text = "Read input register";
                   // data = values;
                    
                    break;
                case 5:
                    SingletonLogger.AddToLog("Write single coil", LogType.Info, LogModule.COM);
                    break;
                case 6:
                    SingletonLogger.AddToLog("Write multiple coils", LogType.Info, LogModule.COM);
                    break;
                case 7:
                    SingletonLogger.AddToLog("Write single register", LogType.Info, LogModule.COM);
                    break;
                case 8:
                    SingletonLogger.AddToLog("Write multiple register", LogType.Info, LogModule.COM);
                    break;
            }
        }

        // ------------------------------------------------------------------------
        // Modbus TCP slave exception
        // ------------------------------------------------------------------------
        private void MBmaster_OnException(ushort id, byte unit, byte function, byte exception)
        {
            string exc = "Modbus says error: ";
            switch (exception)
            {
                case Master.excIllegalFunction: exc += "Illegal function!"; break;
                case Master.excIllegalDataAdr: exc += "Illegal data adress!"; break;
                case Master.excIllegalDataVal: exc += "Illegal data value!"; break;
                case Master.excSlaveDeviceFailure: exc += "Slave device failure!"; break;
                case Master.excAck: exc += "Acknoledge!"; break;
                case Master.excGatePathUnavailable: exc += "Gateway path unavailbale!"; break;
                case Master.excExceptionTimeout: exc += "Slave timed out!"; break;
                case Master.excExceptionConnectionLost: exc += "Connection is lost!"; break;
                case Master.excExceptionNotConnected: exc += "Not connected!"; break;
            }

            SingletonLogger.AddToLog("Modbus slave exception", LogType.Error, LogModule.COM);
        }

        #endregion

        #region Get / Set

        // ------------------------------------------------------------------------
        // Modbus TCP Connection Ip address
        // ------------------------------------------------------------------------
        private string _MoudbusIPAddress = "192.168.1.23";
        public string MoudbusIPAddress
        {
            get
            {

                return _MoudbusIPAddress;
            }
            set
            {
                _MoudbusIPAddress = value;
            }

        }


        // ------------------------------------------------------------------------
        // Modbus TCP Connection port
        // ------------------------------------------------------------------------
        private ushort _MoudbusPort = 502;
        public ushort MoudbusPort
        {
            get
            {

                return _MoudbusPort;
            }
            set
            {
                _MoudbusPort = value;
            }

        }

        // ------------------------------------------------------------------------
        // Modbus TCP Connection status
        // ------------------------------------------------------------------------
        private bool _IsConnected;
        public bool IsConnected
        {
            get
            {

                return _IsConnected;
            }

        }

        // ------------------------------------------------------------------------
        // Preformence info update thread Returns ms time 
        // ------------------------------------------------------------------------
        private int[] _PreformanceTimeMs = new int[5];
        public int PreformanceTimeMs
        {
            get
            {
                return (_PreformanceTimeMs.Sum()/5);
            }
        }


        // ------------------------------------------------------------------------
        // Data object with all plc coil`s
        // ------------------------------------------------------------------------
        private byte[] _CoilsData = new byte[128]; // 1024 bits in MC0-1023
        public byte[] CoilsData
        {
            get 
            {
                return _CoilsData;
            }
        }

        // ------------------------------------------------------------------------
        // Data object with all plc coil`s
        // ------------------------------------------------------------------------
        private Int16[] _RegisterData = new Int16[2048]; // 2048 word signed 16-bit in MHR0-2048
        public Int16[] RegisterData
        {
            get
            {
                return _RegisterData;
            }
        }

        #endregion
    }
}