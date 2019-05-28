using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WebSocketSharp;

namespace TwitchAPI.ChatTest
{
    public class TwitchChatWebSocket : TwitchChat
    {
        private readonly object ConnectingLock = new object();

        private Queue<string> ReceiveQueue;
        private ManualResetEventSlim ReceiveEvent;

        private WebSocket Socket;

        public TwitchChatWebSocket()
        {
            this.ReceiveQueue = new Queue<string>();
            this.ReceiveEvent = new ManualResetEventSlim();

            this.Socket = null;
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            ObjectUtils.DisposeQuietly(this.ReceiveEvent);

            lock (this.ConnectingLock)
            {
                ObjectUtils.DisposeQuietly(this.Socket);
                this.Socket = null;
            }

        }

        public override void Connect()
        {
            WebSocket ws = null;

            lock (this.ConnectingLock)
            {
                this.EnsureNotDispose();

                var connectMode = this.ConnectMode;
                var protocol = this.GetProtocol(connectMode);
                var port = this.GetPort(connectMode);

                ws = this.Socket = new WebSocket($"{protocol}://irc-ws.chat.twitch.tv:{port}");
            }

            ws.Log.Output = null;
            ws.OnMessage += this.OnMessage;
            ws.OnError += this.OnError;
            ws.Connect();

            this.EnsureNotDispose();
        }

        private void OnError(object sender, ErrorEventArgs e)
        {

        }

        private void OnMessage(object sender, MessageEventArgs e)
        {
            lock (this.ReceiveQueue)
            {
                this.ReceiveQueue.Enqueue(e.Data);
                this.ReceiveEvent.Set();
            }

        }

        public override void Send(string str)
        {
            this.EnsureNotDispose();
            this.Socket.Send(str);
        }

        public override string Receive()
        {
            var receiveQueue = this.ReceiveQueue;
            var receiveEvent = this.ReceiveEvent;

            while (true)
            {
                this.EnsureNotDispose();

                lock (receiveQueue)
                {
                    if (receiveQueue.Count > 0)
                    {
                        return receiveQueue.Dequeue();
                    }

                }

                receiveEvent.Wait();
                receiveEvent.Reset();
            }

        }

        public string GetProtocol(ConnectMode mode)
        {
            return mode == ConnectMode.SSL ? "wss" : "ws";
        }

        public int GetPort(ConnectMode mode)
        {
            return mode == ConnectMode.SSL ? 443 : 80;
        }

    }

}
