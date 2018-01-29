using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace SharpMaster.Tools
{
    public class Disposer : IDisposable
    {
        public static void Dispose(object any)
        {
            Execute(() =>
            {
                if (any is IDisposable)
                {
                    var disposable = (IDisposable)any;
                    disposable.Dispose();
                }
            });

        }

        // SerialPort, Socket, TcpClient, Streams, Writers, Readers, ...
        public static void Dispose(IDisposable disposable)
        {
            Execute(() => { disposable?.Dispose(); });
        }

        // TcpListener
        public static void Close(TcpListener closeable)
        {
            Execute(() => { closeable?.Stop(); });
        }

        private static void Execute(Action action)
        {
            try { action(); } catch (Exception) { }
        }

        private readonly Stack<Action> actions;

        public Disposer()
        {
            this.actions = new Stack<Action>();
        }

        public void Add(IDisposable disposable)
        {
            actions.Push(() => {
                disposable.Dispose();
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
                Execute(actions.Pop());
            }
        }
    }
}