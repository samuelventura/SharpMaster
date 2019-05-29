
using System;
using System.Windows.Forms;
using SharpMaster.Tools;

namespace SharpMaster
{
	internal sealed class Program
	{
		[STAThread]
		private static void Main(string[] args)
		{
            var dbPath = args.Length > 0 ? args[0] : null;
			Application.EnableVisualStyles();
            Application.ThreadException += (s, t) =>
            {
                var msg = string.Format("{0} {1}", t.Exception.GetType().Name, t.Exception.Message);
                Thrower.Dump(t.Exception);
                MessageBox.Show(msg, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            };
            Application.SetCompatibleTextRenderingDefault(false);
			Application.Run(new MainForm(dbPath));
		}
		
	}
}
