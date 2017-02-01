
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;
using System.Net.Sockets;
using System.Text;
using System.IO;
using SharpToolsUI;
using SharpTools;
using SharpModbus;

namespace SharpMaster
{
	public partial class MainForm : Form
	{
		private readonly ASCIIEncoding ascii = new ASCIIEncoding();
		private readonly SerialSettings serial = new SerialSettings();
		private readonly XmlPersister<PersistedSettings> persister = new XmlPersister<PersistedSettings>();
		private readonly List<IoControl> controls = new List<IoControl>();
		private ModbusMaster master;
		private ThreadRunner ior;
		private ControlRunner uir;
		
		public MainForm()
		{
			InitializeComponent();
		}
		
		private void RefreshSerials()
		{
			var current = comboBoxSerial.Text;
			comboBoxSerial.Items.Clear();
			foreach (var name in SerialPort.GetPortNames())
				comboBoxSerial.Items.Add(name);
			comboBoxSerial.Text = current;
		}
		
		private void EnableControls(bool closed)
		{
			linkLabelSerial.Enabled = closed;
			comboBoxSerial.Enabled = closed;
			buttonOpenSerial.Enabled = closed;
			buttonSetupSerial.Enabled = closed;
			textBoxClientHost.Enabled = closed;
			numericUpDownClientPort.Enabled = closed;
			buttonOpenSocket.Enabled = closed;
			buttonClose.Enabled = !closed;
		}
		
