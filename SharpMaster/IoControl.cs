using System;

namespace SharpMaster
{
	public interface IoControl
	{
		SerializableMap GetSettings();
		void Enable(bool enabled);
        void Perform();
	}
}
