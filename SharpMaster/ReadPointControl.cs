
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using SharpModbus;
using SharpTools;

namespace SharpMaster
{
	public partial class ReadPointControl : UserControl, IoControl
	{
		private readonly ControlContext context;
		
		public ReadPointControl(ControlContext context, SerializableMap settings)
		{
			this.context = context;
			
			InitializeComponent();
			
			numericUpDownSlaveAddress.Value = settings.GetNumber("slaveAddress", 0);
			numericUpDownStartAddress.Value = settings.GetNumber("startAddress", 0);
			comboBoxFunctionCode.Text = settings.GetString("functionCode", "1 Coil");
			if (comboBoxFunctionCode.SelectedIndex < 0)
				comboBoxFunctionCode.SelectedIndex = 0;
		}
		
		public SerializableMap GetSettings()
		{
			var settings = new SerializableMap();
			settings.AddAny("slaveAddress", numericUpDownSlaveAddress.Value);
			settings.AddAny("startAddress", numericUpDownStartAddress.Value);
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
			var startAddress = (ushort)numericUpDownStartAddress.Value;
			var functionCode = comboBoxFunctionCode.SelectedIndex;
			context.ioRunner.Run(() => {
				if (context.Master != null) {
					var state = functionCode == 0 ?
					context.Master.ReadCoil(slaveAddress, startAddress) :
					context.Master.ReadInput(slaveAddress, startAddress);
					context.uiRunner.Run(() => {
						labelState.Text = state ? "On" : "Off";
						labelState.BackColor = state ? Color.LimeGreen : Color.Gray;
					});
				}
			});
		}
	}
}
