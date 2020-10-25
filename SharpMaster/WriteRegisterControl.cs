
using System;
using System.Windows.Forms;
using SharpModbus;

namespace SharpMaster
{
	public partial class WriteRegisterControl : UserControl, IoControl
	{
		private readonly ControlContext context;
		
		public WriteRegisterControl(ControlContext context, SerializableMap settings)
		{
			this.context = context;
			
			InitializeComponent();
			
			numericUpDownSlaveAddress.Value = settings.GetNumber("slaveAddress", 0);
			numericUpDownRegisterAddress.Value = settings.GetNumber("startAddress", 0);
			numericUpDownRegisterValue.Value = settings.GetNumber("registerValue", 0);
			if (comboBoxFunctionCode.SelectedIndex < 0)
				comboBoxFunctionCode.SelectedIndex = 0;
		}
		
		public SerializableMap GetSettings()
		{
			var settings = new SerializableMap();
			settings.AddAny("slaveAddress", numericUpDownSlaveAddress.Value);
			settings.AddAny("startAddress", numericUpDownRegisterAddress.Value);
			settings.AddAny("registerValue", numericUpDownRegisterValue.Value);
			return settings;
		}
		
		public void Enable(bool enabled)
		{
			buttonWrite.Enabled = enabled;        	
        }

        public void Perform()
        {
        }

        void ButtonWriteClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var startAddress = (ushort)numericUpDownRegisterAddress.Value;
			var registerValue = (ushort)numericUpDownRegisterValue.Value;
			context.Io((master) => {
                master.WriteRegister(slaveAddress, startAddress, registerValue);
			});
		}
	}
}
