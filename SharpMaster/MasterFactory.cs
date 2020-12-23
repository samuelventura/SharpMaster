using System;
using System.Drawing;
using System.Windows.Forms;
using SharpTabs;

namespace SharpMaster
{
    public class MasterFactory : ISessionFactory
    {
        private readonly string path;
        
        public string Name => "SharpMaster";
        public string Ext => "SharpMaster";
        public string Title => $"SharpMaster - {Version} {Home}";
        public string Status => path;
        public Icon Icon => TabsTools.ExeIcon();
        private string Version => Tools.Executable.VersionString();
        private string Home => "https://github.com/samuelventura/SharpMaster";

        public bool HasSetup => true;

        public MasterFactory(string path)
        {
            this.path = path ?? SessionDao.DefaultPath(Name);
        }

        public ISessionDto[] Load()
        {
            return Load(path);
        }

        public ISessionDto[] Load(string path)
        {
            SessionDao.Exec(path, (db) =>
            {
                if (TabsTools.IsDebug())
                {
                    //force migration
                    db.Engine.UserVersion = 0;
                }
                //migration
                if (db.Engine.UserVersion < 1)
                {
                    var assy = typeof(MasterDto).Assembly.FullName;
                    var type = typeof(MasterDto).FullName;
                    db.Engine.Run($"db.sessions.update _type='{type}, {assy}'");
                    db.Engine.UserVersion = 1;
                }
            });
            return SessionDao.Load<MasterDto>(path);
        }

        public void Unload(Control obj)
        {
            var control = obj as ModbusControl;
            control.Unload();
        }

        public void Save(ISessionDto[] dtos)
        {
            Save(path, dtos);
        }

        public void Setup(Control obj)
        {
            var control = obj as ModbusControl;
            control.Setup();
        }

        public void Save(string path, ISessionDto[] dtos)
        {
            SessionDao.Save(path, dtos);
        }

        public Control New()
        {
            return Wrap(new MasterDto
            {
                Name = SessionDao.NewName()
            });
        }

        public ISessionDto Unwrap(Control obj)
        {
            var control = obj as ModbusControl;
            var dto = new MasterDto
            {
                Name = control.Text
            };
            control.FromUI(dto);
            return dto;
        }

        public Control Wrap(ISessionDto obj)
        {
            var dto = obj as MasterDto;
            var control = new ModbusControl
            {
                Text = dto.Name,
                Dock = DockStyle.Fill,
            };
            control.ToUI(dto);
            return control;
        }
    }
}
