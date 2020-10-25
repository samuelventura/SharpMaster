
using System;
using System.Text;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SharpMaster
{
	/// <summary>
	/// Description of WrapperControl.
	/// </summary>
	public partial class WrapperControl : UserControl
	{
		private readonly Control payload;
		private readonly Action<Control> action;
		
		public WrapperControl(Control payload, Action<Control> action)
		{
			this.payload = payload;
			this.action = action;
			
			InitializeComponent();
			
			panelContainer.Controls.Add(payload);
			labelTitle.Text = SplitTitle(payload.GetType().Name);
			Height = payload.Height + panelTop.Height;
			Width = payload.Width;
		}
		
		public Control Payload {
			get { return payload; }
		}
		
		public string ItemName {
			get { return labelName.Text; }
			set { labelName.Text = value; }
		}
		
		private string SplitTitle(string text)
		{
			var title = text.Replace("Control", "");
			var sb = new StringBuilder();
			foreach (var c in title) {
				if (char.IsUpper(c))
					sb.Append(" ");
				sb.Append(c);
			}
			return sb.ToString();
		}
		
		void LinkLabelRemoveLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			action(this);
        }

        void LinkLabelNameClick(object sender, EventArgs e)
        {
            var form = new NameForm();
            form.ItemName = labelName.Text;
            if (form.ShowDialog() == DialogResult.OK)
            {
                labelName.Text = form.ItemName;
            }
        }

        void LabelDragMouseDown(object sender, MouseEventArgs e)
		{
			DoDragDrop(this, DragDropEffects.Move);
		}
	}
}
