
namespace SharpMaster
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Panel panelLeft;
		private System.Windows.Forms.Button buttonClear;
		private System.Windows.Forms.Button buttonClose;
		private System.Windows.Forms.Button buttonSetupSerial;
		private System.Windows.Forms.Button buttonOpenSocket;
		private System.Windows.Forms.NumericUpDown numericUpDownClientPort;
		private System.Windows.Forms.Label labelPort;
		private System.Windows.Forms.TextBox textBoxClientHost;
		private System.Windows.Forms.Label labelHost;
		private System.Windows.Forms.Button buttonOpenSerial;
		private System.Windows.Forms.ComboBox comboBoxSerial;
		private System.Windows.Forms.LinkLabel linkLabelSerial;
		private System.Windows.Forms.RichTextBox richTextBoxLog;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Panel panelRight;
		private System.Windows.Forms.Button buttonWritePoint;
		private System.Windows.Forms.Button buttonReadPoint;
		private System.Windows.Forms.FlowLayoutPanel panelContainer;
		private System.Windows.Forms.Button buttonWriteRegister;
		private System.Windows.Forms.Button buttonReadRegister;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.panelLeft = new System.Windows.Forms.Panel();
			this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.textBoxClientHost = new System.Windows.Forms.TextBox();
			this.labelPort = new System.Windows.Forms.Label();
			this.linkLabelSerial = new System.Windows.Forms.LinkLabel();
			this.comboBoxSerial = new System.Windows.Forms.ComboBox();
			this.labelHost = new System.Windows.Forms.Label();
			this.numericUpDownClientPort = new System.Windows.Forms.NumericUpDown();
			this.buttonSetupSerial = new System.Windows.Forms.Button();
			this.buttonClose = new System.Windows.Forms.Button();
			this.buttonOpenSocket = new System.Windows.Forms.Button();
			this.buttonOpenSerial = new System.Windows.Forms.Button();
			this.buttonClear = new System.Windows.Forms.Button();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.buttonWritePoint = new System.Windows.Forms.Button();
			this.buttonReadPoint = new System.Windows.Forms.Button();
			this.buttonWriteRegister = new System.Windows.Forms.Button();
			this.buttonReadRegister = new System.Windows.Forms.Button();
			this.panelRight = new System.Windows.Forms.Panel();
			this.panelContainer = new System.Windows.Forms.FlowLayoutPanel();
			this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
			this.panelLeft.SuspendLayout();
			this.tableLayoutPanel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownClientPort)).BeginInit();
			this.panelRight.SuspendLayout();
			this.tableLayoutPanel2.SuspendLayout();
			this.SuspendLayout();
			// 
			// panelLeft
			// 
			this.panelLeft.Controls.Add(this.richTextBoxLog);
			this.panelLeft.Controls.Add(this.tableLayoutPanel1);
			this.panelLeft.Controls.Add(this.buttonClear);
			this.panelLeft.Dock = System.Windows.Forms.DockStyle.Left;
			this.panelLeft.Location = new System.Drawing.Point(0, 0);
			this.panelLeft.Name = "panelLeft";
			this.panelLeft.Size = new System.Drawing.Size(399, 561);
			this.panelLeft.TabIndex = 0;
			// 
			// richTextBoxLog
			// 
			this.richTextBoxLog.BackColor = System.Drawing.Color.Black;
			this.richTextBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
			this.richTextBoxLog.ForeColor = System.Drawing.Color.White;
			this.richTextBoxLog.Location = new System.Drawing.Point(0, 65);
			this.richTextBoxLog.Margin = new System.Windows.Forms.Padding(2);
			this.richTextBoxLog.Name = "richTextBoxLog";
			this.richTextBoxLog.ReadOnly = true;
			this.richTextBoxLog.Size = new System.Drawing.Size(399, 470);
			this.richTextBoxLog.TabIndex = 19;
			this.richTextBoxLog.Text = "";
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 7;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.textBoxClientHost, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.labelPort, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.linkLabelSerial, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxSerial, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.labelHost, 0, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownClientPort, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonSetupSerial, 3, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonClose, 6, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonOpenSocket, 5, 1);
			this.tableLayoutPanel1.Controls.Add(this.buttonOpenSerial, 5, 0);
			this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(2);
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(399, 65);
			this.tableLayoutPanel1.TabIndex = 7;
			// 
			// textBoxClientHost
			// 
			this.textBoxClientHost.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.tableLayoutPanel1.SetColumnSpan(this.textBoxClientHost, 2);
			this.textBoxClientHost.Location = new System.Drawing.Point(37, 37);
			this.textBoxClientHost.Margin = new System.Windows.Forms.Padding(2);
			this.textBoxClientHost.Name = "textBoxClientHost";
			this.textBoxClientHost.Size = new System.Drawing.Size(122, 20);
			this.textBoxClientHost.TabIndex = 4;
			// 
			// labelPort
			// 
			this.labelPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelPort.AutoSize = true;
			this.labelPort.Location = new System.Drawing.Point(163, 41);
			this.labelPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelPort.Name = "labelPort";
			this.labelPort.Size = new System.Drawing.Size(26, 13);
			this.labelPort.TabIndex = 5;
			this.labelPort.Text = "Port";
			this.labelPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// linkLabelSerial
			// 
			this.linkLabelSerial.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.linkLabelSerial.AutoSize = true;
			this.tableLayoutPanel1.SetColumnSpan(this.linkLabelSerial, 2);
			this.linkLabelSerial.Location = new System.Drawing.Point(4, 10);
			this.linkLabelSerial.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.linkLabelSerial.Name = "linkLabelSerial";
			this.linkLabelSerial.Size = new System.Drawing.Size(60, 13);
			this.linkLabelSerial.TabIndex = 0;
			this.linkLabelSerial.TabStop = true;
			this.linkLabelSerial.Text = "Serial Ports";
			this.linkLabelSerial.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSerialLinkClicked);
			// 
			// comboBoxSerial
			// 
			this.comboBoxSerial.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.comboBoxSerial.FormattingEnabled = true;
			this.comboBoxSerial.Location = new System.Drawing.Point(69, 6);
			this.comboBoxSerial.Margin = new System.Windows.Forms.Padding(2);
			this.comboBoxSerial.Name = "comboBoxSerial";
			this.comboBoxSerial.Size = new System.Drawing.Size(90, 21);
			this.comboBoxSerial.TabIndex = 1;
			// 
			// labelHost
			// 
			this.labelHost.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.labelHost.AutoSize = true;
			this.labelHost.Location = new System.Drawing.Point(4, 41);
			this.labelHost.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
			this.labelHost.Name = "labelHost";
			this.labelHost.Size = new System.Drawing.Size(29, 13);
			this.labelHost.TabIndex = 3;
			this.labelHost.Text = "Host";
			this.labelHost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// numericUpDownClientPort
			// 
			this.numericUpDownClientPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.numericUpDownClientPort.Location = new System.Drawing.Point(193, 37);
			this.numericUpDownClientPort.Margin = new System.Windows.Forms.Padding(2);
			this.numericUpDownClientPort.Maximum = new decimal(new int[] {
			65535,
			0,
			0,
			0});
			this.numericUpDownClientPort.Name = "numericUpDownClientPort";
			this.numericUpDownClientPort.Size = new System.Drawing.Size(57, 20);
			this.numericUpDownClientPort.TabIndex = 6;
			// 
			// buttonSetupSerial
			// 
			this.tableLayoutPanel1.SetColumnSpan(this.buttonSetupSerial, 2);
			this.buttonSetupSerial.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonSetupSerial.Location = new System.Drawing.Point(163, 4);
			this.buttonSetupSerial.Margin = new System.Windows.Forms.Padding(2);
			this.buttonSetupSerial.Name = "buttonSetupSerial";
			this.buttonSetupSerial.Size = new System.Drawing.Size(87, 26);
			this.buttonSetupSerial.TabIndex = 8;
			this.buttonSetupSerial.Text = "Setup";
			this.buttonSetupSerial.UseVisualStyleBackColor = true;
			this.buttonSetupSerial.Click += new System.EventHandler(this.ButtonSetupSerialClick);
			// 
			// buttonClose
			// 
			this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonClose.Location = new System.Drawing.Point(323, 4);
			this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
			this.buttonClose.Name = "buttonClose";
			this.tableLayoutPanel1.SetRowSpan(this.buttonClose, 2);
			this.buttonClose.Size = new System.Drawing.Size(72, 57);
			this.buttonClose.TabIndex = 9;
			this.buttonClose.Text = "Close";
			this.buttonClose.UseVisualStyleBackColor = true;
			this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
			// 
			// buttonOpenSocket
			// 
			this.buttonOpenSocket.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOpenSocket.Location = new System.Drawing.Point(254, 34);
			this.buttonOpenSocket.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOpenSocket.Name = "buttonOpenSocket";
			this.buttonOpenSocket.Size = new System.Drawing.Size(65, 27);
			this.buttonOpenSocket.TabIndex = 7;
			this.buttonOpenSocket.Text = "Connect";
			this.buttonOpenSocket.UseVisualStyleBackColor = true;
			this.buttonOpenSocket.Click += new System.EventHandler(this.ButtonOpenSocketClick);
			// 
			// buttonOpenSerial
			// 
			this.buttonOpenSerial.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOpenSerial.Location = new System.Drawing.Point(254, 4);
			this.buttonOpenSerial.Margin = new System.Windows.Forms.Padding(2);
			this.buttonOpenSerial.Name = "buttonOpenSerial";
			this.buttonOpenSerial.Size = new System.Drawing.Size(65, 26);
			this.buttonOpenSerial.TabIndex = 2;
			this.buttonOpenSerial.Text = "Open";
			this.buttonOpenSerial.UseVisualStyleBackColor = true;
			this.buttonOpenSerial.Click += new System.EventHandler(this.ButtonOpenSerialClick);
			// 
			// buttonClear
			// 
			this.buttonClear.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.buttonClear.Location = new System.Drawing.Point(0, 535);
			this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
			this.buttonClear.Name = "buttonClear";
			this.buttonClear.Size = new System.Drawing.Size(399, 26);
			this.buttonClear.TabIndex = 17;
			this.buttonClear.Text = "Clear";
			this.buttonClear.UseVisualStyleBackColor = true;
			this.buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
			// 
			// buttonWritePoint
			// 
			this.buttonWritePoint.Location = new System.Drawing.Point(2, 2);
			this.buttonWritePoint.Margin = new System.Windows.Forms.Padding(2);
			this.buttonWritePoint.Name = "buttonWritePoint";
			this.buttonWritePoint.Size = new System.Drawing.Size(94, 26);
			this.buttonWritePoint.TabIndex = 10;
			this.buttonWritePoint.Text = "Write Point";
			this.buttonWritePoint.UseVisualStyleBackColor = true;
			this.buttonWritePoint.Click += new System.EventHandler(this.ButtonWritePointClick);
			// 
			// buttonReadPoint
			// 
			this.buttonReadPoint.Location = new System.Drawing.Point(100, 2);
			this.buttonReadPoint.Margin = new System.Windows.Forms.Padding(2);
			this.buttonReadPoint.Name = "buttonReadPoint";
			this.buttonReadPoint.Size = new System.Drawing.Size(94, 26);
			this.buttonReadPoint.TabIndex = 11;
			this.buttonReadPoint.Text = "Read Point";
			this.buttonReadPoint.UseVisualStyleBackColor = true;
			this.buttonReadPoint.Click += new System.EventHandler(this.ButtonReadPointClick);
			// 
			// buttonWriteRegister
			// 
			this.buttonWriteRegister.Location = new System.Drawing.Point(198, 2);
			this.buttonWriteRegister.Margin = new System.Windows.Forms.Padding(2);
			this.buttonWriteRegister.Name = "buttonWriteRegister";
			this.buttonWriteRegister.Size = new System.Drawing.Size(94, 26);
			this.buttonWriteRegister.TabIndex = 12;
			this.buttonWriteRegister.Text = "Write Register";
			this.buttonWriteRegister.UseVisualStyleBackColor = true;
			this.buttonWriteRegister.Click += new System.EventHandler(this.ButtonWriteRegisterClick);
			// 
			// buttonReadRegister
			// 
			this.buttonReadRegister.Location = new System.Drawing.Point(296, 2);
			this.buttonReadRegister.Margin = new System.Windows.Forms.Padding(2);
			this.buttonReadRegister.Name = "buttonReadRegister";
			this.buttonReadRegister.Size = new System.Drawing.Size(94, 26);
			this.buttonReadRegister.TabIndex = 13;
			this.buttonReadRegister.Text = "Read Register";
			this.buttonReadRegister.UseVisualStyleBackColor = true;
			this.buttonReadRegister.Click += new System.EventHandler(this.ButtonReadRegisterClick);
			// 
			// panelRight
			// 
			this.panelRight.Controls.Add(this.panelContainer);
			this.panelRight.Controls.Add(this.tableLayoutPanel2);
			this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelRight.Location = new System.Drawing.Point(399, 0);
			this.panelRight.Name = "panelRight";
			this.panelRight.Size = new System.Drawing.Size(545, 561);
			this.panelRight.TabIndex = 1;
			// 
			// panelContainer
			// 
			this.panelContainer.AllowDrop = true;
			this.panelContainer.AutoScroll = true;
			this.panelContainer.BackColor = System.Drawing.Color.White;
			this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContainer.Location = new System.Drawing.Point(0, 30);
			this.panelContainer.Name = "panelContainer";
			this.panelContainer.Size = new System.Drawing.Size(545, 531);
			this.panelContainer.TabIndex = 6;
			this.panelContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelContainerDragDrop);
			this.panelContainer.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelContainerDragEnter);
			this.panelContainer.DragOver += new System.Windows.Forms.DragEventHandler(this.PanelContainerDragOver);
			// 
			// tableLayoutPanel2
			// 
			this.tableLayoutPanel2.AutoSize = true;
			this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel2.ColumnCount = 4;
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel2.Controls.Add(this.buttonReadRegister, 3, 1);
			this.tableLayoutPanel2.Controls.Add(this.buttonReadPoint, 1, 1);
			this.tableLayoutPanel2.Controls.Add(this.buttonWriteRegister, 2, 1);
			this.tableLayoutPanel2.Controls.Add(this.buttonWritePoint, 0, 1);
			this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel2.Name = "tableLayoutPanel2";
			this.tableLayoutPanel2.RowCount = 2;
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel2.Size = new System.Drawing.Size(545, 30);
			this.tableLayoutPanel2.TabIndex = 5;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(944, 561);
			this.Controls.Add(this.panelRight);
			this.Controls.Add(this.panelLeft);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MinimumSize = new System.Drawing.Size(800, 400);
			this.Name = "MainForm";
			this.Text = "SharpMaster";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.panelLeft.ResumeLayout(false);
			this.panelLeft.PerformLayout();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownClientPort)).EndInit();
			this.panelRight.ResumeLayout(false);
			this.panelRight.PerformLayout();
			this.tableLayoutPanel2.ResumeLayout(false);
			this.ResumeLayout(false);

		}
	}
}
