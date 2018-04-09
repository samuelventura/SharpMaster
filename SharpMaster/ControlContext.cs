using System;
using System.Threading;
using SharpModbus;
using SharpMaster.Tools;

namespace SharpMaster
{
	public class ControlContext
	{
		public IRunner ioRunner { get; set; }
		public IRunner uiRunner { get; set; }
		public ModbusMaster Master { get; set; }
    
        public void EnsureDelay()
        {
            //SELEC requires 20ms between calls
            Thread.Sleep(20);
        }
    }
}
