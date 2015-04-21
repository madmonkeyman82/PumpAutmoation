using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation
{
        #region enums / struct
        public  enum LogType { Error, Info, Alarm, Warning };
        public  enum LogModule { GUI, PLC, COM, LOG, CORE, DB };

        public struct MessageToLog
        {
            public DateTime datetime;
            public string message;
            public LogType logtype;
            public LogModule logmodule;
        }
        #endregion
}
