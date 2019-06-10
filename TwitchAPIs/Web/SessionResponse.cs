using Giselle.Commons;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.Web
{
    public class SessionResponse : IDisposable
    {
        private HttpWebResponse _Impl = null;
        public HttpWebResponse Impl { get { return this._Impl; } }

        public SessionResponse(HttpWebResponse impl)
        {
            this._Impl = impl;
        }

        ~SessionResponse()
        {
            this.Dispose(false);
        }

        public string ReadAsString()
        {
            Stream stream = null;
            StreamReader reader = null;

            try
            {
                stream = this.Impl.GetResponseStream();
                reader = new StreamReader(stream);

                return reader.ReadToEnd();
            }
            finally
            {
                ObjectUtils.DisposeQuietly(reader);
                ObjectUtils.DisposeQuietly(stream);
            }

        }

        public Stream ReadAsStream()
        {
            return this.Impl.GetResponseStream();
        }

        public JObject ReadAsJSON()
        {
            var content = this.ReadAsString();
            var jobj = JObject.Parse(content);

            return jobj;
        }

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            ObjectUtils.DisposeQuietly(this.Impl);
        }

    }

}