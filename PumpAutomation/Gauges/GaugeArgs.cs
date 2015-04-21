using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PumpAutomation
{
	
	public class GaugeArgs: EventArgs
	{
		//private string message;
        private float sPValue;

        //public GaugeArgs(string message)
        public GaugeArgs(float sPValue)
		{ 
			//this.message=message;
            this.sPValue = sPValue;
		}
		
	    // This is a straightforward implementation for declaring a public
		// field
		//public string Message
        public float SPValue
		{
			get
			{
				return sPValue;
			}
		}
	}
}