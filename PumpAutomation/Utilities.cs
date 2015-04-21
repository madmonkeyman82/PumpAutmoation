using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation
{
    static class Utilities
    {

        /// <summary>
        /// Converts Boolean value to int true = 1 false = 0 error = 99
        /// </summary>
        /// <param name="boolvalue"></param>
        /// <returns></returns>
        public static int BoolToInt(this bool boolvalue)
        {
            switch (boolvalue)
            {
                case true:
                    return 1;

                case false:
                    return 0;
                default:

                    return 99;
            }            
        }

    }

    //enum LogType { Error, Info, Alarm, Warning };
    //struct MessageToLog
    //{
    //    public DateTime datetime;
    //    public string message;
    //    public LogType logtype;
    //}
}
