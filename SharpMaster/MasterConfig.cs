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
        [DisplayName("Frame Separation (ms)")]
        public int DelayMs { get; set; } = 10;

        [Category("Session")]
        [DisplayName("Poll Interval (ms)")]
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
            return clone;
        }

        public int FixedTimer()
        {
            return Math.Max(TimerMs, 10);
        }

        public int FixedConnect()
        {
            return Math.Max(ConnectMs, 100);
        }

        public int FixedTimeout()
        {
            return Math.Max(ConnectMs, 100);
        }

        public int FixedDelay()
        {
            return Math.Max(DelayMs, 0);
        }
    }
}
