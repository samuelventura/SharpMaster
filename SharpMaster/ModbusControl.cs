using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.IO.Ports;
using System.Windows.Forms;
using SharpMaster.Tools;
using SharpModbus;

namespace SharpMaster
{
    public partial class ModbusControl : UserControl
    {
        private readonly SerialSettings serial = new SerialSettings();
        private readonly List<IoControl> controls = new List<IoControl>();
        private ModbusMaster master;
        private ThreadRunner ior;
        private ControlRunner uir;

        public ModbusControl()
        {
            InitializeComponent();
        }
        public void Unload()
        {
            ior.Dispose(IoDispose);
        }

        public void FromUI(SessionSettings config)
        {
            config.Serial = serial;
            config.SerialPortName = comboBoxSerialPortName.Text;
            config.TcpIP = textBoxTcpIP.Text;
            config.TcpPort = (int)numericUpDownTcpPort.Value;
            foreach (var control in panelContainer.Controls)
            {
                var wrapper = (WrapperControl)control;
                var payload = (IoControl)wrapper.Payload;
                var name = wrapper.ItemName;
                var settings = payload.GetSettings();
                settings.Put("$Type", payload.GetType().Name);
                settings.Put("$Name", name);
                config.Controls.Add(settings);
            }
        }

        public void ToUI(SessionSettings config)
        {
            config.Serial.CopyTo(serial);
            comboBoxSerialPortName.Text = config.SerialPortName;
            textBoxTcpIP.Text = config.TcpIP;
            numericUpDownTcpPort.Value = config.TcpPort;
            foreach (var settings in config.Controls)
            {
                AddControl(settings.Get("$Type"), settings);
            }
        }

        private void RefreshSerials()
        {
            var current = comboBoxSerialPortName.Text;
            comboBoxSerialPortName.Items.Clear();
            foreach (var name in SerialPort.GetPortNames())
                comboBoxSerialPortName.Items.Add(name);
            comboBoxSerialPortName.Text = current;
        }

        private void EnableControls(bool closed)
        {
            linkLabelSerialRefresh.Enabled = closed;
            comboBoxSerialPortName.Enabled = closed;
            buttonOpenSerial.Enabled = closed;
            buttonSetupSerial.Enabled = closed;
            textBoxTcpIP.Enabled = closed;
            numericUpDownTcpPort.Enabled = closed;
            buttonOpenSocket.Enabled = closed;
            buttonClose.Enabled = !closed;
        }

        private void Log(string type, string format, params object[] args)
        {
            if (args.Length > 0)
                format = string.Format(format, args);
            var color = Color.White;
            switch (type)
            {
                case "<":
                    color = Color.DodgerBlue;
                    break;
                case ">":
                    color = Color.Salmon;
                    break;
                case "success":
                    color = Color.LimeGreen;
                    break;
                case "error":
                    color = Color.OrangeRed;
                    break;
            }
            richTextBoxLog.SelectionLength = 0; //clear selection
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.SelectionColor = Color.Gray;
            richTextBoxLog.AppendText(DateTime.Now.ToString("HH:mm:ss.fff"));
            richTextBoxLog.SelectionColor = color;
            richTextBoxLog.AppendText(" ");
            richTextBoxLog.AppendText(format);
            richTextBoxLog.AppendText("\n");
            richTextBoxLog.SelectionStart = richTextBoxLog.Text.Length;
            richTextBoxLog.ScrollToCaret();
        }

        private void Log(char prefix, byte[] bytes, int count)
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

        private Control CreateControl(string name, SerializableMap settings)
        {
            var context = new ControlContext
            {
                ioRunner = ior,
                uiRunner = uir
            };
            switch (name)
            {
                case "WritePointControl":
                    return new WritePointControl(context, settings);
                case "ReadPointControl":
                    return new ReadPointControl(context, settings);
                case "ReadRegisterControl":
                    return new ReadRegisterControl(context, settings);
                case "WriteRegisterControl":
                    return new WriteRegisterControl(context, settings);
                case "ReadFloatControl":
                    return new ReadFloatControl(context, settings);
                case "WriteFloatControl":
                    return new WriteFloatControl(context, settings);
            }
            Thrower.Throw("Unknown control name {0}", name);
            return null;
        }

        private void AddControl(string name, SerializableMap settings = null)
        {
            if (settings == null)
            {
                settings = new SerializableMap();
            }
            var control = CreateControl(name, settings);
            var wrapper = new WrapperControl(control, () => ior.Run(() => controls.Remove((IoControl)control)))
            {
                ItemName = settings.GetString("$Name", "NO NAME")
            };
            panelContainer.Controls.Add(wrapper);
            ior.Run(() => {
                var ioc = (IoControl)control;
                ioc.SetMaster(master);
                controls.Add(ioc);
            });
        }

        private void MoveTo(WrapperControl wrapper, Point point)
        {
            var control = panelContainer.GetChildAtPoint(point);
            var index = control == null ? panelContainer.Controls.Count - 1 :
                panelContainer.Controls.GetChildIndex(control);
            panelContainer.Controls.SetChildIndex(wrapper, index);
            //reassign taborder for tab navigation to honor visual order
            var tabIndex = 0;
            foreach (Control c in panelContainer.Controls)
            {
                c.TabIndex = tabIndex++;
            }
        }

