
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SharpModbus;
using SharpTools;

namespace SharpMaster
{
	public partial class WritePointControl : UserControl, IoControl
	{
		private readonly ControlContext context;
		
		public WritePointControl(ControlContext context, SerializableMap settings)
		{
			this.context = context;
			
			InitializeComponent();
			
			numericUpDownSlaveAddress.Value = settings.GetNumber("slaveAddress", 0);
			numericUpDownStartAddress.Value = settings.GetNumber("startAddress", 0);
			if (comboBoxFunctionCode.SelectedIndex < 0)
				comboBoxFunctionCode.SelectedIndex = 0;
		}
		
		public SerializableMap GetSettings()
		{
			var settings = new SerializableMap();
			settings.AddAny("slaveAddress", numericUpDownSlaveAddress.Value);
			settings.AddAny("startAddress", numericUpDownStartAddress.Value);
			return settings;
		}
		
		public void SetMaster(ModbusMaster master)
		{
			context.Master = master;
			var enabled = (master != null);
			context.uiRunner.Run(() => {
				buttonOff.Enabled = enabled;
				buttonOn.Enabled = enabled;            	
			});
		}
		
		void ButtonOnClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var coilAddress = (ushort)numericUpDownStartAddress.Value;
			context.ioRunner.Run(() => {
				if (context.Master != null) {
					context.Master.WriteCoil(slaveAddress, coilAddress, true);
				}
			});	
		}
		
		void ButtonOffClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var startAddress = (ushort)numericUpDownStartAddress.Value;
			context.ioRunner.Run(() => {
				if (context.Master != null) {
					context.Master.WriteCoil(slaveAddress, startAddress, false);
				}
			});		
		}
	}
}
