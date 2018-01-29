using System;
using System.IO;
using System.Collections.Generic;
using LiteDB;
using SharpMaster.Tools;

namespace SharpMaster
{
    public class SessionDao
    {
        private readonly LiteDatabase db;

        public SessionDao()
        {
#if DEBUG
            db = new LiteDatabase(Executable.Relative("sessions.db"));
#else
            var root = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            var folder = Path.Combine(root, "SharpMaster");
            Directory.CreateDirectory(folder);
            db = new LiteDatabase(Path.Combine(folder, "sessions.db"));
#endif
        }

        public List<SessionSettings> Load()
        {
            var table = db.GetCollection<SessionSettings>("sessions");
            return new List<SessionSettings>(table.FindAll());
        }

        public void Save(List<SessionSettings> sessions)
        {
            db.DropCollection("sessions");
            var table = db.GetCollection<SessionSettings>("sessions");
            foreach(var session in sessions)
            {
                table.Upsert(session);
            }
        }

    }
}
