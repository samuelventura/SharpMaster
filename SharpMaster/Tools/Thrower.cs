using System;

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
    }
}