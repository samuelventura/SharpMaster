using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace SharpMaster.Tools
{
    public class Disposer : IDisposable
    {
        // SerialPort, Socket, TcpClient, Streams, Writers, Readers, ...
        public static void Dispose(object any)
        {
            IgnoreException(() => {
                if (any is IDisposable disposable) disposable.Dispose();
            });
        }

        // TcpListener
        public static void Stop(TcpListener stoppable)
        {
            IgnoreException(() => {
                stoppable?.Stop();
            });
        }

        public static void IgnoreException(Action action)
        {
            try { action?.Invoke(); } catch (Exception) { }
        }

        private readonly Stack<Action> actions;

        public Disposer(params Action[] actions)
        {
            this.actions = new Stack<Action>(actions);
        }

        public void Add(IDisposable disposable)
        {
            actions.Push(() => {
                disposable?.Dispose();
            });
        }

        public void Add(Action action)
        {
            actions.Push(action);
        }

        public void Dispose()
        {
            while (actions.Count > 0)
            {
                IgnoreException(actions.Pop());
            }
        }
    }
}