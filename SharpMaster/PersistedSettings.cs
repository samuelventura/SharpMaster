using System;
using System.Collections.Generic;
using SharpTools;
using SharpToolsUI;

namespace SharpMaster
{
	public class PersistedSettings
	{
		public string Name;
		public string ClientHost;
		public int ClientPort;
		public SerialSettings Serial = new SerialSettings();
		public List<SerializableMap> Controls = new List<SerializableMap>();
	}
}
