using System;
using SharpModbus;
using SharpTools;

namespace SharpMaster
{
	public class ControlContext
	{
		public IRunner ioRunner { get; set; }
		public IRunner uiRunner { get; set; }
		public ModbusMaster Master { get; set; }
	}
}
