using System;
using System.Collections.Generic;
using LiteDB;

namespace SharpMaster
{
    public class SerializableMap
    {
        public Dictionary<string, string> Data { get; set; } = new Dictionary<string, string>();

        public void AddAny(string key, object any)
        {
            Data[key] = any.ToString();
        }

        public string GetString(string key, string defval)
        {
            if (Data.TryGetValue(key, out var value))
            {
                return value;
            }
            return defval;
        }

        public decimal GetNumber(string key, decimal defval)
        {
            if (Data.TryGetValue(key, out var value))
            {
                if (decimal.TryParse(value, out var number))
                {
                    return number;
                }
            }
            return defval;
        }

        public void Put(string key, string value)
        {
            Data[key] = value;
        }

        public string Get(string key)
        {
            return Data[key];
        }
    }
}
