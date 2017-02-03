using System;
using System.Collections.Generic;
using SharpTools;
using SharpToolsUI;

namespace SharpMaster
{
	public class PersistedSettings
	{
		public string SerialPortName;
		public string TcpIP;
		public int TcpPort;
		public SerialSettings Serial = new SerialSettings();
		public List<SerializableMap> Controls = new List<SerializableMap>();
	}
}
