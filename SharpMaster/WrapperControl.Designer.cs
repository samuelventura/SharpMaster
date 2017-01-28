
namespace SharpMaster
{
	partial class WrapperControl
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.LinkLabel linkLabelRemove;
		private System.Windows.Forms.ToolTip toolTip;
		private System.Windows.Forms.Panel panelTop;
		private System.Windows.Forms.Label labelTitle;
		private System.Windows.Forms.Panel panelContainer;
		private System.Windows.Forms.Label labelDrag;
		
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
			this.components = new System.ComponentModel.Container();
			this.toolTip = new System.Windows.Forms.ToolTip(this.components);
			this.linkLabelRemove = new System.Windows.Forms.LinkLabel();
			this.labelDrag = new System.Windows.Forms.Label();
			this.panelTop = new System.Windows.Forms.Panel();
			this.labelTitle = new System.Windows.Forms.Label();
			this.panelContainer = new System.Windows.Forms.Panel();
			this.panelTop.SuspendLayout();
			this.SuspendLayout();
			// 
			// linkLabelRemove
			// 
			this.linkLabelRemove.ActiveLinkColor = System.Drawing.Color.DarkRed;
			this.linkLabelRemove.AutoSize = true;
			this.linkLabelRemove.BackColor = System.Drawing.Color.Transparent;
			this.linkLabelRemove.Dock = System.Windows.Forms.DockStyle.Left;
			this.linkLabelRemove.LinkBehavior = System.Windows.Forms.LinkBehavior.NeverUnderline;
			this.linkLabelRemove.LinkColor = System.Drawing.Color.DarkRed;
			this.linkLabelRemove.Location = new System.Drawing.Point(0, 4);
			this.linkLabelRemove.Margin = new System.Windows.Forms.Padding(0);
			this.linkLabelRemove.Name = "linkLabelRemove";
			this.linkLabelRemove.Size = new System.Drawing.Size(47, 13);
			this.linkLabelRemove.TabIndex = 4;
			this.linkLabelRemove.TabStop = true;
			this.linkLabelRemove.Text = "Remove";
			this.linkLabelRemove.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.toolTip.SetToolTip(this.linkLabelRemove, "Click to remove");
			this.linkLabelRemove.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkLabelRemoveLinkClicked);
			// 
			// labelDrag
			// 
			this.labelDrag.AutoSize = true;
			this.labelDrag.BackColor = System.Drawing.Color.Transparent;
			this.labelDrag.Cursor = System.Windows.Forms.Cursors.Hand;
			this.labelDrag.Dock = System.Windows.Forms.DockStyle.Right;
			this.labelDrag.ForeColor = System.Drawing.Color.DodgerBlue;
			this.labelDrag.Location = new System.Drawing.Point(404, 4);
			this.labelDrag.Name = "labelDrag";
			this.labelDrag.Size = new System.Drawing.Size(30, 13);
			this.labelDrag.TabIndex = 7;
			this.labelDrag.Text = "Drag";
			this.toolTip.SetToolTip(this.labelDrag, "Drag to reorder");
			this.labelDrag.MouseDown += new System.Windows.Forms.MouseEventHandler(this.LabelDragMouseDown);
			// 
			// panelTop
			// 
			this.panelTop.AutoSize = true;
			this.panelTop.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
			this.panelTop.BackColor = System.Drawing.Color.FloralWhite;
			this.panelTop.Controls.Add(this.labelDrag);
			this.panelTop.Controls.Add(this.labelTitle);
			this.panelTop.Controls.Add(this.linkLabelRemove);
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelTop.Location = new System.Drawing.Point(0, 0);
			this.panelTop.Margin = new System.Windows.Forms.Padding(0);
			this.panelTop.Name = "panelTop";
			this.panelTop.Padding = new System.Windows.Forms.Padding(0, 4, 0, 4);
			this.panelTop.Size = new System.Drawing.Size(434, 21);
			this.panelTop.TabIndex = 5;
			// 
			// labelTitle
			// 
			this.labelTitle.AutoSize = true;
			this.labelTitle.BackColor = System.Drawing.Color.Transparent;
			this.labelTitle.Dock = System.Windows.Forms.DockStyle.Fill;
			this.labelTitle.Location = new System.Drawing.Point(47, 4);
			this.labelTitle.Name = "labelTitle";
			this.labelTitle.Size = new System.Drawing.Size(27, 13);
			this.labelTitle.TabIndex = 5;
			this.labelTitle.Text = "Title";
			this.labelTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelContainer
			// 
			this.panelContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelContainer.Location = new System.Drawing.Point(0, 21);
			this.panelContainer.Name = "panelContainer";
			this.panelContainer.Size = new System.Drawing.Size(434, 76);
			this.panelContainer.TabIndex = 6;
			// 
			// WrapperControl
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.panelContainer);
			this.Controls.Add(this.panelTop);
			this.Name = "WrapperControl";
			this.Size = new System.Drawing.Size(434, 97);
			this.panelTop.ResumeLayout(false);
			this.panelTop.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
