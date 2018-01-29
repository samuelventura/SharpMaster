
using System;
using System.Windows.Forms;
using SharpModbus;
using SharpMaster.Tools;

namespace SharpMaster
{
	public partial class ReadFloatControl : UserControl, IoControl
	{
		private readonly ControlContext context;
		
		public ReadFloatControl(ControlContext context, SerializableMap settings)
		{
			this.context = context;
			
			InitializeComponent();
			
			numericUpDownSlaveAddress.Value = settings.GetNumber("slaveAddress", 0);
			numericUpDownRegisterAddress.Value = settings.GetNumber("startAddress", 0);
			comboBoxFunctionCode.Text = settings.GetString("functionCode", "3 Holding");
			if (comboBoxFunctionCode.SelectedIndex < 0)
				comboBoxFunctionCode.SelectedIndex = 0;
		}
		
		public SerializableMap GetSettings()
		{
			var settings = new SerializableMap();
			settings.AddAny("slaveAddress", numericUpDownSlaveAddress.Value);
			settings.AddAny("startAddress", numericUpDownRegisterAddress.Value);
			settings.AddAny("functionCode", comboBoxFunctionCode.Text);
			return settings;
		}
		
		public void SetMaster(ModbusMaster master)
		{
			context.Master = master;
			var enabled = (master != null);
			context.uiRunner.Run(() => {
				buttonRead.Enabled = enabled;        	
			});
		}
		
		void ButtonReadClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var startAddress = (ushort)numericUpDownRegisterAddress.Value;
			var functionCode = comboBoxFunctionCode.SelectedIndex;
			context.ioRunner.Run(() => {
				if (context.Master != null) {
					var value = functionCode == 0 ? 
					context.Master.ReadHoldingRegisters(slaveAddress, startAddress, 2) : 
					context.Master.ReadInputRegisters(slaveAddress, startAddress, 2);
					var floatValue = ByteArrayToFloat(value);
					context.uiRunner.Run(() => {
						labelFloatValue.Text = floatValue.ToString("0.00");
					});
				}
			});
		}
		
		private float ByteArrayToFloat(ushort[] value)
		{
			var bytes = new byte[] { 
				(byte)((value[0] >> 8) & 0xff),
				(byte)((value[0] >> 0) & 0xff),
				(byte)((value[1] >> 8) & 0xff),
				(byte)((value[1] >> 0) & 0xff),
			};
			if (BitConverter.IsLittleEndian)
				Array.Reverse(bytes);
			return BitConverter.ToSingle(bytes, 0);
		}
	}
}
