using System;
using System.Collections.Generic;

namespace SharpMaster
{
	public class ControlSettings
	{
		public ControlSettings()
		{
			Config = new Dictionary<string, string>();
		}
		
		public string Type { get; set; }
		public Dictionary<string, string> Config { get; set; }
		
		public int GetInteger(string key)
		{
			return Convert.ToInt32(Config[key]);
		}
	}
}
