using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO.Ports;

namespace SharpMaster.Tools
{
	public partial class SerialSettingsForm : Form
	{		
		public SerialSettingsForm(SerialSettings settings)
		{
			InitializeComponent();
			propertyGrid.SelectedObject = settings;
		}
	}
}
