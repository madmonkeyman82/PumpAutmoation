using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using PumpAutomation;
using PumpAutomation.PLC;


namespace PumpAutomation
{
    class ModbusModule_
    {
       
        #region Constructor / Deconstructor

        //private static readonly Lazy<Modbus> lazy = new Lazy<Modbus>(() => new Modbus());
        //public static Modbus Instance { get { return lazy.Value; } }

        //Constructor
        public ModbusModule_(bool tcp)
        {
            SingletonLogger.AddToLog("Loading Core", LogType.Info, LogModule.CORE);
            _tcpMode = tcp;

            if (tcp)
            {
               // modbusControlTCP = new ModbusTcpControl();
               // modbusControlTCP.ConnectTimeout = 1000;
               // modbusControlTCP.ResponseTimeout = 1000;
                LoadModbusTcp();
                SetupUpModbusModuleTcp();
            }          
            
            SingletonLogger.AddToLog("Core Loaded", LogType.Info, LogModule.CORE);
        }

        //Deconstructor
        ~ModbusModule_()
        {

        }

        #endregion

        #region Private Variables
        //Private Variables

        //String`s


        // Serial variables
        private string _ComPort;
        private int _Baudrate;
        private System.IO.Ports.Parity _Parity;
        private System.IO.Ports.StopBits _Stopbits;
        private int _Databits;
        private string _Protocol;
        private int _TimeOut;

        // Ethernet Variables
        private string _sPlcIPAddress;
        private int _iPlcPort;
        private int _iTimeout;

        // Thread`s


        // bool`s
        private bool _bModbusTCPMode = false;
        private bool IsCommunicationBusy { get; set; }
        private bool _tcpMode = false;

        // Communication Modules
          private ModbusTcpControl modbusControlTCP;





        // Communication Modules
        // public Modbus moudbusrtu = new Modbus();
        //public Plc PlcModule = new Plc();

        // Logger Variable
        private Logger SingletonLogger = Logger.Instance;
        
 
        #endregion

        #region Public Variables
        //Public Variables


        #endregion

        #region Private Functions


        private void LoadModbusTcp()
        {
            _sPlcIPAddress = Properties.Settings.Default.PlcIP;
            _iPlcPort = Properties.Settings.Default.PlcIpPort;
            _iTimeout = 3000;
        }

        private void SetupUpModbusModuleTcp()
        {
            modbusControlTCP.ConnectTimeout = _iTimeout;
            //modbusControlTCP.Mode = ModbusTcp.Mode.TCP_IP;
            // modbusControlTCP.Connect(_sPlcIPAddress, _iPlcPort);
        }

        private void LoadModbusSerial()
        {
            #region Serial

            _ComPort = Properties.Settings.Default.comPort;
            _Baudrate = Properties.Settings.Default.Baudrate;
            _TimeOut = Properties.Settings.Default.TimeOut;
            _Protocol = Properties.Settings.Default.Protocol;
            _Databits = Properties.Settings.Default.Databits;

            switch (Properties.Settings.Default.Parity)
            {
                case "Even":
                    {
                        _Parity = System.IO.Ports.Parity.Even;
                        break;
                    }
                case "Mark":
                    {
                        _Parity = System.IO.Ports.Parity.Mark;
                        break;
                    }
                case "None":
                    {
                        _Parity = System.IO.Ports.Parity.None;
                        break;
                    }
                case "Odd":
                    {
                        _Parity = System.IO.Ports.Parity.Odd;
                        break;
                    }
                case "Space":
                    {
                        _Parity = System.IO.Ports.Parity.Space;
                        break;
                    }
            }

            switch (Properties.Settings.Default.Stopbits)
            {
                case "None":
                    {
                        _Stopbits = System.IO.Ports.StopBits.None;
                        break;
                    }
                case "One":
                    {
                        _Stopbits = System.IO.Ports.StopBits.One;
                        break;
                    }
                case "OnePointFive":
                    {
                        _Stopbits = System.IO.Ports.StopBits.OnePointFive;
                        break;
                    }
                case "Two":
                    {
                        _Stopbits = System.IO.Ports.StopBits.Two;
                        break;
                    }
            }
            #endregion
        }



        #endregion // Private Functions

        #region Public Functions
 

        #region PLC method`s

        #region General

