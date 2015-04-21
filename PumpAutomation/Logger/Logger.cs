using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation
{
     public sealed class Logger
     {
        #region Constructor / Deconstructor

        private static readonly Lazy<Logger> lazy = new Lazy<Logger>(() => new Logger());
        public static Logger Instance { get { return lazy.Value; } }

        //Constructor
        private Logger()
        {
            AddToLog("Logger Loaded", LogType.Info, LogModule.LOG);
        }

        //Deconstructor
        ~Logger()
        {

        }
        #endregion

        private List<MessageToLog> _Logg = new List<MessageToLog>();

        public List<MessageToLog> Logg { get { return _Logg; } }

        public void AddToLog(string TextToLog, LogType logtype, LogModule logmodule)
        {
            MessageToLog messagetolog;
            messagetolog.datetime = DateTime.Now;
            messagetolog.logtype = logtype;
            messagetolog.message = TextToLog;
            messagetolog.logmodule = logmodule;
            _Logg.Add(messagetolog);
        }

        //#region enums / struct
        //public  enum LogType { Error, Info, Alarm, Warning };
        //public  enum LogModule { GUI, PLC, COM, LOG, CORE };

        //public struct MessageToLog
        //{
        //    public DateTime datetime;
        //    public string message;
        //    public LogType logtype;
        //    public LogModule logmodule;
        //}
        //#endregion

        
    }
}
