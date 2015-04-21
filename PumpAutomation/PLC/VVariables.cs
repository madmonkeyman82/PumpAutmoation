using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation.PLC
{

    public enum VPlcVariable
    {
        MBFlow1 = 100,          // Pump 1 15 - 300 l/Min 
        MBPressure1 = 101,      // Pump 1 0 - 400 Bar
        MB_T_Filter1 = 102,     // Pump 1 0 - 50 -   Bar = MB_T_Filter1 / 10
        MBConSens4 = 103,       // 4uM ISO class
        MBConSens6 = 104,       // 6uM ISO class
        MBConSens14 = 105,      // 14uM ISO class
        MBConSens21 = 106,      // 21uM ISO class
        MBConSensStaus = 107,   // Status of Contamination Sensor 5 = OK, 6 = Device Error/CS not ready, 7 = Low Flow 8 = ISO <9.<8.<7, 9 = No measured value
        MBConSensmA = 108,      // MBConSensmA the mA from the sensor
        MBFlow2 = 109,          // Pump 2 15 - 300 l/Min
        MBPressure2 = 110,      // Pump 2 0 - 400 Bar
        MBWaterContent = 111,   // Water contamination 0 - 100 %
        MBOilTemp = 112,        // OilTemp at Contamination sensor
        MB_TFilter2 = 113,      // Pump 2 0 - 50 -   Bar = MB_T_Filter2 / 10
        MBRFilter = 114,        // Pressure on retur filter 0 - 50 (bar = / 10)


        MBFlowRegulator1SetPoint = 200, //SetPoint of flow regulator 1  Range 0 - 100%
        MBFlowRegulator2SetPoint = 201, //SetPoint of flow regulator 2  Range 0 - 100%

    }

    public enum VPlcTime
    {
        PlcHour = 300, // The PLC hour
        PLCMin = 301, // The PLC Minute
        PLCSecond = 302, // The PLC Second
    }
}
