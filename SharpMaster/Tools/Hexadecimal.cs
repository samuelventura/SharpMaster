using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

namespace SharpMaster.Tools
{
    public static class Hexadecimal
    {
        public static readonly Regex HEXRE = new Regex(@"[^0-9a-fA-F]");

        public static byte[] Parse(string text)
        {
            var upper = HEXRE.Replace(text, " ");
            var bytes = new List<byte>();
            var chunks = upper.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var chunk in chunks)
            {
                var count = chunk.Length / 2 + chunk.Length % 2;
                for (var i = 0; i < count; i++)
                {
                    var end = chunk.Length - 2 * (count - i - 1);
                    var start = Math.Max(0, end - 2);
                    var pair = chunk.Substring(start, end - start);
                    var b = Convert.ToByte(pair, 16);
                    bytes.Add(b);
                }
            }
            return bytes.ToArray();
        }

        public static string ToString(byte[] bytes, char sep = ' ')
        {
            var sb = new StringBuilder();
            foreach (var b in bytes)
            {
                if (sb.Length > 0)
                    sb.Append(sep);
                sb.Append(b.ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
