using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation.PLC
{
    static class PlcCovnertions
    {

        public static ushort GetVariableAddresse(CPlcVariableDoMore _ContactVariable, bool OctalAdressing = true)
        {
            if (OctalAdressing)
            {
                int test = (int)_ContactVariable;
                string test2 = test.ToString();
                int _decValue = ConvertOctalAddressToDec(test2);
                int firstlvalue;
                firstlvalue = _decValue + (int)MemoryTypeDirectLogic.ControlRelaysC - (int)1;

                ushort secondvalue = (ushort)firstlvalue;

                return secondvalue;
            }
            else
            {
                int _decValue = (int)_ContactVariable;

                int firstlvalue;
               firstlvalue = _decValue + (int)MemoryTypeDoMore.ControlRelaysC - 1;
               // firstlvalue = _decValue + (int)MemoryTypeDoMore.ControlRelaysC;

                ushort secondvalue = (ushort)firstlvalue;

                return secondvalue;
            }
        }


        public static ushort GetVariableAddresse(VPlcVariable _VVariable, bool OctalAdressing = true)
        {
            if (OctalAdressing)
            {
                int test = (int)_VVariable;
                string test2 = test.ToString();
                int _decValue = ConvertOctalAddressToDec(test2);

                int firstlvalue;
                //firstlvalue = _decValue + (int)MemoryType.V_MemoryUserData1400 - (int)1;
                firstlvalue = _decValue + 1;

                ushort secondvalue = (ushort)firstlvalue;

                return secondvalue;
            }
            else
            {
                int _decValue = (int)_VVariable;

                int firstlvalue;
                firstlvalue = _decValue + (int)MemoryTypeDoMore.V_MemoryUserData - 1;
               

                ushort secondvalue = (ushort)firstlvalue;

                return secondvalue;
            }
        }

        public static ushort GetVariableAddresse(VPlcTime _VVariable)
        {

                int _decValue = (int)_VVariable;

                int firstlvalue;
                firstlvalue = _decValue + (int)MemoryTypeDoMore.V_MemoryUserData - 1;


                ushort secondvalue = (ushort)firstlvalue;

                return secondvalue;   
        }



        /*Example 4: C54
            Find the Modbus address for
            Control Relay C54.
            1. Find Control Relays in the table.
            2. Convert C54 into decimal (44).
            3. Add the starting address for the range (3073).
            4. Use the Modbus data type from the table.
         * 
         */
        private static int ConvertOctalAddressToDec(string Octalvalue)
        {
            int calulatedvalue = Convert.ToInt32(Octalvalue, 8);

            return calulatedvalue;
        }
    }
}
