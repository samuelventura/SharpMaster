using System;
using System.Text;
using System.Windows.Forms;

namespace SharpMaster
{
	public partial class WrapperControl : UserControl
	{
		private readonly Action<WrapperControl> action;
		private readonly Control control;
		
		public WrapperControl(Control control, Action<WrapperControl> action)
		{
			this.control = control;
			this.action = action;
			
			InitializeComponent();
			
			panelContainer.Controls.Add(control);
			labelTitle.Text = SplitTitle(control.GetType().Name);
			Height = control.Height + panelTop.Height;
			Width = control.Width;
		}
		
		public Control Control { get { return control; } }
		
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
