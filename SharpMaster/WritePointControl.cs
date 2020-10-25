using System;
using System.Windows.Forms;

namespace SharpMaster
{
	public partial class WritePointControl : UserControl, IoControl
	{
		private ControlContext context;
		
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
		
		public void Enable(bool enabled)
		{
			buttonOff.Enabled = enabled;
			buttonOn.Enabled = enabled;            	
        }

        public void Perform()
        {
        }

        void ButtonOnClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var coilAddress = (ushort)numericUpDownStartAddress.Value;
			context.Io((master) => {
				master.WriteCoil(slaveAddress, coilAddress, true);
			});	
		}
		
		void ButtonOffClick(object sender, EventArgs e)
		{
			var slaveAddress = (byte)numericUpDownSlaveAddress.Value;
			var startAddress = (ushort)numericUpDownStartAddress.Value;
			context.Io((master) => {
                master.WriteCoil(slaveAddress, startAddress, false);
			});		
		}
	}
}
