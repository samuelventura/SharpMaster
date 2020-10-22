
namespace SharpMaster
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.ToolTip toolTip;
		
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
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.toolStrip = new System.Windows.Forms.ToolStrip();
            this.newToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.cloneToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.renameToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.saveToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.exportAllToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.exportSelectedToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.importToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.removeToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.ModbusControl1 = new SharpMaster.ModbusControl();
            this.shiftRightToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.shiftLeftToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip
            // 
            this.toolStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripButton,
            this.cloneToolStripButton,
            this.renameToolStripButton,
            this.saveToolStripButton,
            this.toolStripSeparator3,
            this.shiftLeftToolStripButton,
            this.shiftRightToolStripButton,
            this.toolStripSeparator2,
            this.exportAllToolStripButton,
            this.exportSelectedToolStripButton,
            this.importToolStripButton,
            this.toolStripSeparator1,
            this.removeToolStripButton});
            this.toolStrip.Location = new System.Drawing.Point(0, 0);
            this.toolStrip.Name = "toolStrip";
            this.toolStrip.Size = new System.Drawing.Size(1114, 25);
            this.toolStrip.TabIndex = 1;
            this.toolStrip.Text = "toolStrip1";
            // 
            // newToolStripButton
            // 
            this.newToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.newToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("newToolStripButton.Image")));
            this.newToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newToolStripButton.Name = "newToolStripButton";
            this.newToolStripButton.Size = new System.Drawing.Size(35, 22);
            this.newToolStripButton.Text = "New";
            this.newToolStripButton.ToolTipText = "Create New Empty Session";
            this.newToolStripButton.Click += new System.EventHandler(this.NewToolStripButton_Click);
            // 
            // cloneToolStripButton
            // 
            this.cloneToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.cloneToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("cloneToolStripButton.Image")));
            this.cloneToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cloneToolStripButton.Name = "cloneToolStripButton";
            this.cloneToolStripButton.Size = new System.Drawing.Size(42, 22);
            this.cloneToolStripButton.Text = "Clone";
            this.cloneToolStripButton.ToolTipText = "Clone Selected Session";
            this.cloneToolStripButton.Click += new System.EventHandler(this.CloneToolStripButton_Click);
            // 
            // renameToolStripButton
            // 
            this.renameToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.renameToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("renameToolStripButton.Image")));
            this.renameToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.renameToolStripButton.Name = "renameToolStripButton";
            this.renameToolStripButton.Size = new System.Drawing.Size(54, 22);
            this.renameToolStripButton.Text = "Rename";
            this.renameToolStripButton.ToolTipText = "Rename Selected Session";
            this.renameToolStripButton.Click += new System.EventHandler(this.RenameToolStripButton_Click);
            // 
            // saveToolStripButton
            // 
            this.saveToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.saveToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("saveToolStripButton.Image")));
            this.saveToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.saveToolStripButton.Name = "saveToolStripButton";
            this.saveToolStripButton.Size = new System.Drawing.Size(35, 22);
            this.saveToolStripButton.Text = "Save";
            this.saveToolStripButton.ToolTipText = "Save Sessions";
            this.saveToolStripButton.Click += new System.EventHandler(this.SaveToolStripButton_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // exportAllToolStripButton
            // 
            this.exportAllToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportAllToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("exportAllToolStripButton.Image")));
            this.exportAllToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportAllToolStripButton.Name = "exportAllToolStripButton";
            this.exportAllToolStripButton.Size = new System.Drawing.Size(62, 22);
            this.exportAllToolStripButton.Text = "Export All";
            this.exportAllToolStripButton.ToolTipText = "Export All Sessions to File";
            this.exportAllToolStripButton.Click += new System.EventHandler(this.ExportAllToolStripButton_Click);
            // 
            // exportSelectedToolStripButton
            // 
            this.exportSelectedToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.exportSelectedToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("exportSelectedToolStripButton.Image")));
            this.exportSelectedToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exportSelectedToolStripButton.Name = "exportSelectedToolStripButton";
            this.exportSelectedToolStripButton.Size = new System.Drawing.Size(92, 22);
            this.exportSelectedToolStripButton.Text = "Export Selected";
            this.exportSelectedToolStripButton.ToolTipText = "Export Selected Session to File";
            this.exportSelectedToolStripButton.Click += new System.EventHandler(this.ExportSelectedToolStripButton_Click);
            // 
            // importToolStripButton
            // 
            this.importToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.importToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("importToolStripButton.Image")));
            this.importToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.importToolStripButton.Name = "importToolStripButton";
            this.importToolStripButton.Size = new System.Drawing.Size(47, 22);
            this.importToolStripButton.Text = "Import";
            this.importToolStripButton.ToolTipText = "Import Sessions from File";
            this.importToolStripButton.Click += new System.EventHandler(this.ImportToolStripButton_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // removeToolStripButton
            // 
            this.removeToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.removeToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("removeToolStripButton.Image")));
            this.removeToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.removeToolStripButton.Name = "removeToolStripButton";
            this.removeToolStripButton.Size = new System.Drawing.Size(54, 22);
            this.removeToolStripButton.Text = "Remove";
            this.removeToolStripButton.ToolTipText = "Remove Selected Session";
            this.removeToolStripButton.Click += new System.EventHandler(this.RemoveToolStripButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 565);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1114, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(158, 17);
            this.toolStripStatusLabel.Text = "/home/user/db.SharpMaster";
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPage1);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 25);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1114, 540);
            this.tabControl.TabIndex = 4;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.ModbusControl1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1106, 514);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Session 1";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // ModbusControl1
            // 
            this.ModbusControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ModbusControl1.Location = new System.Drawing.Point(3, 3);
            this.ModbusControl1.MinimumSize = new System.Drawing.Size(620, 500);
            this.ModbusControl1.Name = "ModbusControl1";
            this.ModbusControl1.Size = new System.Drawing.Size(1100, 508);
            this.ModbusControl1.TabIndex = 0;
            // 
            // shiftRightToolStripButton
            // 
            this.shiftRightToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.shiftRightToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("shiftRightToolStripButton.Image")));
            this.shiftRightToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shiftRightToolStripButton.Name = "shiftRightToolStripButton";
            this.shiftRightToolStripButton.Size = new System.Drawing.Size(50, 22);
            this.shiftRightToolStripButton.Text = "Right >";
            this.shiftRightToolStripButton.ToolTipText = "Shift Right";
            this.shiftRightToolStripButton.Click += new System.EventHandler(this.ShiftRightToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // shiftLeftToolStripButton
            // 
            this.shiftLeftToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.shiftLeftToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("shiftLeftToolStripButton.Image")));
            this.shiftLeftToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.shiftLeftToolStripButton.Name = "shiftLeftToolStripButton";
            this.shiftLeftToolStripButton.Size = new System.Drawing.Size(42, 22);
            this.shiftLeftToolStripButton.Text = "< Left";
            this.shiftLeftToolStripButton.ToolTipText = "Shift Left";
            this.shiftLeftToolStripButton.Click += new System.EventHandler(this.ShiftLeftToolStripButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1114, 587);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(714, 308);
            this.Name = "MainForm";
            this.Text = "SharpMaster";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
            this.Load += new System.EventHandler(this.MainFormLoad);
            this.toolStrip.ResumeLayout(false);
            this.toolStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
        private System.Windows.Forms.ToolStrip toolStrip;
        private System.Windows.Forms.ToolStripButton newToolStripButton;
        private System.Windows.Forms.ToolStripButton cloneToolStripButton;
        private System.Windows.Forms.ToolStripButton renameToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton removeToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton exportSelectedToolStripButton;
        private System.Windows.Forms.ToolStripButton importToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private ModbusControl ModbusControl1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripButton exportAllToolStripButton;
        private System.Windows.Forms.ToolStripButton saveToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton shiftLeftToolStripButton;
        private System.Windows.Forms.ToolStripButton shiftRightToolStripButton;
    }
}
