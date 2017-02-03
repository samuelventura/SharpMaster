
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using SharpModbus;
using SharpTools;

namespace SharpMaster
{
	public partial class ReadRegisterControl : UserControl, IoControl
	{
		private readonly ControlContext context;
		
		public ReadRegisterControl(ControlContext context, SerializableMap settings)
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
					context.Master.ReadHoldingRegister(slaveAddress, startAddress) : 
					context.Master.ReadInputRegister(slaveAddress, startAddress);
					context.uiRunner.Run(() => {
						labelRegisterValue.Text = value.ToString();
					});
				}
			});
		}
	}
}
