using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation.PLC
{
    public enum MemoryTypeDirectLogic
    {
        InputsX = 2048,
        SpecialRelaysSP0 = 3072,
        SpecialRelaysSP320 = 3280,
        OutputsY = 2048,
        ControlRelaysC = 3072,
        TimerContactsT = 6144,
        CounterContactsCT = 6400,
        StageStatusBitsS = 5120,
        TimerCurrectValuesV = 0,
        CounterCurrectValuesV = 512,
        V_MemoryUserData1400 = 768,
        V_MemoryUserData10000 = 4096,
        v_MemorySystemData = 3480
    }

    public enum MemoryTypeDoMore
    {
        //Logically, Do-more CPUs as a Modbus slave is very easy.  
        // As a Modbus slave, there are no instructions to enter. 
        // There is no mapped memory.  
        // The Modbus protocol supports 4 data types, Modbus (discrete) Inputs, Modbus Coils, Modbus Input Registers,
        // and Modbus Holding Registers.
        // Do-more’s memory configuration has 4 predefined Modbus data blocks, MI bits, MC bits, MIR WORDs, and MHR WORDs.  
        // Remote Masters can read/write to these "Modbus" data blocks, 
        // but they will never have direct access to the Do-more I/O registers (or any other data-blocks).  
        // Just write some ladder code that references whatever Modbus elements the Master is accessing,
        // using only the "offset" part of the address in the Do-more Modbus ID.
        // 
        //• Modbus Input bit 10003 would be bit MI3 
        //• Modbus Coil bit 00011 would be MC11 
        //• Modbus Input Register 30028 would be MIR28 
        //• Modbus Holding Register 40009 would be MHR9 



        InputsX = 0,
        ControlRelaysC = 0,
        V_MemoryUserData = 0,
    }
}
