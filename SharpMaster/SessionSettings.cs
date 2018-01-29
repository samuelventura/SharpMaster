using System.Collections.Generic;
using SharpMaster.Tools;

namespace SharpMaster
{
	public class SessionSettings
	{
        public SessionSettings()
        {
            Controls = new List<SerializableMap> ();
            Serial = new SerialSettings();
            Name = "New Session";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string SerialPortName { get; set; }
        public string TcpIP { get; set; }
        public int TcpPort { get; set; }
        public SerialSettings Serial { get; set; }
        public List<SerializableMap> Controls { get; set; }
    }
}
