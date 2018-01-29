using System;

namespace SharpMaster.Tools
{
    public static class Thrower
    {
        public static void Throw(string format, params object[] args)
        {
            var msg = args.Length > 0 ? string.Format(format, args) : format;
            throw new Exception(msg);
        }

        public static void Throw(Exception inner, string format, params object[] args)
        {
            var msg = args.Length > 0 ? string.Format(format, args) : format;
            throw new Exception(msg, inner);
        }
    }
}