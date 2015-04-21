using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation.PLC
{

    public enum CPlcVariable
    {
        MakroSimON = 13,                //MakroSimON()       'Sender SIMULATOR ON kommando C13 til Master
        MakroSimOFF = 13,               //MakroSimOFF()       'Sender SIMULATOR OFF kommando C13 til Master
        MakroMYK = 460,                 //MakroMYK()       'Sender MYK Opp -  Ned kommando C112 til Master
        MakroAutoStartStopp = 670,      //MakroAutoStartStopp()       'Sender Auto SS kommando C464 til Master
        MakroStasjon = 464,             //MakroStasjon()       'Sender Auto Stasjon kommando C464 til Master   
        MakroAggregat= 467,             // MakroAggregat()       'Sender Auto Aggregat kommando C467 til Master
        MakroSimulator = 67,            //MakroSimulator()       'Sender Simulator kommando C67 til Master
        MakroFinregulering_Av_På = 414, //MakroFinregulering_Av_På()       'Sender Finregulering kommando C414 til Master
       

        
        A1_Start = 117,            //A1_Start()            'Starter Aggregat 1
        A1_Standby = 211,          //A1_Standby()           'Endrer A1 Standby Status
        A1_Stopp = 117,            //A1_Stopp()             'Stopper Aggregat 1  
        A1_Port = 321,             //A1_Port()              'Spesifiserer Port A eller B Aggregat 1 
        A1_Bypass = 324,           //A1_Bypass()            'Disable Bypass Aggregat1
        Bypass_1_INNE = 1111,     // Bypass 1 INNE
                                    /*
                                     * ByPass status text  = (A1_Bypass * 2) + Bypass_1_INNE
                                        0	Passiv
                                        1	Aktiv
                                        2	Slått Av
                                        3	FEIL
                                     * 
                                     */

        TF1_Warning = 1100,          //TF1-Warning	C1100	=dsdde|a!'c1100:b' =IF(c1100=1;"ALARM";"ok")


        A2_Start = 127,            //A2_Start()            'Starter Aggregat 2
        A2_Standby = 221,          //A2_Standby()           'Endrer A2 Standby Status
        A2_Stopp = 127,            //A2_Stopp()             'Stopper Aggregat 2  
        A2_Port = 322,             //A2_Port()              'Spesifiserer Port A eller B Aggregat 2 
        A2_Bypass = 325,           //A2_Bypass()            'Disable Bypass Aggregat2

        A3_Start = 137,            //A3_Start()               'Starter Aggregat 3


        SimulationMode = 30,        // SimulationMode 
        



    }

    public enum CPlcVariableDoMore
    {
        MBPump1Start = 1,        //This is to start & stop the pump.
        MBPump1On = 2,           //This is true then pump is running.
        Unused1 = 3,           //Unused
        Unused2 = 4,           //Unused
        Unused3 = 5,           //Unused
        Unused4 = 6,           //Unused
        Unused5 = 7,           //Unused
        Unused6 = 8,           //Unused
        Unused7 = 9,           //Unused
        MBSimulationMode = 10,    //This is to activate simulation mode.. no actual output from the plc will happen. numbers are randomly generated.
        MBWatchDog = 11,        // WatchDog bit is always high when plc is on and connected.
        MBIsAlive = 12,         // Watchdog bit that toggles every second.
    }
}
