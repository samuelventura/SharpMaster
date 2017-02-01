
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SharpModbus;
using SharpTools;

namespace SharpMaster
{
	public partial class WriteRegisterControl : UserControl, IoControl
	{
		private readonly ControlContext context;
		
		public WriteRegisterControl(ControlContext context, SerializableMap settings)
		{
			this.context = context;
			
			InitializeComponent();
			
			if (settings != null) {
				numericUpDownSlaveAddress.Value = settings.GetNumber("slaveAddress", 0);
				numericUpDownRegisterAddress.Value = settings.GetNumber("startAddress", 0);
				numericUpDownRegisterValue.Value = settings.GetNumber("registerValue", 0);
			}
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
		
		public void SetMaster(ModbusMaster master)
		{
			context.Master = master;
			var enabled = (master != null);
			context.uiRunner.Run(() => {
				buttonWrite.Enabled = enabled;        	
			});
		}
		
		void ButtonWriteClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var startAddress = (ushort)numericUpDownRegisterAddress.Value;
			var registerValue = (ushort)numericUpDownRegisterValue.Value;
			context.ioRunner.Run(() => {
				if (context.Master != null) {
					context.Master.WriteRegister(slaveAddress, startAddress, registerValue);
				}
			});
		}
	}
}
