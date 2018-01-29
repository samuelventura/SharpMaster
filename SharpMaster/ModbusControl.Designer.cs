namespace SharpMaster
{
    partial class ModbusControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.panelLeft = new System.Windows.Forms.Panel();
            this.richTextBoxLog = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanelControls = new System.Windows.Forms.TableLayoutPanel();
            this.textBoxTcpIP = new System.Windows.Forms.TextBox();
            this.labelPort = new System.Windows.Forms.Label();
            this.linkLabelSerialRefresh = new System.Windows.Forms.LinkLabel();
            this.comboBoxSerialPortName = new System.Windows.Forms.ComboBox();
            this.labelIP = new System.Windows.Forms.Label();
            this.numericUpDownTcpPort = new System.Windows.Forms.NumericUpDown();
            this.buttonSetupSerial = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.buttonOpenSocket = new System.Windows.Forms.Button();
            this.buttonOpenSerial = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.panelRight = new System.Windows.Forms.Panel();
            this.panelContainer = new System.Windows.Forms.FlowLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonReadRegister = new System.Windows.Forms.Button();
            this.buttonReadPoint = new System.Windows.Forms.Button();
            this.buttonWriteRegister = new System.Windows.Forms.Button();
            this.buttonWritePoint = new System.Windows.Forms.Button();
            this.buttonWriteFloat = new System.Windows.Forms.Button();
            this.buttonReadFloat = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.panelLeft.SuspendLayout();
            this.tableLayoutPanelControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTcpPort)).BeginInit();
            this.panelRight.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer
            // 
            this.splitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer.Location = new System.Drawing.Point(0, 0);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.panelLeft);
            this.splitContainer.Panel1MinSize = 400;
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.panelRight);
            this.splitContainer.Size = new System.Drawing.Size(1121, 456);
            this.splitContainer.SplitterDistance = 400;
            this.splitContainer.TabIndex = 0;
            // 
            // panelLeft
            // 
            this.panelLeft.Controls.Add(this.richTextBoxLog);
            this.panelLeft.Controls.Add(this.tableLayoutPanelControls);
            this.panelLeft.Controls.Add(this.buttonClear);
            this.panelLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelLeft.Location = new System.Drawing.Point(0, 0);
            this.panelLeft.Name = "panelLeft";
            this.panelLeft.Size = new System.Drawing.Size(400, 456);
            this.panelLeft.TabIndex = 1;
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
            this.richTextBoxLog.Size = new System.Drawing.Size(400, 365);
            this.richTextBoxLog.TabIndex = 11;
            this.richTextBoxLog.Text = "";
            // 
            // tableLayoutPanelControls
            // 
            this.tableLayoutPanelControls.AutoSize = true;
            this.tableLayoutPanelControls.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanelControls.ColumnCount = 8;
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanelControls.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelControls.Controls.Add(this.textBoxTcpIP, 1, 1);
            this.tableLayoutPanelControls.Controls.Add(this.labelPort, 3, 1);
            this.tableLayoutPanelControls.Controls.Add(this.linkLabelSerialRefresh, 0, 0);
            this.tableLayoutPanelControls.Controls.Add(this.comboBoxSerialPortName, 2, 0);
            this.tableLayoutPanelControls.Controls.Add(this.labelIP, 0, 1);
            this.tableLayoutPanelControls.Controls.Add(this.numericUpDownTcpPort, 4, 1);
            this.tableLayoutPanelControls.Controls.Add(this.buttonSetupSerial, 3, 0);
            this.tableLayoutPanelControls.Controls.Add(this.buttonClose, 6, 0);
            this.tableLayoutPanelControls.Controls.Add(this.buttonOpenSocket, 5, 1);
            this.tableLayoutPanelControls.Controls.Add(this.buttonOpenSerial, 5, 0);
            this.tableLayoutPanelControls.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanelControls.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelControls.Name = "tableLayoutPanelControls";
            this.tableLayoutPanelControls.Padding = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanelControls.RowCount = 2;
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelControls.Size = new System.Drawing.Size(400, 65);
            this.tableLayoutPanelControls.TabIndex = 7;
            // 
            // textBoxTcpIP
            // 
            this.textBoxTcpIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.tableLayoutPanelControls.SetColumnSpan(this.textBoxTcpIP, 2);
            this.textBoxTcpIP.Location = new System.Drawing.Point(25, 37);
            this.textBoxTcpIP.Margin = new System.Windows.Forms.Padding(2);
            this.textBoxTcpIP.Name = "textBoxTcpIP";
            this.textBoxTcpIP.Size = new System.Drawing.Size(122, 20);
            this.textBoxTcpIP.TabIndex = 4;
            // 
            // labelPort
            // 
            this.labelPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelPort.AutoSize = true;
            this.labelPort.Location = new System.Drawing.Point(162, 41);
            this.labelPort.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPort.Name = "labelPort";
            this.labelPort.Size = new System.Drawing.Size(26, 13);
            this.labelPort.TabIndex = 5;
            this.labelPort.Text = "Port";
            this.labelPort.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // linkLabelSerialRefresh
            // 
            this.linkLabelSerialRefresh.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.linkLabelSerialRefresh.AutoSize = true;
            this.tableLayoutPanelControls.SetColumnSpan(this.linkLabelSerialRefresh, 2);
            this.linkLabelSerialRefresh.Location = new System.Drawing.Point(4, 10);
            this.linkLabelSerialRefresh.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.linkLabelSerialRefresh.Name = "linkLabelSerialRefresh";
            this.linkLabelSerialRefresh.Size = new System.Drawing.Size(60, 13);
            this.linkLabelSerialRefresh.TabIndex = 0;
            this.linkLabelSerialRefresh.TabStop = true;
            this.linkLabelSerialRefresh.Text = "Serial Ports";
            this.linkLabelSerialRefresh.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelSerialLinkClicked);
            // 
            // comboBoxSerialPortName
            // 
            this.comboBoxSerialPortName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.comboBoxSerialPortName.FormattingEnabled = true;
            this.comboBoxSerialPortName.Location = new System.Drawing.Point(68, 6);
            this.comboBoxSerialPortName.Margin = new System.Windows.Forms.Padding(2);
            this.comboBoxSerialPortName.Name = "comboBoxSerialPortName";
            this.comboBoxSerialPortName.Size = new System.Drawing.Size(90, 21);
            this.comboBoxSerialPortName.TabIndex = 1;
            // 
            // labelIP
            // 
            this.labelIP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelIP.AutoSize = true;
            this.labelIP.Location = new System.Drawing.Point(4, 41);
            this.labelIP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelIP.Name = "labelIP";
            this.labelIP.Size = new System.Drawing.Size(17, 13);
            this.labelIP.TabIndex = 3;
            this.labelIP.Text = "IP";
            this.labelIP.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // numericUpDownTcpPort
            // 
            this.numericUpDownTcpPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.numericUpDownTcpPort.Location = new System.Drawing.Point(192, 37);
            this.numericUpDownTcpPort.Margin = new System.Windows.Forms.Padding(2);
            this.numericUpDownTcpPort.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.numericUpDownTcpPort.Name = "numericUpDownTcpPort";
            this.numericUpDownTcpPort.Size = new System.Drawing.Size(57, 20);
            this.numericUpDownTcpPort.TabIndex = 6;
            // 
            // buttonSetupSerial
            // 
            this.tableLayoutPanelControls.SetColumnSpan(this.buttonSetupSerial, 2);
            this.buttonSetupSerial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonSetupSerial.Location = new System.Drawing.Point(162, 4);
            this.buttonSetupSerial.Margin = new System.Windows.Forms.Padding(2);
            this.buttonSetupSerial.Name = "buttonSetupSerial";
            this.buttonSetupSerial.Size = new System.Drawing.Size(87, 26);
            this.buttonSetupSerial.TabIndex = 2;
            this.buttonSetupSerial.Text = "Setup";
            this.buttonSetupSerial.UseVisualStyleBackColor = true;
            this.buttonSetupSerial.Click += new System.EventHandler(this.ButtonSetupSerialClick);
            // 
            // buttonClose
            // 
            this.buttonClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonClose.Location = new System.Drawing.Point(322, 4);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClose.Name = "buttonClose";
            this.tableLayoutPanelControls.SetRowSpan(this.buttonClose, 2);
            this.buttonClose.Size = new System.Drawing.Size(73, 57);
            this.buttonClose.TabIndex = 8;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.ButtonCloseClick);
            // 
            // buttonOpenSocket
            // 
            this.buttonOpenSocket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buttonOpenSocket.Location = new System.Drawing.Point(253, 34);
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
            this.buttonOpenSerial.Location = new System.Drawing.Point(253, 4);
            this.buttonOpenSerial.Margin = new System.Windows.Forms.Padding(2);
            this.buttonOpenSerial.Name = "buttonOpenSerial";
            this.buttonOpenSerial.Size = new System.Drawing.Size(65, 26);
            this.buttonOpenSerial.TabIndex = 3;
            this.buttonOpenSerial.Text = "Open";
            this.buttonOpenSerial.UseVisualStyleBackColor = true;
            this.buttonOpenSerial.Click += new System.EventHandler(this.ButtonOpenSerialClick);
            // 
            // buttonClear
            // 
            this.buttonClear.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonClear.Location = new System.Drawing.Point(0, 430);
            this.buttonClear.Margin = new System.Windows.Forms.Padding(2);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(400, 26);
            this.buttonClear.TabIndex = 10;
            this.buttonClear.Text = "Clear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.ButtonClearClick);
            // 
            // panelRight
            // 
            this.panelRight.Controls.Add(this.panelContainer);
            this.panelRight.Controls.Add(this.tableLayoutPanel2);
            this.panelRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelRight.Location = new System.Drawing.Point(0, 0);
            this.panelRight.Name = "panelRight";
            this.panelRight.Size = new System.Drawing.Size(717, 456);
            this.panelRight.TabIndex = 2;
            // 
            // panelContainer
            // 
            this.panelContainer.AllowDrop = true;
            this.panelContainer.AutoScroll = true;
            this.panelContainer.BackColor = System.Drawing.Color.White;
            this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContainer.Location = new System.Drawing.Point(0, 30);
            this.panelContainer.Name = "panelContainer";
            this.panelContainer.Size = new System.Drawing.Size(717, 426);
            this.panelContainer.TabIndex = 30;
            this.panelContainer.DragDrop += new System.Windows.Forms.DragEventHandler(this.PanelContainerDragDrop);
            this.panelContainer.DragEnter += new System.Windows.Forms.DragEventHandler(this.PanelContainerDragEnter);
            this.panelContainer.DragOver += new System.Windows.Forms.DragEventHandler(this.PanelContainerDragOver);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.AutoSize = true;
            this.tableLayoutPanel2.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel2.ColumnCount = 6;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.buttonReadRegister, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonReadPoint, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonWriteRegister, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonWritePoint, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonWriteFloat, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.buttonReadFloat, 5, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(717, 30);
            this.tableLayoutPanel2.TabIndex = 5;
            // 
            // buttonReadRegister
            // 
            this.buttonReadRegister.Location = new System.Drawing.Point(296, 2);
            this.buttonReadRegister.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReadRegister.Name = "buttonReadRegister";
            this.buttonReadRegister.Size = new System.Drawing.Size(94, 26);
            this.buttonReadRegister.TabIndex = 23;
            this.buttonReadRegister.Text = "Read Register";
            this.buttonReadRegister.UseVisualStyleBackColor = true;
            this.buttonReadRegister.Click += new System.EventHandler(this.ButtonReadRegisterClick);
            // 
            // buttonReadPoint
            // 
            this.buttonReadPoint.Location = new System.Drawing.Point(100, 2);
            this.buttonReadPoint.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReadPoint.Name = "buttonReadPoint";
            this.buttonReadPoint.Size = new System.Drawing.Size(94, 26);
            this.buttonReadPoint.TabIndex = 21;
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
            this.buttonWriteRegister.TabIndex = 22;
            this.buttonWriteRegister.Text = "Write Register";
            this.buttonWriteRegister.UseVisualStyleBackColor = true;
            this.buttonWriteRegister.Click += new System.EventHandler(this.ButtonWriteRegisterClick);
            // 
            // buttonWritePoint
            // 
            this.buttonWritePoint.Location = new System.Drawing.Point(2, 2);
            this.buttonWritePoint.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWritePoint.Name = "buttonWritePoint";
            this.buttonWritePoint.Size = new System.Drawing.Size(94, 26);
            this.buttonWritePoint.TabIndex = 20;
            this.buttonWritePoint.Text = "Write Point";
            this.buttonWritePoint.UseVisualStyleBackColor = true;
            this.buttonWritePoint.Click += new System.EventHandler(this.ButtonWritePointClick);
            // 
            // buttonWriteFloat
            // 
            this.buttonWriteFloat.Location = new System.Drawing.Point(394, 2);
            this.buttonWriteFloat.Margin = new System.Windows.Forms.Padding(2);
            this.buttonWriteFloat.Name = "buttonWriteFloat";
            this.buttonWriteFloat.Size = new System.Drawing.Size(94, 26);
            this.buttonWriteFloat.TabIndex = 24;
            this.buttonWriteFloat.Text = "Write Float";
            this.buttonWriteFloat.UseVisualStyleBackColor = true;
            this.buttonWriteFloat.Click += new System.EventHandler(this.ButtonWriteFloatClick);
            // 
            // buttonReadFloat
            // 
            this.buttonReadFloat.Location = new System.Drawing.Point(492, 2);
            this.buttonReadFloat.Margin = new System.Windows.Forms.Padding(2);
            this.buttonReadFloat.Name = "buttonReadFloat";
            this.buttonReadFloat.Size = new System.Drawing.Size(94, 26);
            this.buttonReadFloat.TabIndex = 25;
            this.buttonReadFloat.Text = "Read Float";
            this.buttonReadFloat.UseVisualStyleBackColor = true;
            this.buttonReadFloat.Click += new System.EventHandler(this.ButtonReadFloatClick);
            // 
            // ModbusControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainer);
            this.Name = "ModbusControl";
            this.Size = new System.Drawing.Size(1121, 456);
            this.Load += new System.EventHandler(this.ModbusControl_Load);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.panelLeft.ResumeLayout(false);
            this.panelLeft.PerformLayout();
            this.tableLayoutPanelControls.ResumeLayout(false);
            this.tableLayoutPanelControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownTcpPort)).EndInit();
            this.panelRight.ResumeLayout(false);
            this.panelRight.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.Panel panelLeft;
        private System.Windows.Forms.RichTextBox richTextBoxLog;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelControls;
        private System.Windows.Forms.TextBox textBoxTcpIP;
        private System.Windows.Forms.Label labelPort;
        private System.Windows.Forms.LinkLabel linkLabelSerialRefresh;
        private System.Windows.Forms.ComboBox comboBoxSerialPortName;
        private System.Windows.Forms.Label labelIP;
        private System.Windows.Forms.NumericUpDown numericUpDownTcpPort;
        private System.Windows.Forms.Button buttonSetupSerial;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.Button buttonOpenSocket;
        private System.Windows.Forms.Button buttonOpenSerial;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Panel panelRight;
        private System.Windows.Forms.FlowLayoutPanel panelContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button buttonReadRegister;
        private System.Windows.Forms.Button buttonReadPoint;
        private System.Windows.Forms.Button buttonWriteRegister;
        private System.Windows.Forms.Button buttonWritePoint;
        private System.Windows.Forms.Button buttonWriteFloat;
        private System.Windows.Forms.Button buttonReadFloat;
    }
}
