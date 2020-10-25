using System;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using System.Threading;
using SharpMaster.Tools;
using SharpModbus;

namespace SharpMaster
{
	public class ControlContext : IDisposable
    {
        private Action<string, string> log;
        private Action<bool> connected;
        private ModbusMaster master;
        private ControlRunner uir;
        private ThreadRunner ior;

        public void Setup(Control control, Action<bool> connected, Action<string, string> log)
        {
            this.log = log;
            this.connected = connected;
            this.uir = new ControlRunner(control);
            this.ior = new ThreadRunner("IO", IoException);
        }

        public void OpenSerial(string name, SerialSettings config)
        {
            Io(() => {
                var serialPort = new SerialPort(name);
                config.CopyTo(serialPort);
                serialPort.Open();
                var stream = new ModbusSerialStream(serialPort, 1000, StreamLog);
                var protocol = new ModbusRTUProtocol();
                master = new ModbusMaster(stream, protocol);
                Log("success", "Serial {0}@{1} open", name, config.BaudRate);
                Ui(() => { connected(true); });
            });
        }

        public void OpenSocket(string host, int port)
        {
            Io(() => {
                //standalone app maybe closed anytime so default timeout
                var socket = Sockets.ConnectWithTimeout(host, port, 400);
                var stream = new ModbusSocketStream(socket, 400, StreamLog);
                var protocol = new ModbusTCPProtocol();
                master = new ModbusMaster(stream, protocol);
                Log("success", "Socket {0}:{1} open", host, port);
                Ui(() => { connected(true); });
            });
        }

        public void Close()
        {
            Io(() => {
                Disposer.Dispose(master);
                master = null;
                Ui(() => { connected(false); });
            });
        }

        public void Dispose()
        {
            var ior = this.ior;
            if (ior == null) return;
            ior.Dispose(() => {
                Disposer.Dispose(master);
                master = null;
            });
        }

        public void Ui(Action callback)
        {
            var uir = this.uir;
            if (uir == null) return;
            uir.Run(callback);
        }

        public void Io(Action<ModbusMaster> callback)
        {
            Io(() => {
                var master = this.master;
                if (master == null) return;
                //SELEC requires 20ms between calls
                Thread.Sleep(20);
                callback(master);
            });
        }

        public void Io(Action callback)
        {
            var ior = this.ior;
            if (ior == null) return;
            ior.Run(callback);
        }

        private void IoException(Exception ex)
        {
            Log("error", "Error: {0}", ex.Message);
            Disposer.Dispose(master);
            master = null;
            Ui(() => { connected(false); });
        }

        private void StreamLog(char prefix, byte[] bytes, int count)
        {
            var sb = new StringBuilder();
            sb.Append(prefix);
            for (var i = 0; i < count; i++)
            {
                var b = bytes[i];
                if (i > 0)
                    sb.Append(" ");
                sb.Append(b.ToString("X2"));
            }
            Log(prefix.ToString(), sb.ToString());
        }

        private void Log(string type, string format, params object[] args)
        {
            if (args.Length > 0) format = string.Format(format, args);
            Ui(() => { log(type, format); });
        }
    }
}
