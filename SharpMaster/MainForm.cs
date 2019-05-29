using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace SharpMaster
{
	public partial class MainForm : Form
	{
        private readonly SessionDao sessionDao;

		public MainForm(string dbPath = null)
		{
            sessionDao = new SessionDao(dbPath);

			InitializeComponent();

            toolStripStatusLabel.Text = sessionDao.DbPath;
        }

        private void AddSession(SessionSettings session)
        {
            var tabPage = new TabPage
            {
                Text = session.Name
            };
            var modbusControl = new ModbusControl
            {
                Dock = DockStyle.Fill
            };
            tabPage.Controls.Add(modbusControl);
            tabControl.TabPages.Add(tabPage);
            modbusControl.ToUI(session);
            tabControl.SelectedTab = tabPage;
        }

        private ModbusControl GetTerminal(TabPage tabPage)
        {
            //Tag not used to make it compatible with designer added tabs
            return (ModbusControl)tabPage.Controls[0];
        }

        private ModbusControl GetSettings(TabPage tabPage, SessionSettings session)
        {
            var modbusControl = GetTerminal(tabPage);
            modbusControl.FromUI(session);
            session.Name = tabPage.Text;
            return modbusControl;
        }

        private List<SessionSettings> GetSessionList()
        {
            var sessions = new List<SessionSettings>();
            foreach (TabPage tabPage in tabControl.TabPages)
            {
                var session = new SessionSettings();
                var modbusControl = GetSettings(tabPage, session);
                modbusControl.Unload();
                sessions.Add(session);
            }
            return sessions;
        }

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
            var live = GetSessionList();
            var stored = sessionDao.Load();

            foreach (var session in stored) session.Id = 0;

            var storedJSON = JsonConvert.SerializeObject(stored);
            var liveJSON = JsonConvert.SerializeObject(live);
            if (storedJSON != liveJSON)
            {
                //System.IO.File.WriteAllText(SharpMaster.Tools.Executable.Relative("storedJSON.txt"), storedJSON);
                //System.IO.File.WriteAllText(SharpMaster.Tools.Executable.Relative("liveJSON.txt"), liveJSON);

                var result = MessageBox.Show(this, "Save changes before closing?",
                                     "Detected changes will be lost",
                                     MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    sessionDao.Save(live);
                }
            }
		}
	
		void MainFormLoad(object sender, EventArgs e)
		{
			Text = string.Format("SharpMaster - 1.0.4 https://github.com/samuelventura/SharpMaster");

            var sessions = sessionDao.Load();

            if (sessions.Count == 0)
            {
                sessions.Add(new SessionSettings());
            }
            
            //remove design default
            removeToolStripButton.PerformClick();

            foreach (var session in sessions)
            {
                AddSession(session);
            }

            tabControl.SelectedIndex = 0;
        }

        private void NewToolStripButton_Click(object sender, EventArgs e)
        {
            AddSession(new SessionSettings());
        }

        private void CloneToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage != null)
            {
                var session = new SessionSettings();
                var modbusControl = GetSettings(selectedPage, session);
                AddSession(session);
            }
        }

        private void RenameToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage != null)
            { 
                var form = new RenameForm();
                form.textBox.Text = selectedPage.Text;
                if (DialogResult.OK == form.ShowDialog())
                {
                    selectedPage.Text = form.textBox.Text;
                }
            }
        }

        private void RemoveToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage != null)
            {
                var modbusControl = GetTerminal(selectedPage);
                modbusControl.Unload();
                tabControl.TabPages.Remove(selectedPage);
            }
        }

        private void ExportSelectedToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage == null) return;

            var fd = new SaveFileDialog
            {
                Title = "Export to SharpMaster File",
                Filter = "LiteDB Files (*.SharpMaster)|*.SharpMaster",
                OverwritePrompt = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var session = new SessionSettings();
                var list = new List<SessionSettings>();
                list.Add(session);
                GetSettings(selectedPage, session);
                var dao = new SessionDao(fd.FileName);
                dao.Save(list);
            }
        }

        private void ExportAllToolStripButton_Click(object sender, EventArgs e)
        {
            if (tabControl.TabPages.Count == 0) return;

            var fd = new SaveFileDialog
            {
                Title = "Export to SharpMaster File",
                Filter = "LiteDB Files (*.SharpMaster)|*.SharpMaster",
                OverwritePrompt = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var dao = new SessionDao(fd.FileName);
                dao.Save(GetSessionList());
            }
        }

        private void ImportToolStripButton_Click(object sender, EventArgs e)
        {
            var fd = new OpenFileDialog
            {
                Title = "Import from SharpMaster File",
                Filter = "LiteDB Files (*.SharpMaster)|*.SharpMaster",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true
            };
            if (fd.ShowDialog() == DialogResult.OK)
            {
                var dao = new SessionDao(fd.FileName);
                foreach (var session in dao.Load())
                {
                    AddSession(session);
                }
            }
        }
    }
}
