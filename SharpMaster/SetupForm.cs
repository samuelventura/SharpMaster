using System;
using System.Windows.Forms;

namespace SharpMaster
{
	public partial class SetupForm : Form
	{
		public MasterConfig Config { get; set; } = new MasterConfig();

		public SetupForm()
		{
			InitializeComponent();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			propertyGrid.SelectedObject = Config;
		}
		
		void ButtonOkClick(object sender, EventArgs e)
		{
			Config = (MasterConfig)propertyGrid.SelectedObject;
		}
	}
}
