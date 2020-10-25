using System;
using System.Windows.Forms;
using SharpMaster.Tools;

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
            comboBoxFunctionCode.Text = settings.GetString("functionCode", "6 Holding 1234");
            if (comboBoxFunctionCode.SelectedIndex < 0)
				comboBoxFunctionCode.SelectedIndex = 0;
		}
		
		public SerializableMap GetSettings()
		{
			var settings = new SerializableMap();
			settings.AddAny("slaveAddress", numericUpDownSlaveAddress.Value);
			settings.AddAny("startAddress", numericUpDownRegisterAddress.Value);
			settings.AddAny("floatValue", numericUpDownFloatValue.Value);
            settings.AddAny("functionCode", comboBoxFunctionCode.Text);
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
			var floatValue = numericUpDownFloatValue.Value;
            var functionCode = comboBoxFunctionCode.SelectedIndex;
            context.Io((master) => {
                var value = FloatToByteArray((float)floatValue, functionCode);
				master.WriteRegisters(slaveAddress, startAddress, value);
			});
        }

        /*
        Modbus is Big Endian
        Opto22 float is Big Endian
        6 Holding 1234
        6 Holding 3412
        */

        private ushort[] FloatToByteArray(float value, int byteOrder)
		{
            byte[] bytes = null;
            switch (byteOrder)
            {
                case 0: //1234 opto22
                    bytes = BitConverter.GetBytes(value);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytes);
                    return new ushort[] {
                (ushort)((bytes[0] << 8 | bytes[1]) & 0xFFFF),
                (ushort)((bytes[2] << 8 | bytes[3]) & 0xFFFF),
            };
                case 1: //3412 selec
                    bytes = BitConverter.GetBytes(value);
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytes);
                    return new ushort[] {
                (ushort)((bytes[2] << 8 | bytes[3]) & 0xFFFF),
                (ushort)((bytes[0] << 8 | bytes[1]) & 0xFFFF),
            };
            }
            throw Thrower.Make("Invalid byte order {0}", byteOrder);
		}
	}
}
