
using System;
using System.Drawing;
using System.Windows.Forms;
using SharpModbus;

namespace SharpMaster
{
	public partial class ReadPointControl : UserControl, IoControl
	{
		private ControlContext context;
		
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
		
		public void Enable(bool enabled)
		{
			buttonRead.Enabled = enabled;        	
        }

        public void Perform()
        {
            buttonRead.PerformClick();
        }

        void ButtonReadClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var startAddress = (ushort)numericUpDownStartAddress.Value;
			var functionCode = comboBoxFunctionCode.SelectedIndex;
			context.Io((master) => {
                var state = functionCode == 0 ?
				master.ReadCoil(slaveAddress, startAddress) :
				master.ReadInput(slaveAddress, startAddress);
				context.Ui(() => {
					labelState.Text = state ? "On" : "Off";
					labelState.BackColor = state ? Color.LimeGreen : Color.Gray;
				});
			});
		}
	}
}
