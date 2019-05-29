using System;
using System.IO;

namespace SharpMaster.Tools
{
    public static class Thrower
    {
        public static void Throw(string format, params object[] args)
        {
            throw Make(format, args);
        }

        public static void Throw(Exception inner, string format, params object[] args)
        {
            throw Make(inner, format, args);
        }

        public static Exception Make(string format, params object[] args)
        {
            var message = args.Length > 0 ? string.Format(format, args) : format;
            return new Exception(message);
        }

        public static Exception Make(Exception inner, string format, params object[] args)
        {
            var message = args.Length > 0 ? string.Format(format, args) : format;
            return new Exception(message, inner);
        }

        public static void Dump(Exception ex)
        {
            var folder = Executable.Relative("Exceptions");
            Directory.CreateDirectory(folder);
            var ts = DateTime.Now.ToString("yyyyMMdd_HHmmss_fff");
            var fileName = string.Format("exception-{0}.txt", ts);
            File.WriteAllText(Path.Combine(folder, fileName), ex.ToString());
        }
    }
}