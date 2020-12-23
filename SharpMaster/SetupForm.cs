using System;
using System.Windows.Forms;
using SharpTabs;
using SharpMaster.Tools;

namespace SharpMaster
{
	public partial class SetupForm : Form
	{
		public SetupForm()
		{
			InitializeComponent();
		}
		
		void MainFormLoad(object sender, EventArgs e)
		{
			Icon = TabsTools.ExeIcon();
		}

		public void Edit(SerialSettings oldObject)
		{
			Text = "Serial Port Settings";
			var newObject = oldObject.Clone();
			propertyGrid.SelectedObject = newObject;
			if (ShowDialog() == DialogResult.OK)
			{
				newObject.CopyTo(oldObject);
			}
		}

		public MasterConfig Edit(MasterConfig oldObject)
		{
			Text = "Master Setup";
			var newObject = oldObject.Clone();
			propertyGrid.SelectedObject = newObject;
			if (ShowDialog() == DialogResult.OK)
			{
				return newObject;
			}
			return oldObject;
		}
	}
}