        public bool Connect()
        {
       
               
                SingletonLogger.AddToLog("Connecting to PLC using " + _Protocol + " and Ethernet ", LogType.Info, LogModule.PLC);
                try
                {
                    if ((result = modbusControlTCP.Connect(_sPlcIPAddress, _iPlcPort)) == Modbus)
                    {
                        SingletonLogger.AddToLog("Connecting to PLC = " + result.ToString(), LogType.Info, LogModule.COM);
                        return true;
                    }
                    else if (result == ModbusTcp.Result.CONNECT_ERROR)
                    {
                        Disconnect();
                        SingletonLogger.AddToLog("Connecting to PLC faild = " + result.ToString(), LogType.Info, LogModule.COM);
                        return false;
                    }
                    else
                    {
                        return false;
                    }
                }
                catch (Exception e)
                {
                    SingletonLogger.AddToLog(e.ToString(), LogType.Error, LogModule.PLC);
                    SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString(), LogType.Error, LogModule.COM);
                    return false;
                }
            
        }

        private void Connect2()
        {
            
            ModbusTcp.Result result;
            result = modbusControlTCP.Connect(_sPlcIPAddress, _iPlcPort);
        }

        public void Disconnect()
        {
            if (_tcpMode)
            {
                try
                {
                    modbusControlTCP.Close();               
                }
                catch (Exception e)
                {
                    SingletonLogger.AddToLog(e.ToString(), LogType.Error, LogModule.PLC);
                    SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString(), LogType.Error, LogModule.COM);       
                }
            }
        }

        public string GetLastErrorString()
        {
           return modbusControlTCP.GetLastErrorString();
        }

        public void test()
        {
            //  Read Coils
            //  Result = modbusControll.ReadCoilsFC1(1, address, (ushort)Coils.Length, Coils); // OBS OBS !!!!!!!!!!!!!
            //  Read V
            //  Result = modbusControll.ReadHoldingRegistersFC3(1, addess, 1, VMemValue);
           bool[] CoilsBuffer = new bool[30]; 

           ModbusTcp.Result Result;
          // Result = modbusControlTCP.ReadCoils(1, 0, 30, CoilsBuffer);
           Result = modbusControlTCP.WriteSingleCoil(1, 0, true);
           // WriteToRegister(0, 50);
           // WriteToRegister(1, 100);
           
        }

        #endregion // General

        #region PLC Read

        #region Coils



        #region Ethernet TCP/IP


        /// <summary>
        /// Read Bool status of single coil by ushort address
        /// </summary>
        /// <param name="adresse"></param>
        /// <returns></returns>
        public bool GetCoilStatus(ushort address)
        {
            Connect2();
            bool _Status = false;

            bool[] Coils = new bool[30];
            ModbusTcp.Result Result;
            Result = modbusControlTCP.ReadCoils(1, 0, 30, Coils); // OBS OBS !!!!!!!!!!!!!
            // Result = modbusControll.ReadCoilsFC1(1, address, 1, Coils); 
           
            //Result = modbusControll.ReadCoils(1, 0, 10, Coils);
            if (Result == ModbusTcp.Result.SUCCESS)
            {
                _Status = Coils[0];
                return _Status;
            }
            else
            {
                SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString() + _Protocol, LogType.Error, LogModule.COM);
            }

            return _Status;
        }

        /// <summary>
        /// Read Bool status of range of coil`s 
        /// </summary>
        /// <param name="adresse">This is the start adress of the coils</param>
        /// <param name="Coils">Bool Array to hold the coils </param>
        /// <returns></returns>
        public bool GetCoils(ushort address , ref bool[] Coils)
        {
            Connect2();
            ModbusTcp.Result Result;
            
            Result = modbusControlTCP.ReadCoils(1, address, (ushort)Coils.Length, Coils); 

            if (Result == ModbusTcp.Result.SUCCESS)
            {
                return true;
            }
            else
            {
                SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString() + _Protocol, LogType.Error, LogModule.COM);
            }

            return false;
        }

        #endregion

        #endregion // Coils

        #region Holding registers


        #region Ethernet/IP

        /// <summary>
        /// Read Word 16bit from ushort address
        /// </summary>
        /// <param name="Ctype"></param>
        /// <returns></returns>
        public short ReadWordValue(ushort addess)
        {
            Connect2();
            while (IsCommunicationBusy)
            {
                Thread.Sleep(10);
            }
            IsCommunicationBusy = true;

            ModbusTcp.Result Result;
            short[] VMemValue = new short[1];

            Result = modbusControlTCP.ReadHoldingRegisters(1, addess, 1, VMemValue);

            if (Result == ModbusTcp.Result.SUCCESS)
            {

                IsCommunicationBusy = false;
                return VMemValue[0];
            }
            else
            {
                SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString() + _Protocol, LogType.Error, LogModule.COM);
            }

            IsCommunicationBusy = false;
            return VMemValue[0];
        }

        public short ReadWordValue(PumpAutomation.PLC.VPlcTime Vtype)
        {

            while (IsCommunicationBusy)
            {
                Thread.Sleep(10);
            }
            IsCommunicationBusy = true;

            short[] VMemValue = new short[1];
            ModbusTcp.Result Result;
            ushort addess = (PlcCovnertions.GetVariableAddresse(Vtype));

            Result = modbusControlTCP.ReadHoldingRegisters(1, addess, 1, VMemValue);

            if (Result == ModbusTcp.Result.SUCCESS)
            {

                IsCommunicationBusy = false;
                return VMemValue[0];
            }
            else
            {
                SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString() + _Protocol, LogType.Error, LogModule.COM);
            }

            IsCommunicationBusy = false;
            return VMemValue[0];
        }

        /// <summary>
        /// Read Word 16bit from ushort address
        /// </summary>
        /// <param name="address"> Start address</param>
        /// <param name="Registers">How Many registers to read</param>
        /// <returns></returns>
        public bool ReadWordValueS(ushort address, ushort quantity, ref short[] Registers)
        {
            Connect2();
            while (IsCommunicationBusy)
            {
                Thread.Sleep(10);
            }
            IsCommunicationBusy = true;

            ModbusTcp.Result Result;

            Result = modbusControlTCP.ReadHoldingRegisters(1, address, quantity, Registers);
                
            if (Result == ModbusTcp.Result.SUCCESS)
            {

                IsCommunicationBusy = false;
                return true;
            }
            else
            {
                SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString() + _Protocol, LogType.Error, LogModule.COM);
            }

            IsCommunicationBusy = false;
            return false;

        }

        #endregion // Ethernet/IP

        #endregion // holding registers

        

        #endregion // PLC Read

        #region PLC Write

        #region Coils

        #region Ethernet/TCP

        /// <summary>
        /// Write to Coil register by ushort address With value either true / false
        /// </summary>
        /// <param name="adresse"></param>
        /// <param name="NewCoilStatus"></param>
        /// <returns></returns>
        public bool WriteToCoil(ushort address, bool NewCoilStatus)
        {
            Connect2();
            bool _Status = false;
            ModbusTcp.Result Result;
            Result = modbusControlTCP.WriteSingleCoil(1, address, NewCoilStatus);

            if (Result == ModbusTcp.Result.SUCCESS)
            {
                _Status = true;
                return _Status;
            }
            else
            {
                SingletonLogger.AddToLog("Error in plc --> com ", LogType.Error, LogModule.PLC);
                SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString(), LogType.Error, LogModule.COM);
            }
            return _Status;
        }

        #endregion //Ethernet/TCP

        #endregion // Coils

        #region Holding Registers

        #region  Ethernet/TCP
        
        /// <summary>
        /// Write to Holding register ex:MHR1, MHR2 by short address with value either 16bit value
        /// </summary>
        /// <param name="adresse"></param>
        /// <param name="SetValue"></param>
        /// <returns></returns>
        public bool WriteToRegister(ushort address, short SetValue)
        {
            Connect2();
            bool _Status = false;
            ModbusTcp.Result Result;

            Result = modbusControlTCP.WriteSingleRegister(1, address, SetValue);

            if (Result == ModbusTcp.Result.SUCCESS)
            {
                _Status = true;
                return _Status;
            }
            else
            {
                SingletonLogger.AddToLog("Error in plc --> com ", LogType.Error, LogModule.PLC);
                SingletonLogger.AddToLog(modbusControlTCP.GetLastErrorString(), LogType.Error, LogModule.COM);
            }

            return _Status;
        }

        #endregion



        #endregion // Holding Registers

        #endregion // PLC Write

        #endregion // PLC method`s

        #endregion // Public Functios

        
        #region Get / Set

        private string _MoudbusIPAddress;
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

        private int _CoilsInPlc = 0;
        public int CoilsInPlc
        {
            get
            {
                return _CoilsInPlc;
            }
            
            set
            {
                _CoilsInPlc = value;
            }
        }

    }


        #endregion // Get / Set

    }

