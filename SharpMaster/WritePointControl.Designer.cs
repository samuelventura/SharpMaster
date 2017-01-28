
namespace SharpMaster
{
	partial class WritePointControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.NumericUpDown numericUpDownSlaveAddress;
		private System.Windows.Forms.Button buttonOn;
		private System.Windows.Forms.Button buttonOff;
		private System.Windows.Forms.NumericUpDown numericUpDownStartAddress;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.ComboBox comboBoxFunctionCode;
		
		/// <summary>
		/// Disposes resources used by the control.
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
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDownSlaveAddress = new System.Windows.Forms.NumericUpDown();
			this.label2 = new System.Windows.Forms.Label();
			this.buttonOff = new System.Windows.Forms.Button();
			this.buttonOn = new System.Windows.Forms.Button();
			this.numericUpDownStartAddress = new System.Windows.Forms.NumericUpDown();
			this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
			this.label4 = new System.Windows.Forms.Label();
			this.comboBoxFunctionCode = new System.Windows.Forms.ComboBox();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveAddress)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartAddress)).BeginInit();
			this.tableLayoutPanel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(87, 0);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(34, 13);
			this.label1.TabIndex = 6;
			this.label1.Text = "Slave";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// numericUpDownSlaveAddress
			// 
			this.numericUpDownSlaveAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.numericUpDownSlaveAddress.Location = new System.Drawing.Point(87, 17);
			this.numericUpDownSlaveAddress.Maximum = new decimal(new int[] {
			255,
			0,
			0,
			0});
			this.numericUpDownSlaveAddress.Name = "numericUpDownSlaveAddress";
			this.numericUpDownSlaveAddress.Size = new System.Drawing.Size(57, 20);
			this.numericUpDownSlaveAddress.TabIndex = 7;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(150, 0);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(45, 13);
			this.label2.TabIndex = 10;
			this.label2.Text = "Address";
			// 
			// buttonOff
			// 
			this.buttonOff.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOff.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOff.Location = new System.Drawing.Point(298, 16);
			this.buttonOff.Name = "buttonOff";
			this.buttonOff.Size = new System.Drawing.Size(68, 22);
			this.buttonOff.TabIndex = 9;
			this.buttonOff.Text = "Off";
			this.buttonOff.UseVisualStyleBackColor = true;
			this.buttonOff.Click += new System.EventHandler(this.ButtonOffClick);
			// 
			// buttonOn
			// 
			this.buttonOn.Dock = System.Windows.Forms.DockStyle.Fill;
			this.buttonOn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.buttonOn.Location = new System.Drawing.Point(224, 16);
			this.buttonOn.Name = "buttonOn";
			this.buttonOn.Size = new System.Drawing.Size(68, 22);
			this.buttonOn.TabIndex = 8;
			this.buttonOn.Text = "On";
			this.buttonOn.UseVisualStyleBackColor = true;
			this.buttonOn.Click += new System.EventHandler(this.ButtonOnClick);
			// 
			// numericUpDownStartAddress
			// 
			this.numericUpDownStartAddress.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.numericUpDownStartAddress.Location = new System.Drawing.Point(150, 17);
			this.numericUpDownStartAddress.Maximum = new decimal(new int[] {
			65535,
			0,
			0,
			0});
			this.numericUpDownStartAddress.Name = "numericUpDownStartAddress";
			this.numericUpDownStartAddress.Size = new System.Drawing.Size(68, 20);
			this.numericUpDownStartAddress.TabIndex = 11;
			// 
			// tableLayoutPanel1
			// 
			this.tableLayoutPanel1.AutoSize = true;
			this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.tableLayoutPanel1.ColumnCount = 5;
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
			this.tableLayoutPanel1.Controls.Add(this.buttonOff, 4, 1);
			this.tableLayoutPanel1.Controls.Add(this.label2, 2, 0);
			this.tableLayoutPanel1.Controls.Add(this.label1, 1, 0);
			this.tableLayoutPanel1.Controls.Add(this.buttonOn, 3, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownSlaveAddress, 1, 1);
			this.tableLayoutPanel1.Controls.Add(this.numericUpDownStartAddress, 2, 1);
			this.tableLayoutPanel1.Controls.Add(this.label4, 0, 0);
			this.tableLayoutPanel1.Controls.Add(this.comboBoxFunctionCode, 0, 1);
			this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
			this.tableLayoutPanel1.Name = "tableLayoutPanel1";
			this.tableLayoutPanel1.RowCount = 2;
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
			this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 41);
			this.tableLayoutPanel1.TabIndex = 12;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(3, 0);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 13);
			this.label4.TabIndex = 21;
			this.label4.Text = "Function";
			// 
			// comboBoxFunctionCode
			// 
			this.comboBoxFunctionCode.Anchor = System.Windows.Forms.AnchorStyles.Left;
			this.comboBoxFunctionCode.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBoxFunctionCode.FormattingEnabled = true;
			this.comboBoxFunctionCode.Items.AddRange(new object[] {
			"5 Coil"});
			this.comboBoxFunctionCode.Location = new System.Drawing.Point(3, 16);
			this.comboBoxFunctionCode.Name = "comboBoxFunctionCode";
			this.comboBoxFunctionCode.Size = new System.Drawing.Size(78, 21);
			this.comboBoxFunctionCode.TabIndex = 22;
			// 
			// WritePointControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.AutoSize = true;
			this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.Controls.Add(this.tableLayoutPanel1);
			this.Name = "WritePointControl";
			this.Size = new System.Drawing.Size(372, 44);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownSlaveAddress)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDownStartAddress)).EndInit();
			this.tableLayoutPanel1.ResumeLayout(false);
			this.tableLayoutPanel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
