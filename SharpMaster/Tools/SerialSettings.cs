using System;
using System.IO.Ports;
using System.Globalization;
using System.ComponentModel;

namespace SharpMaster.Tools
{
	public class SerialSettings
	{
		public SerialSettings()
		{
			CopyFrom(new SerialPort());
		}
		
		public SerialSettings(SerialPort sp)
		{
			CopyFrom(sp);
		}

		public SerialSettings Clone()
        {
			var clone = new SerialSettings();
			CopyTo(clone);
			return clone;
        }

		public void CopyFrom(SerialPort sp)
		{
			BaudRate = sp.BaudRate;
			DataBits = sp.DataBits;
			Parity = sp.Parity;
			Handshake = sp.Handshake;
			StopBits = sp.StopBits;
			DiscardNull = sp.DiscardNull;
			DtrEnable = sp.DtrEnable;
			ReadTimeout = sp.ReadTimeout;
			ReadBufferSize = sp.ReadBufferSize;
			WriteTimeout = sp.WriteTimeout;
			WriteBufferSize = sp.WriteBufferSize;
		}
		
		public void CopyTo(SerialPort sp)
		{
			sp.BaudRate = BaudRate;
			sp.DataBits = DataBits;
			sp.Parity = Parity;
			sp.Handshake = Handshake;
			sp.StopBits = StopBits;
			sp.DiscardNull = DiscardNull;
			sp.DtrEnable = DtrEnable;
			sp.ReadTimeout = ReadTimeout;
			sp.ReadBufferSize = ReadBufferSize;
			sp.WriteTimeout = WriteTimeout;
			sp.WriteBufferSize = WriteBufferSize;
        }

        public void CopyFrom(SerialSettings ss)
        {
            BaudRate = ss.BaudRate;
            DataBits = ss.DataBits;
            Parity = ss.Parity;
            Handshake = ss.Handshake;
            StopBits = ss.StopBits;
            DiscardNull = ss.DiscardNull;
            DtrEnable = ss.DtrEnable;
            ReadTimeout = ss.ReadTimeout;
            ReadBufferSize = ss.ReadBufferSize;
            WriteTimeout = ss.WriteTimeout;
            WriteBufferSize = ss.WriteBufferSize;
        }

        public void CopyTo(SerialSettings ss)
		{
			ss.BaudRate = BaudRate;
			ss.DataBits = DataBits;
			ss.Parity = Parity;
			ss.Handshake = Handshake;
			ss.StopBits = StopBits;
			ss.DiscardNull = DiscardNull;
			ss.DtrEnable = DtrEnable;
			ss.ReadTimeout = ReadTimeout;
			ss.ReadBufferSize = ReadBufferSize;
			ss.WriteTimeout = WriteTimeout;
			ss.WriteBufferSize = WriteBufferSize;
		}
		
		[TypeConverter(typeof(BaudRateOptions))]
		public int BaudRate { get; set; }
			
		public int DataBits { get; set; }
			
		public Parity Parity { get; set; }
			
		public Handshake Handshake { get; set; }
			
		public StopBits StopBits { get; set; }
			
		public bool DiscardNull { get; set; }
			
		public bool DtrEnable { get; set; }
			
		public int ReadTimeout { get; set; }
			
		public int ReadBufferSize { get; set; }
			
		public int WriteTimeout { get; set; }
			
		public int WriteBufferSize { get; set; }
	}
	
	public class BaudRateOptions : TypeConverter
	{
		public readonly static int[] BaudRates = new int[] {
			110,
			300,
			600,
			1200,
			2400,
			4800,
			9600,
			14400,
			19200,
			28800,
			38400,
			56000,
			57600,
			115200,
			128000,
			153600,
			230400,
			256000,
			460800,
			921600
		};
	
		public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
		{
			return true;
		}

		public override StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
		{
			return new StandardValuesCollection(BaudRates);
		}

		public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
		{
			return false;
		}
		
		public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
		{
			return (sourceType == typeof(string));
		}
		
		public override object ConvertFrom(ITypeDescriptorContext context, 
			CultureInfo culture, object value)
		{
			return int.Parse(value.ToString());
		}
		
		public override object ConvertTo(ITypeDescriptorContext context, 
			CultureInfo culture, object value, Type destinationType)
		{  
			return value.ToString();
		}
	}
}
