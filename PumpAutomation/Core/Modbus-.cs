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

        private ModbusTCP.Master MBmaster;


        // Logger Variable
        private Logger SingletonLogger = Logger.Instance;

        #region Modbus General

        public Modbus()
        {
            test();
        }

        ~Modbus()
        {

        }

        // ------------------------------------------------------------------------
        // Connect
        // ------------------------------------------------------------------------
        public bool Connect()
        {
            try
            {
                // Create new modbus master and add event functions
                MBmaster = new Master(_MoudbusIPAddress, _MoudbusPort);
                MBmaster.OnResponseData += new ModbusTCP.Master.ResponseData(MBmaster_OnResponseData);
                MBmaster.OnException += new ModbusTCP.Master.ExceptionData(MBmaster_OnException);
                // Show additional fields, enable watchdog
                return true;
            }
            catch (SystemException ex)
            {
                SingletonLogger.AddToLog("Modbus connction error: " + ex.Message, LogType.Error, LogModule.COM);
            }
            return false;
        }

        #endregion


        #region Test
        private void test()
        {
            if (Connect())
            {
               // ReadCoils(1, 0, 1023);
                ReadHoldReg(1, 90, 128);
                
            }
        }

        #endregion  

        #region Modbus Read

        // ------------------------------------------------------------------------
        // Read coils
        // ------------------------------------------------------------------------
        private void ReadCoils(int unit, int startaddr, int length)
        {
            ushort ID = 1;

            byte UNIT = Convert.ToByte(unit);

            ushort STRADDR = Convert.ToUInt16(startaddr);

            ushort LENGTH = Convert.ToUInt16(length);

            MBmaster.ReadCoils(ID, UNIT, STRADDR, LENGTH);
        }

        // ------------------------------------------------------------------------
        // Read holding register
        // ------------------------------------------------------------------------
        private void ReadHoldReg(int unit, int startaddr, int length)
        {
            ushort ID = 3;
            byte UNIT = Convert.ToByte(unit);
            ushort STRADDR = Convert.ToUInt16(startaddr);
            ushort LENGTH = Convert.ToUInt16(length);

            MBmaster.ReadHoldingRegister(ID, UNIT, STRADDR, LENGTH);
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
                   _CoilsData = values;
                    
                    break;
                case 2:
                    //grpData.Text = "Read discrete inputs";
                    //data = values;
                   
                    break;
                case 3:
                    SingletonLogger.AddToLog("Read holding register", LogType.Info, LogModule.COM);
                     _RegisterData = values;
                    
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

        private bool _IsConnected;
        public bool IsConnected
        {
            get
            {

                return _IsConnected;
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
        private byte[] _RegisterData = new byte[4096]; // 2048 word signed 16-bit in MHR0-2048
        public byte[] RegisterData
        {
            get
            {
                return _RegisterData;
            }
        }

        #endregion
    }
}