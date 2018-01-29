using System;
using System.Net;
using System.Net.Sockets;

namespace SharpMaster.Tools
{
    public static class Sockets
    {
        public static TcpClient ConnectWithTimeout(string ip, int port, int timeout)
        {
            return ConnectWithTimeout(new TcpClient(), ip, port, timeout);
        }

        public static TcpClient ConnectWithTimeout(TcpClient socket, string ip, int port, int timeout)
        {
            var result = socket.BeginConnect(ip, port, null, null);
            if (!result.AsyncWaitHandle.WaitOne(timeout, true))
            {
                Disposer.Dispose(socket);
                Thrower.Throw("Timeout connecting to {0}:{1}", ip, port);
            }
            socket.EndConnect(result);
            return socket;
        }
    }
}
