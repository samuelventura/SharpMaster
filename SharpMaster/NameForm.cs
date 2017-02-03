using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace SharpMaster
{
	public partial class NameForm : Form
	{
		private readonly Regex re = new Regex(@"[^a-zA-Z0-9_ ]");
		
		public NameForm()
		{
			InitializeComponent();
		}
		
		public string ItemName {
			get { return  textBoxName.Text.Trim(); }
			set { textBoxName.Text = value ; }
		}
		
		private void UpdateButtons()
		{
			var empty = textBoxName.Text.Trim().Length == 0;
			buttonAccept.Enabled = !empty;
		}
		
		void SelectFormLoad(object sender, EventArgs e)
		{
			UpdateButtons();
		}
		
		void TextBoxNameTextChanged(object sender, EventArgs e)
		{
			UpdateButtons();
		}
		
		void TextBoxNameValidating(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = re.IsMatch(textBoxName.Text);
		}
		
		void TextBoxNameKeyPress(object sender, KeyPressEventArgs e)
		{
			//Delete works but Backspace requires IsControl check
			e.Handled = !char.IsControl(e.KeyChar) && re.IsMatch(e.KeyChar.ToString());
		}
	}
}
