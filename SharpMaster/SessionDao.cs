using System;
using System.IO;
using System.Collections.Generic;
using SharpMaster.Tools;
using LiteDB;

namespace SharpMaster
{
    public class SessionDao
    {
        private readonly string dbPath;

        public SessionDao(string dbPath = null)
        {
            BsonMapper.Global.EmptyStringToNull = false;
            this.dbPath = dbPath ?? DefaultPath();
        }

        public string DbPath
        {
            get { return dbPath;  }
        }

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
            return new LiteDatabase(dbPath);
        }

        private string DefaultPath()
        {
#if DEBUG
            return Executable.Relative("sessions.db");
#else
            var root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folder = Path.Combine(root, "SharpMaster");
            Directory.CreateDirectory(folder);
            return Path.Combine(folder, "sessions.db");
#endif
        }
    }
}
