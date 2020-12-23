using System;
using System.Text;
using System.IO.Ports;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpMaster.Tools;
using SharpModbus;

namespace SharpMaster
{
	public class ControlContext : IDisposable
    {
        public MasterConfig Config = new MasterConfig();
        private Action<string, string> log;
        private Action<bool, bool> connected;
        private ModbusMaster master;
        private ControlRunner uir;
        private ThreadRunner ior;
        private DateTime start;
        private DateTime last;

        public void Setup(Control control, Action<bool, bool> connected, Action<string, string> log)
        {
            this.log = log;
            this.connected = connected;
            this.uir = new ControlRunner(control);
            this.ior = new ThreadRunner("IO", IoException);
        }

        public void OpenSerial(string name, SerialSettings serial)
        {
            Io(() => {
                if (uir == null) return; //disposed
                var serialPort = new SerialPort(name);
                serial.CopyTo(serialPort);
                serialPort.Open();
                var stream = new ModbusSerialStream(serialPort, Config.FixedTimeout(), StreamLog);
                var protocol = new ModbusRTUProtocol();
                master = new ModbusMaster(stream, protocol);
                start = DateTime.Now;
                last = DateTime.Now;
                Log("success", "Serial {0}@{1} open", name, serial.BaudRate);
                Ui(() => { connected(true, false); });
            });
        }

        public void OpenSocket(string host, int port)
        {
            Io(() => {
                if (uir == null) return; //disposed
                var socket = Sockets.ConnectWithTimeout(host, port, Config.FixedConnect());
                var stream = new ModbusSocketStream(socket, Config.FixedTimeout(), StreamLog);
                master = new ModbusMaster(stream, SocketProtocol());
                start = DateTime.Now;
                last = DateTime.Now;
                Log("success", "Socket {0}:{1} open", host, port);
                Ui(() => { connected(true, false); });
            });
        }

        public void Close()
        {
            Io(() => {
                if (master != null) LogDuration();
                Disposer.Dispose(master);
                master = null;
                Ui(() => { connected(false, true); });
            });
        }

        public void Dispose()
        {
            var ior = this.ior;
            if (ior == null) return;
            ior.Run(() => {
                Disposer.Dispose(master);
                master = null;
                uir = null; //disposed
            });
            //fixes block on close while connected
            Task.Factory.StartNew(ior.Dispose);
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
                var df = DateTime.Now - last;
                var ms = Config.FixedDelay() - df.TotalMilliseconds;
                if (ms > 0) Thread.Sleep((int)ms);
                last = DateTime.Now; //least it fails
                callback(master);
                last = DateTime.Now;
            });
        }

        public void Io(Action callback)
        {
            var ior = this.ior;
            if (ior == null) return;
            ior.Run(callback);
        }

        private IModbusProtocol SocketProtocol()
        {
            if (Config.RtuOverSocket) return new ModbusRTUProtocol();
            return new ModbusTCPProtocol();
        }

        private void LogDuration()
        {
            var ts = DateTime.Now - start;
            Log("Info", "Session duration {0:0.0}s", ts.TotalSeconds);
        }

        private void IoException(Exception ex)
        {
            //first connection attempt should not reconnect
            var cancelReconnect = (master == null);
            if (master != null) LogDuration();
            Log("error", "Error: {0}", ex.Message);
            if (Config.ShowStacktrace) Log("debug", "{0}", ex.ToString());
            Disposer.Dispose(master);
            master = null;
            Ui(() => { connected(false, cancelReconnect); });
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
