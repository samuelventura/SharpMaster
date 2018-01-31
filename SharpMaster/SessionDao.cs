using System;
using System.IO;
using System.Collections.Generic;
using LiteDB;
using SharpMaster.Tools;

namespace SharpMaster
{
    public class SessionDao
    {
        public List<SessionSettings> Load()
        {
            using (var db = DB())
            { 
                var table = db.GetCollection<SessionSettings>("sessions");
                return new List<SessionSettings>(table.FindAll());
            }
        }

        public void Save(List<SessionSettings> sessions)
        {
            using (var db = DB())
            {
                db.DropCollection("sessions");
                var table = db.GetCollection<SessionSettings>("sessions");
                foreach(var session in sessions)
                {
                    table.Upsert(session);
                }
            }
        }

        private LiteDatabase DB()
        {
#if DEBUG
            return new LiteDatabase(Executable.Relative("sessions.db"));
#else
            var root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folder = Path.Combine(root, "SharpMaster");
            Directory.CreateDirectory(folder);
            return new LiteDatabase(Path.Combine(folder, "sessions.db"));
#endif
        }
    }
}
