
using System;
using SharpTools;
using SharpModbus;

namespace SharpMaster
{
	/// <summary>
	/// Description of IoControl.
	/// </summary>
	public interface IoControl
	{
		SerializableMap GetSettings();
		void SetMaster(ModbusMaster master);
	}
}
