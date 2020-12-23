using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;
using SharpMaster.Tools;

namespace SharpMaster
{
    public partial class ModbusControl : UserControl
    {
        private readonly SetupForm setup = new SetupForm();
        private readonly SerialSettings serial = new SerialSettings();
        private readonly List<IoControl> controls = new List<IoControl>();
        private readonly ControlContext context = new ControlContext();
        private Button reconnect;

        public ModbusControl()
        {
            InitializeComponent();
        }

        public void Unload()
        {
            context.Dispose();
        }

        public void FromUI(MasterDto dto)
        {
            dto.Serial = serial;
            dto.Config = context.Config.Clone();
            dto.PollInputs = pollCheckBox.Checked;
            dto.SerialPortName = comboBoxSerialPortName.Text;
            dto.TcpIP = textBoxTcpIP.Text;
            dto.TcpPort = (int)numericUpDownTcpPort.Value;
            foreach (var control in panelContainer.Controls)
            {
                var wrapper = (WrapperControl)control;
                var payload = (IoControl)wrapper.Control;
                var name = wrapper.ItemName;
                var settings = payload.GetSettings();
                settings.Put("$Type", payload.GetType().Name);
                settings.Put("$Name", name);
                dto.Controls.Add(settings);
            }
        }

        public void ToUI(MasterDto dto)
        {
            dto.Serial.CopyTo(serial);
            context.Config = dto.Config.Clone();
            timer.Interval = dto.Config.FixedTimer();
            pollCheckBox.Checked = dto.PollInputs;
            comboBoxSerialPortName.Text = dto.SerialPortName;
            textBoxTcpIP.Text = dto.TcpIP;
            numericUpDownTcpPort.Value = dto.TcpPort;
            foreach (var settings in dto.Controls)
            {
                AddControl(settings.Get("$Type"), settings);
            }
        }

        public void Setup()
        {
            context.Config = setup.Edit(context.Config);
            timer.Interval = context.Config.FixedTimer();
        }

        private void RemoveControl(WrapperControl wrapper)
        {
            controls.Remove((IoControl)wrapper.Control);
            panelContainer.Controls.Remove(wrapper);
        }

        private void AddControl(string name, SerializableMap settings = null)
        {
            settings = settings ?? new SerializableMap();
            var control = CreateControl(name, settings);
            var wrapper = new WrapperControl(control, RemoveControl)
            {
                ItemName = settings.GetString("$Name", "NO NAME")
            };
            panelContainer.Controls.Add(wrapper);
            var ioc = control as IoControl;
            ioc.Enable(false);
            controls.Add(ioc);
        }

        private Control CreateControl(string name, SerializableMap settings)
        {
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

        private void EnableControls(bool closed)
        {
            linkLabelSerialRefresh.Enabled = closed;
            comboBoxSerialPortName.Enabled = closed;
            buttonOpenSerial.Enabled = closed;
            buttonSetupSerial.Enabled = closed;
            textBoxTcpIP.Enabled = closed;
            numericUpDownTcpPort.Enabled = closed;
            buttonOpenSocket.Enabled = closed;
            buttonWriteFloat.Enabled = closed;
            buttonWritePoint.Enabled = closed;
            buttonWriteRegister.Enabled = closed;
            buttonReadFloat.Enabled = closed;
            buttonReadPoint.Enabled = closed;
            buttonReadRegister.Enabled = closed;
            //close always enabled to avoid reconnect flicker
            //buttonClose.Enabled = !closed;
        }

        private void RefreshSerials()
        {
            var current = comboBoxSerialPortName.Text;
            comboBoxSerialPortName.Items.Clear();
            foreach (var name in SerialPort.GetPortNames())
            {
                comboBoxSerialPortName.Items.Add(name);
            }
            comboBoxSerialPortName.Text = current;
        }

        private void Log(string type, string format, params object[] args)
        {
            switch (type)
            {
                case "<":
                case ">":
                    if (!context.Config.ShowPackets) return;
                    break;
            }
            if (args.Length > 0) format = string.Format(format, args);
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

        private void Connected(bool connected, bool cancelReconnect)
        {
            EnableControls(!connected);
            foreach (var control in controls)
            {
                control.Enable(connected);
            }
            if (cancelReconnect) reconnect = null;
            if (!connected && reconnect!=null && context.Config.Reconnect)
            {
                reconnect.PerformClick();
            }
        }

        void ModbusControl_Load(object sender, EventArgs e)
        {
            context.Setup(this, Connected, (t, m) => Log(t, m));
            RefreshSerials();
            Connected(false, true);
            timer.Enabled = pollCheckBox.Checked;
        }

        void ButtonOpenSerialClick(object sender, EventArgs e)
        {
            reconnect = buttonOpenSerial;
            var name = comboBoxSerialPortName.Text;
            EnableControls(false);
            context.OpenSerial(name, serial.Clone());
        }

        void ButtonOpenSocketClick(object sender, EventArgs e)
        {
            reconnect = buttonOpenSocket;
            var host = textBoxTcpIP.Text;
            var port = (int)numericUpDownTcpPort.Value;
            EnableControls(false);
            context.OpenSocket(host, port);
        }

        void ButtonCloseClick(object sender, EventArgs e)
        {
            reconnect = null;
            context.Close();
        }

        void Timer_Tick(object sender, EventArgs e)
        {
            timer.Enabled = false;
            foreach (var control in controls)
            {
                control.Perform();
            }
            context.Io(() => {
                context.Ui(() => {
                    timer.Enabled = pollCheckBox.Checked;
                });
            });
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
            setup.Edit(serial);
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

        private void PollCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            timer.Enabled = pollCheckBox.Checked;
        }
    }
}
