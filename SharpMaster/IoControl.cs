using System;
using SharpTools;
using SharpModbus;

namespace SharpMaster
{
	public interface IoControl
	{
		SerializableMap GetSettings();
		void SetMaster(ModbusMaster master);
	}
}
