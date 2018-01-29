using System;
using System.Threading;
using System.Collections.Generic;

namespace SharpMaster.Tools
{
    public interface IRunner
    {
        void Run(Action action);
    }

    public class ThreadRunner : IRunner, IDisposable
    {
        private readonly Action<Exception> catcher;
        private readonly Queue<Named> queue;
        private readonly Thread thread;
        private readonly Action idle;
        private readonly int delay;

        public ThreadRunner(string name) : this(name, null, null, 0)
        {
        }

        public ThreadRunner(string name, Action idle, int delay = 0) : this(name, null, idle, delay)
        {
        }

        public ThreadRunner(string name, Action<Exception> catcher) : this(name, catcher, null, 0)
        {
        }

        public ThreadRunner(string name, Action<Exception> catcher, Action idle, int delay = 0)
        {
            this.catcher = catcher;
            this.idle = idle;
            this.delay = delay;
            this.queue = new Queue<Named>();
            this.thread = new Thread(Loop)
            {
                IsBackground = true,
                Name = name
            };
            this.thread.Start();
        }

        public void Run(Action action)
        {
            Push(new Named("action", action));
        }

        public void Dispose(Action action)
        {
            Push(new Named("dispose", action));
            thread.Join();
        }

        public void Dispose()
        {
            Push(new Named("dispose"));
            thread.Join();
        }

        public void Flush()
        {
            var flag = new AutoResetEvent(false);
            Push(new Named("flush", flag));
            flag.WaitOne();
        }

        private void Loop()
        {
            while (true)
            {
                var named = Poll();

                switch (named.Name)
                {
                    case "action":
                        Execute((Action)named.Payload);
                        break;
                    case "flush":
                        var flag = (AutoResetEvent)named.Payload;
                        flag.Set();
                        break;
                    case "dispose":
                        var action = (Action)named.Payload;
                        if (action != null) Execute(action);
                        return;
                }
            }
        }

        private void Push(Named named)
        {
            lock (queue)
            {
                queue.Enqueue(named);
                Monitor.Pulse(queue);
            }
        }

        private Named Poll()
        {
            lock (queue)
            {
                while (queue.Count == 0)
                {
                    if (idle == null) Monitor.Wait(queue);
                    else if (!Monitor.Wait(queue, delay))
                    {
                        return new Named("action", idle);
                    }
                }
                return queue.Dequeue();
            }
        }

        private void Execute(Action action)
        {
            try { action(); }
            catch (Exception ex)
            { try { catcher?.Invoke(ex); } catch (Exception) { } }
        }
    }
}