        private void IoSetMaster(ModbusMaster current)
        {
            master = current;
            foreach (var control in controls)
            {
                control.SetMaster(current);
            }
        }

        private void IoDispose()
        {
            Disposer.Dispose(master);
        }

        private void IoClose()
        {
            IoDispose();
            IoSetMaster(null);
            uir.Run(() => EnableControls(true));
        }

        private void IoLog(char prefix, byte[] bytes, int count)
        {
            uir.Run(() => Log(prefix, bytes, count));
        }

        void ModbusControl_Load(object sender, EventArgs e)
        {
            uir = new ControlRunner(this);
            ior = new ThreadRunner("IO", (Exception ex) => {
                IoClose();
                uir.Run(() => Log("error", "Error: {0}", ex.Message));
            });
            RefreshSerials();
            EnableControls(true);
            timer.Enabled = pollCheckBox.Checked;
        }

        void ButtonWritePointClick(object sender, EventArgs e)
        {
            AddControl(typeof(WritePointControl).Name);
        }

        void ButtonReadPointClick(object sender, EventArgs e)
        {
            AddControl(typeof(ReadPointControl).Name);
        }

        void ButtonWriteRegisterClick(object sender, EventArgs e)
        {
            AddControl(typeof(WriteRegisterControl).Name);
        }

        void ButtonReadRegisterClick(object sender, EventArgs e)
        {
            AddControl(typeof(ReadRegisterControl).Name);
        }

        void ButtonWriteFloatClick(object sender, EventArgs e)
        {
            AddControl(typeof(WriteFloatControl).Name);
        }

        void ButtonReadFloatClick(object sender, EventArgs e)
        {
            AddControl(typeof(ReadFloatControl).Name);
        }

        void LinkLabelSerialLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RefreshSerials();
            comboBoxSerialPortName.DroppedDown = true;
        }

        void ButtonClearClick(object sender, EventArgs e)
        {
            richTextBoxLog.Clear();
        }

        void ButtonSetupSerialClick(object sender, EventArgs e)
        {
            var setup = new SerialSettingsForm(serial);
            setup.ShowDialog();
        }

        void ButtonOpenSerialClick(object sender, EventArgs e)
        {
            var name = comboBoxSerialPortName.Text;
            EnableControls(false);
            ior.Run(() => {
                var serialPort = new SerialPort(name);
                serial.CopyTo(serialPort);
                serialPort.Open();
                var stream = new ModbusSerialStream(serialPort, 1000, IoLog);
                var protocol = new ModbusRTUProtocol();
                IoSetMaster(new ModbusMaster(stream, protocol));
                uir.Run(() => Log("success", "Serial {0}@{1} open", name, serial.BaudRate));
            });
        }

        void ButtonOpenSocketClick(object sender, EventArgs e)
        {
            var host = textBoxTcpIP.Text;
            var port = (int)numericUpDownTcpPort.Value;
            EnableControls(false);
            ior.Run(() => {
                //standalone app maybe closed anytime so default timeout
                var socket = Sockets.ConnectWithTimeout(host, port, 400);
                var stream = new ModbusSocketStream(socket, 400, IoLog);
                var protocol = new ModbusTCPProtocol();
                IoSetMaster(new ModbusMaster(stream, protocol));
                uir.Run(() => Log("success", "Socket {0}:{1} open", host, port));
            });
        }

        void ButtonCloseClick(object sender, EventArgs e)
        {
            ior.Run(IoClose);
        }

        void PanelContainerDragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(typeof(WrapperControl)))
            {
                e.Effect = DragDropEffects.Move;
                var p = panelContainer.PointToClient(new Point(e.X, e.Y));
                var wrapper = (WrapperControl)e.Data.GetData(typeof(WrapperControl));
                wrapper.BackColor = Color.AliceBlue;
                MoveTo(wrapper, p);
            }
            else
                e.Effect = DragDropEffects.None;
        }

        void PanelContainerDragOver(object sender, DragEventArgs e)
        {
            var p = panelContainer.PointToClient(new Point(e.X, e.Y));
            var wrapper = (WrapperControl)e.Data.GetData(typeof(WrapperControl));
            MoveTo(wrapper, p);
        }

        void PanelContainerDragDrop(object sender, DragEventArgs e)
        {
            var p = panelContainer.PointToClient(new Point(e.X, e.Y));
            var wrapper = (WrapperControl)e.Data.GetData(typeof(WrapperControl));
            wrapper.BackColor = Color.White;
            MoveTo(wrapper, p);
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            foreach (var control in panelContainer.Controls)
            {
                var wrapper = (WrapperControl)control;
                var payload = (IoControl)wrapper.Payload;
                payload.Perform();
            }
            ior.Run(()=> {
                uir.Run(()=> {
                    timer.Enabled = pollCheckBox.Checked;
                });
            });
        }

        private void PollCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timer.Enabled = pollCheckBox.Checked;
        }
    }
}
