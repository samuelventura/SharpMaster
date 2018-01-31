
using System;
using System.Windows.Forms;
using SharpModbus;

namespace SharpMaster
{
	public partial class WriteFloatControl : UserControl, IoControl
	{
		private readonly ControlContext context;
		
		public WriteFloatControl(ControlContext context, SerializableMap settings)
		{
			this.context = context;
			
			InitializeComponent();
			
			numericUpDownSlaveAddress.Value = settings.GetNumber("slaveAddress", 0);
			numericUpDownRegisterAddress.Value = settings.GetNumber("startAddress", 0);
			numericUpDownFloatValue.Value = settings.GetNumber("floatValue", 0);
			if (comboBoxFunctionCode.SelectedIndex < 0)
				comboBoxFunctionCode.SelectedIndex = 0;
		}
		
		public SerializableMap GetSettings()
		{
			var settings = new SerializableMap();
			settings.AddAny("slaveAddress", numericUpDownSlaveAddress.Value);
			settings.AddAny("startAddress", numericUpDownRegisterAddress.Value);
			settings.AddAny("floatValue", numericUpDownFloatValue.Value);
			return settings;
		}
		
		public void SetMaster(ModbusMaster master)
		{
			context.Master = master;
			var enabled = (master != null);
			context.uiRunner.Run(() => {
				buttonWrite.Enabled = enabled;        	
			});
        }

        public void Perform()
        {
        }

        void ButtonWriteClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var startAddress = (ushort)numericUpDownRegisterAddress.Value;
			var floatValue = numericUpDownFloatValue.Value;
			context.ioRunner.Run(() => {
				if (context.Master != null) {
					var value = FloatToByteArray((float)floatValue);
					context.Master.WriteRegisters(slaveAddress, startAddress, value);
				}
			});
		}
		
		private ushort[] FloatToByteArray(float value)
		{
			var bytes = BitConverter.GetBytes(value);
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return new ushort[] {
				(ushort)((bytes[0] << 8 | bytes[1]) & 0xFFFF),
				(ushort)((bytes[2] << 8 | bytes[3]) & 0xFFFF),
			};
		}
	}
}
