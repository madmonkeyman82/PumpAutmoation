using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation.PLC
{
    public class PlcVariables
    {
         public PlcVariables()
         {

         }

        #region Private var`s

        #endregion

         #region Public var`s

            #region Bool`s
            
             #region DoMore

             public bool _MBPump1Start { get; set; }
             public bool _MBPump1On { get; set; }

        /*
             public bool _Unused1 { get; set; }
             public bool _Unused2 { get; set; }
             public bool _Unused3 { get; set; }
             public bool _Unused4 { get; set; }
             public bool _Unused5 { get; set; }
             public bool _Unused6 { get; set; }
             public bool _Unused7 { get; set; }
         */
             public bool _MBSimulationMode { get; set; }
             public bool _MBWatchDog { get; set; }
             public bool _MBIsAlive { get; set; }


             #endregion

            #endregion

            #region Word`s

           

             #region DoMore
             public short MBFlow1 { get; set; }
             public short MBPressure1 { get; set; }
             public short MB_T_Filter1 { get; set; }
             public short MB_T_Filter2 { get; set; }
             public short MBRFilter { get; set; }
             public short MBFlowRegulator1SetPoint { get; set; }
             public short MBFlowRegulator2SetPoint { get; set; }
             public short MBConSens4 { get; set; }
             public short MBConSens6 { get; set; }
             public short MBConSens14 { get; set; }
             public short MBConSens21 { get; set; }
             public short MBConSensStaus { get; set; }
             public short MBConSensmA { get; set; }
             public short MBFlow2 { get; set; }
             public short MBPressure2 { get; set; }
             public short MBWaterContent { get; set; }
             public short MBOilTemp { get; set; }

             public double T_Filter1
             {
                 get
                 {
                     double filter = MB_T_Filter1;
                            filter = filter / 10;
                     return filter;
                 }
             }

             public double T_Filter2
             {
                 get
                 {
                     double filter = MB_T_Filter2;
                            filter = filter / 10;
                     return filter;
                 }
             }

             public double R_Filter
             {
                 get
                 {
                     double filter = MBRFilter;
                            filter = filter / 10;
                     return filter;
                 }
             }
        

             #endregion
             #endregion

            #region String`s

            #region DoMore

            public string PlcTime {get; set;}
            #endregion
            #endregion

         #endregion
    }
}
