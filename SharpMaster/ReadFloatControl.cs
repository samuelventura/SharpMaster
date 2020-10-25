using System;
using System.Windows.Forms;
using SharpMaster.Tools;

namespace SharpMaster
{
	public partial class ReadFloatControl : UserControl, IoControl
	{
		private ControlContext context;
		
		public ReadFloatControl(ControlContext context, SerializableMap settings)
		{
            this.context = context;

			InitializeComponent();
			
			numericUpDownSlaveAddress.Value = settings.GetNumber("slaveAddress", 0);
			numericUpDownRegisterAddress.Value = settings.GetNumber("startAddress", 0);
			comboBoxFunctionCode.Text = settings.GetString("functionCode", "3 Holding 1234");
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
			var startAddress = (ushort)numericUpDownRegisterAddress.Value;
			var functionCode = comboBoxFunctionCode.SelectedIndex;
            context.Io((master) => {
                var value = functionCode < 2? 
				master.ReadHoldingRegisters(slaveAddress, startAddress, 2) : 
				master.ReadInputRegisters(slaveAddress, startAddress, 2);
				var floatValue = ByteArrayToFloat(value, functionCode % 2);
				context.Ui(() => {
					labelFloatValue.Text = floatValue.ToString("0.0000");
				});
			});
        }

        /*
        Modbus is Big Endian
        Opto22 float is Big Endian
        3 Holding 1234
        3 Holding 3412
        4 Input 1234
        4 Input 3412
        */

        private float ByteArrayToFloat(ushort[] value, int byteOrder)
		{
            byte[] bytes = null;
            switch(byteOrder)
            {
                case 0: //1234 opto22
                    bytes = new byte[] {
                        (byte)((value[0] >> 8) & 0xff),
                        (byte)((value[0] >> 0) & 0xff),
                        (byte)((value[1] >> 8) & 0xff),
                        (byte)((value[1] >> 0) & 0xff),
                    };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytes);
                    return BitConverter.ToSingle(bytes, 0);
                case 1: //3412 selec
                    bytes = new byte[] {
                        (byte)((value[1] >> 8) & 0xff),
                        (byte)((value[1] >> 0) & 0xff),
                        (byte)((value[0] >> 8) & 0xff),
                        (byte)((value[0] >> 0) & 0xff),
                    };
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(bytes);
                    return BitConverter.ToSingle(bytes, 0);
            }
            throw Thrower.Make("Invalid byte order {0}", byteOrder);
		}
    }
}
