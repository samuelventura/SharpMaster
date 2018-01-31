using System;
using SharpModbus;

namespace SharpMaster
{
	public interface IoControl
	{
		SerializableMap GetSettings();
		void SetMaster(ModbusMaster master);

        void Perform();
	}
}
