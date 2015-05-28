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

        // ------------------------------------------------------------------------
        // Constructor
        // ------------------------------------------------------------------------
        public Modbus()
        {
            StartUpdateModbus();
        }


        // ------------------------------------------------------------------------
        // Deconstructor
        // ------------------------------------------------------------------------
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

        // ------------------------------------------------------------------------
        // Methode used initziate new worker thread
        // ------------------------------------------------------------------------
        private void StartUpdateModbus()
        {
            _tThreadUpdateModbus = new Thread(new ThreadStart(this.ThreadUpdateModbus));
            _tThreadUpdateModbus.IsBackground = true;
            _tThreadUpdateModbus.Name = "MODBUS UPDATE THREAD";
            _tThreadUpdateModbus.Start();

            /* Debug
          // Connect(); // just for testing Modbus- 

          // Thread.Sleep(10);

          // WriteCoil((ushort)10, true);
            */
        }

        // ------------------------------------------------------------------------
        // Methode used for worker thread
        // ------------------------------------------------------------------------
        private void ThreadUpdateModbus()
        {
            while (!_IsClosing) 
            {
                int PrefCounter = 0;

                while (IsConnected)
                {
                    int MsNow = DateTime.Now.Millisecond;

                    if (MBmaster.connected)
                    {
                        try
                        {
                            ReadCoils();
                            ReadHoldRegister();
                        }
                        catch (Exception ex)
                        {
                            SingletonLogger.AddToLog("Error in modbus updatethread :" + ex.Message, LogType.Error, LogModule.COM);
                        }         
                    }
                    else
                    {
                        _IsConnected = false;
                    }

                    _PreformanceTimeMs[PrefCounter] = Math.Abs((DateTime.Now.Millisecond - MsNow));

                    if (PrefCounter >= 49)
                    { PrefCounter = 0; }
                    else
                    { PrefCounter++; }
                    

                } // end while _IsConnected
                Thread.Sleep(20);
            } // end while _IsClosing
        }

        #endregion  
        
        #region Modbus General

        // ------------------------------------------------------------------------
        // Connect
        // ------------------------------------------------------------------------
        public bool Connect()
        {
            if (!IsConnected)
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
        public bool Disconnect()
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
            _CoilsData = new BitArray(byteCoilRegisterTemp);
            //Buffer.BlockCopy(byteCoilRegisterTemp, 0, _CoilsData, 0, byteCoilRegisterTemp.Length);
        }

        // ------------------------------------------------------------------------
        // Read holding register
        // ------------------------------------------------------------------------
        private void ReadHoldRegister()
        {
            ushort ID = 3;
            byte UNIT = 0;

            byte[] byteHoldingRegisterTemp1 = new byte[100];
            byte[] byteBigHoldingReisterTemp = new byte[4096];
            //-------
            //Read all Holding Registers in sequence and block copy in to int16 register

            //0 - 99
            MBmaster.ReadHoldingRegister(ID, UNIT, (ushort)0, (ushort)100, ref byteHoldingRegisterTemp1);
            Buffer.BlockCopy(byteHoldingRegisterTemp1, 0, byteBigHoldingReisterTemp, 0, byteHoldingRegisterTemp1.Length);

            //100 - 200
            MBmaster.ReadHoldingRegister(ID, UNIT, (ushort)100, (ushort)100, ref byteHoldingRegisterTemp1);
            Buffer.BlockCopy(byteHoldingRegisterTemp1, 0, byteBigHoldingReisterTemp, 200, byteHoldingRegisterTemp1.Length);
           
            //200 - 300
            MBmaster.ReadHoldingRegister(ID, UNIT, (ushort)200, (ushort)100, ref byteHoldingRegisterTemp1);
            Buffer.BlockCopy(byteHoldingRegisterTemp1, 0, byteBigHoldingReisterTemp, 400, byteHoldingRegisterTemp1.Length);

            //300 - 400
            MBmaster.ReadHoldingRegister(ID, UNIT, (ushort)300, (ushort)100, ref byteHoldingRegisterTemp1);
            Buffer.BlockCopy(byteHoldingRegisterTemp1, 0, byteBigHoldingReisterTemp, 600, byteHoldingRegisterTemp1.Length);
        
            // Swap littlendian -> bigendian ??
            SwapRegisterByteArray(byteBigHoldingReisterTemp, 1);
        }


        #endregion

        #region Modbus Write

        /// <summary>
        // ------------------------------------------------------------------------
        // Write a single bit to Coil address
        // ------------------------------------------------------------------------
        /// <param name="address">Coil number to set 1 - 1024</param>
        /// <param name="status">True or False</param>
        /// <returns>IP port of plc</returns>
        /// </summary>
        public bool WriteCoil(ushort address, bool status)
        {
            ushort ID = 1;
            byte UNIT = 0;
            byte[] _NewStatus = new byte[1];

            if (status == true)
            {
                 _NewStatus[0] = 1 ;
            }
            else if (status == false)
            {
                 _NewStatus[0] = 0 ;
            }


            ushort _address = Convert.ToUInt16((int)address - 1);

            bool success = false;
            byte[] ReturnStatus = new byte[1];


            MBmaster.WriteMultipleCoils(ID, UNIT, _address, (ushort)1, _NewStatus, ref ReturnStatus);

            if (ReturnStatus[1] == 1)
            {
                success = true;
            }
            return success;
        }

        #endregion

        #region Tools

        private void SwapRegisterByteArray(byte[] byteArray, int offsett)
        {
            try
            {
                if (byteArray.Length % 2 == 0 && byteArray.Length <= 4096 && offsett <= _RegisterData.Length)
                {
                    //byte[] arrbyteTemp = new byte[byteArray.Length];
                    int _iRegWordCounter = offsett;


                    for (int i = 0; i < byteArray.Length; i++)
                    {
                        _RegisterData[_iRegWordCounter] = BitConverter.ToInt16(new byte[2] { (byte)byteArray[i + 1], (byte)byteArray[i] }, 0);

                        i = i + 1;
                        _iRegWordCounter++;

                        if (i > (byteArray.Length / 2) | _iRegWordCounter > _RegisterData.Length)
                        {
                            break;
                        }
                    }
                }
                else
                {

                }
            }
            catch (Exception ex)
            {
                SingletonLogger.AddToLog("Error in modbus \"SwapRegisterByteArray\" :" + ex.Message, LogType.Error, LogModule.COM);
            }

        }

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

                case Master.excExceptionConnectionLost: exc += "Connection is lost!";
                    _IsConnected = false;
                    break;
                case Master.excExceptionNotConnected: exc += "Not connected!"; break;
            }

            SingletonLogger.AddToLog("Modbus slave exception", LogType.Error, LogModule.COM);
        }

        #endregion

        #region Get / Set


        /// <summary>
        // ------------------------------------------------------------------------
        // Modbus TCP Connection Ip address
        // ------------------------------------------------------------------------
        /// </summary>
        /// <returns>IP address of plc</returns>
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

        /// <summary>
        // ------------------------------------------------------------------------
        // Modbus TCP Connection port
        // ------------------------------------------------------------------------
        /// </summary>
        /// <returns>IP port of plc</returns>
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

        /// <summary>
        // ------------------------------------------------------------------------
        // Modbus TCP Connection status
        // ------------------------------------------------------------------------
        /// </summary>
        /// <returns>Status of TCP connection to plc</returns>
        private bool _IsConnected = false;
        public bool IsConnected
        {
            get
            {
                if (MBmaster == null)
                {
                    return false;   
                }
                else
                {
                    if (MBmaster.connected && _IsConnected)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

            }

        }

        /// <summary>
        // ------------------------------------------------------------------------
        // Preformence info update thread Returns ms time 
        // ------------------------------------------------------------------------
        /// </summary>
        /// <returns>Modbus preformancetime </returns>
        private int[] _PreformanceTimeMs = new int[50];
        public int PreformanceTimeMs
        {
            get
            {
                return (_PreformanceTimeMs.Sum()/_PreformanceTimeMs.Length);
            }
        }

        /// <summary>
        // ------------------------------------------------------------------------
        // Data object with all plc coil`s
        // ------------------------------------------------------------------------
        /// </summary>
        /// <returns>All coils</returns>
        private BitArray _CoilsData = new BitArray(1024); // 1024 bits in MC0-1023
        public BitArray CoilsData
        {
            get 
            {
                     //... bitArray is the BitArray instance
                    
                BitArray _CoilsDataTemp = new BitArray(1024);
                try
                {
                    if (_CoilsData != null)
                    {
                        for (int i = 0; i < _CoilsData.Count - 1; i++)
                        {
                            _CoilsDataTemp[i + 1] = _CoilsData[i];

                            if (i >= 1023)
                            {
                                break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    
                    /// error handel here
                }


                    _CoilsDataTemp[0] = false; // or true, whatever you want to shift in
                    return _CoilsDataTemp;
            }
        }

        /// <summary>
        // ------------------------------------------------------------------------
        // Data object with plc HoldingRegisters`s from 1 - 400
        // ------------------------------------------------------------------------
        /// </summary>
        /// <returns>HoldingRegisters 0 - 400</returns>
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