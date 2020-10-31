using System;
using System.ComponentModel;

namespace SharpMaster
{
    public class MasterConfig
    {
        [Category("Session")]
        [DisplayName("Response timeout (ms)")]
        public int TimeoutMs { get; set; } = 2000;

        [Category("Session")]
        [DisplayName("Connect timeout (ms)")]
        public int ConnectMs { get; set; } = 2000;

        [Category("Session")]
        [DisplayName("Frame separation (ms)")]
        public int DelayMs { get; set; } = 10;

        [Category("Session")]
        [DisplayName("Poll interval (ms)")]
        public int TimerMs { get; set; } = 100;

        [Category("Session")]
        [DisplayName("Auto reconnect")]
        public bool Reconnect { get; set; } = true;

        [Category("Session")]
        [DisplayName("Show stacktrace")]
        public bool ShowStacktrace { get; set; } = false;

        [Category("Session")]
        [DisplayName("Show packets")]
        public bool ShowPackets { get; set; } = true;

        [Category("Session")]
        [DisplayName("RTU over socket")]
        public bool RtuOverSocket { get; set; } = false;

        public MasterConfig Clone()
        {
            var clone = new MasterConfig();
            clone.TimeoutMs = TimeoutMs;
            clone.ConnectMs = ConnectMs;
            clone.DelayMs = DelayMs;
            clone.TimerMs = TimerMs;
            clone.Reconnect = Reconnect;
            clone.ShowStacktrace = ShowStacktrace;
            clone.ShowPackets = ShowPackets;
            clone.RtuOverSocket = RtuOverSocket;
            return clone;
        }

        public int FixedTimer()
        {
            return Math.Min(10000, Math.Max(TimerMs, 10));
        }

        public int FixedConnect()
        {
            return Math.Min(10000, Math.Max(ConnectMs, 100));
        }

        public int FixedTimeout()
        {
            return Math.Min(10000, Math.Max(TimeoutMs, 100));
        }

        public int FixedDelay()
        {
            return Math.Min(10000, Math.Max(DelayMs, 0));
        }
    }
}