		private void Log(string type, string format, params object[] args)
		{
			if (args.Length > 0)
				format = string.Format(format, args);
			var color = Color.White;
			switch (type) {
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
			for (var i = 0; i < count; i++) {
				var b = bytes[i];
				if (i > 0)
					sb.Append(" ");
				sb.Append(b.ToString("X2"));
			}
			Log(prefix.ToString(), sb.ToString());
		}
		
		private string SettingsPath()
		{
			#if DEBUG
			return Exe.Relative(Exe.Filename() + ".xml");
			#else
			var path = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			Directory.CreateDirectory(Path.Combine(path, Exe.Filename()));
			return Path.Combine(path, Exe.Filename(), "config.xml");
			#endif
		}
		
		private void SetMaster(ModbusMaster current)
		{
			master = current;
			foreach (var control in controls) {
				control.SetMaster(current);
			}
		}
		
		private void SaveSettings()
		{
			var config = new PersistedSettings();
			config.Serial = serial;
			config.Name = comboBoxSerial.Text;
			config.ClientHost = textBoxClientHost.Text;
			config.ClientPort = (int)numericUpDownClientPort.Value;
			foreach (var control in panelContainer.Controls) {
				var wrapper = (WrapperControl)control;
				var payload = (IoControl)wrapper.Payload;
				var settings = payload.GetSettings();
				settings.Add("$Type", payload.GetType().Name);
				config.Controls.Add(settings);
			}
			persister.Save(SettingsPath(), config);
		}
		
		private void LoadSettings()
		{
			var config = persister.Load(SettingsPath());
			config.Serial.CopyTo(serial);
			comboBoxSerial.Text = config.Name;
			textBoxClientHost.Text = config.ClientHost;
			numericUpDownClientPort.Value = config.ClientPort;
			foreach (var settings in config.Controls) {
				AddControl(settings["$Type"], settings);
			}
		}
		
		private Control CreateControl(string name, SerializableMap settings)
		{
			var context = new ControlContext();
			context.ioRunner = ior;
			context.uiRunner = uir;
			switch (name) {
				case "WritePointControl":
					return new WritePointControl(context, settings);
				case "ReadPointControl":
					return new ReadPointControl(context, settings);
				case "ReadRegisterControl":
					return new ReadRegisterControl(context, settings);
				case "WriteRegisterControl":
					return new WriteRegisterControl(context, settings);
			}
			Thrower.Throw("Unknown control name {0}", name);
			return null;
		}
		
		private void AddControl(string name, SerializableMap settings = null)
		{
			var control = CreateControl(name, settings);
			var wrapper = new WrapperControl(control, () => {
				ior.Run(() => {
					controls.Remove((IoControl)control);          	        	
				});			                                 	
			});
			panelContainer.Controls.Add(wrapper);
			ior.Run(() => {
				var ioc = (IoControl)control;
				ioc.SetMaster(master);
				controls.Add(ioc);          	        	
			});
		}
		
		private void IoClose()
		{
			Disposer.Dispose(master);
			SetMaster(null);
			uir.Run(() => {
				EnableControls(true);               	        	
			});
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			uir = new ControlRunner(this);	
			ior = new ThreadRunner("IO", (Exception ex) => {
				IoClose();
				uir.Run(() => {
					Log("error", "Error: {0}", ex.Message);
				});
			});
			Text = string.Format("{0} - {1} https://github.com/samuelventura/SharpMaster", Text, Exe.VersionString());
			WrapRunner.Try(() => {
				LoadSettings();
			});
			RefreshSerials();
			EnableControls(true);
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
			SaveSettings();
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
		
		void LinkLabelSerialLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			RefreshSerials();
			comboBoxSerial.DroppedDown = true;
		}
		
		void ButtonClearClick(object sender, EventArgs e)
		{
			richTextBoxLog.Clear();
		}
		
		void ButtonSetupSerialClick(object sender, EventArgs e)
		{
			var setup = new SerialSetupForm(serial);
			setup.ShowDialog();
		}
		
		void ButtonOpenSerialClick(object sender, EventArgs e)
		{
			var name = comboBoxSerial.Text;
			EnableControls(false);
			ior.Run(() => {
				var serialPort = new SerialPort(name);
				serial.CopyTo(serialPort);
				serialPort.Open();
				var stream = new SerialModbusStream(serialPort, 400, (prefix, bytes, count) => {
					uir.Run(() => {
						Log(prefix, bytes, count);
					});                             	
				});
				var protocol = new RtuModbusProtocol(stream);
				SetMaster(new ModbusMaster(protocol));
				uir.Run(() => {
					Log("success", "Serial {0}@{1} open", name, serial.BaudRate);
				});		
			});	
		}
		
		void ButtonOpenSocketClick(object sender, EventArgs e)
		{
			var host = textBoxClientHost.Text;
			var port = (int)numericUpDownClientPort.Value;
			EnableControls(false);
			ior.Run(() => {
				//standalone app maybe closed anytime so default timeout
				var socket = TcpTools.ConnectWithTimeout(host, port, 400);
				var stream = new SocketModbusStream(socket, 400, (prefix, bytes, count) => {
					uir.Run(() => {
						Log(prefix, bytes, count);
					});
				});
				var protocol = new TcpModbusProtocol(stream);
				SetMaster(new ModbusMaster(protocol));
				uir.Run(() => {
					Log("success", "Socket {0}:{1} open", host, port);
				});
			});
		}
		
		void ButtonCloseClick(object sender, EventArgs e)
		{
			ior.Run(() => {
				IoClose();
			});
		}
		
		private void MoveTo(WrapperControl wrapper, Point point)
		{
			var control = panelContainer.GetChildAtPoint(point);
			var index = control == null ? panelContainer.Controls.Count - 1 : 
				panelContainer.Controls.GetChildIndex(control);
			panelContainer.Controls.SetChildIndex(wrapper, index);
		}
		
		void PanelContainerDragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(typeof(WrapperControl))) {
				e.Effect = DragDropEffects.Move;
				var p = panelContainer.PointToClient(new Point(e.X, e.Y));
				var wrapper = (WrapperControl)e.Data.GetData(typeof(WrapperControl));
				wrapper.BackColor = Color.AliceBlue;
				MoveTo(wrapper, p);
			} else
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
		
	}
}
