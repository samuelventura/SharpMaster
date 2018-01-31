using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;
using LiteDB;

namespace SharpMaster
{
	public partial class MainForm : Form
	{
        private readonly SessionDao dao = new SessionDao();

		public MainForm()
		{
			InitializeComponent();
		}

        private void AddSession(SessionSettings session)
        {
            var tabPage = new TabPage
            {
                Text = session.Name
            };
            var ModbusControl = new ModbusControl
            {
                Dock = DockStyle.Fill
            };
            tabPage.Controls.Add(ModbusControl);
            tabControl.TabPages.Add(tabPage);
            ModbusControl.ToUI(session);
            tabControl.SelectedTab = tabPage;
        }

        private ModbusControl GetTerminal(TabPage tabPage)
        {
            //Tag not used to make it compatible with designer added tabs
            return (ModbusControl)tabPage.Controls[0];
        }

        private ModbusControl GetSettings(TabPage tabPage, SessionSettings session)
        {
            var ModbusControl = GetTerminal(tabPage);
            ModbusControl.FromUI(session);
            session.Name = tabPage.Text;
            return ModbusControl;
        }

        void MainFormFormClosed(object sender, FormClosedEventArgs e)
		{
            var sessions = new List<SessionSettings>();
            foreach(TabPage tabPage in tabControl.TabPages)
            {
                var session = new SessionSettings();
                var ModbusControl = GetSettings(tabPage, session);
                ModbusControl.Unload();
                sessions.Add(session);
            }
            dao.Save(sessions);
		}
	
		void MainFormLoad(object sender, EventArgs e)
		{
			Text = string.Format("SharpMaster - 1.0.1 https://github.com/samuelventura/SharpMaster");

            var sessions = dao.Load();

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
                var ModbusControl = GetSettings(selectedPage, session);
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
                var ModbusControl = GetTerminal(selectedPage);
                ModbusControl.Unload();
                tabControl.TabPages.Remove(selectedPage);
            }
        }

        private void ExportToolStripButton_Click(object sender, EventArgs e)
        {
            var selectedPage = tabControl.SelectedTab;
            if (selectedPage != null)
            {
                var session = new SessionSettings();
                var ModbusControl = GetSettings(selectedPage, session);
                var sdlg = new SaveFileDialog
                {
                    Title = "Export to SharpMaster File",
                    Filter = "LiteDB Files (*.SharpMaster)|*.SharpMaster",
                    OverwritePrompt = true,
                    RestoreDirectory = true
                };
                if (sdlg.ShowDialog() == DialogResult.OK)
                {
                    File.Delete(sdlg.FileName);
                    using (var db = new LiteDatabase(sdlg.FileName))
                    {
                        var table = db.GetCollection<SessionSettings>("sessions");
                        table.Upsert(session);
                    }
                }
            }
        }

        private void ImportToolStripButton_Click(object sender, EventArgs e)
        {
            var sdlg = new OpenFileDialog
            {
                Title = "Import from SharpMaster File",
                Filter = "LiteDB Files (*.SharpMaster)|*.SharpMaster",
                CheckFileExists = true,
                CheckPathExists = true,
                RestoreDirectory = true
            };
            if (sdlg.ShowDialog() == DialogResult.OK)
            {
                using (var db = new LiteDatabase(sdlg.FileName))
                {
                    var table = db.GetCollection<SessionSettings>("sessions");
                    foreach (var session in table.FindAll())
                    {
                        AddSession(session);
                    }
                }
            }
        }
    }
}
