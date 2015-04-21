using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation
{

        #region enums / struct
        public enum SensorType { Press1, Press2, Flow1, Flow2, Temp1, Temp2, TFilter1, TFilter2, RFilter, WaterContent, _4um, _6um, _14um, _21um,   }

        public struct SensorToDB
        {
            public DateTime datetime;
            public SensorType Sensor;
            public float Value;
            public string Costumer;
        }
        #endregion

        
  
}
