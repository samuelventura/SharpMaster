using System;
using System.Drawing;
using System.Windows.Forms;
using SharpMaster.Tools;
using SharpTabs;

namespace SharpMaster
{
    public class MasterFactory : SessionFactory
    {
        private readonly string path;
        
        public string Name => "SharpMaster";
        public string Ext => "SharpMaster";
        public string Title => "SharpMaster - 1.0.7 https://github.com/samuelventura/SharpMaster";
        public string Status => path;
        public Icon Icon => Resource.Icon;

        public MasterFactory(string path)
        {
            this.path = path ?? SessionDao.DefaultPath(Name);
        }

        public SessionDto[] Load()
        {
            return Load(path);
        }

        public SessionDto[] Load(string path)
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

        public void Save(SessionDto[] dtos)
        {
            Save(path, dtos);
        }

        public void Save(string path, SessionDto[] dtos)
        {
            SessionDao.Save(path, dtos);
        }

        public Control New()
        {
            return Wrap(new MasterDto
            {
                Name = NewName()
            });
        }

        public SessionDto Unwrap(Control obj)
        {
            var control = obj as ModbusControl;
            var dto = new MasterDto
            {
                Name = control.Text
            };
            control.FromUI(dto);
            return dto;
        }

        public Control Wrap(SessionDto obj)
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

        private static long count;

        public static string NewName()
        {
            count++;
            return $"Session {count}";
        }
    }
}
