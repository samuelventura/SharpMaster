using System.Collections.Generic;
using SharpMaster.Tools;
using SharpTabs;

namespace SharpMaster
{
	public class MasterDto : SessionDto
	{
        public MasterDto()
        {
            Controls = new List<SerializableMap> ();
            Serial = new SerialSettings();
            Name = "New Session";
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public string SerialPortName { get; set; } = "COM1";
        public string TcpIP { get; set; } = "127.0.0.1";
        public int TcpPort { get; set; } = 8000;
        public SerialSettings Serial { get; set; }
        public List<SerializableMap> Controls { get; set; }
    }
}
