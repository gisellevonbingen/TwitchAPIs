using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebSocketSharp;

namespace TwitchAPI.ChatTest
{
    public abstract class TwitchChat : IDisposable
    {
        public ConnectMode ConnectMode { get; set; }
        public bool Disposed { get; private set; }

        public TwitchChat()
        {
            this.ConnectMode = ConnectMode.Default;
            this.Disposed = false;
        }

        public void EnsureNotDispose()
        {
            if (this.Disposed == true)
            {
                throw new ObjectDisposedException(this.GetType().FullName);
            }

        }

        public abstract void Connect();

        public abstract void Send(string str);

        public abstract string Receive();

        protected virtual void Dispose(bool disposing)
        {
            this.Disposed = true;
        }

        ~TwitchChat()
        {
            this.Dispose(false);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
            this.Dispose(true);
        }

    }

}
