using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPI
{
    [Serializable]
    public class TwitchException : WebException
    {
        public TwitchException()
        {

        }

        public TwitchException(string message) : base(message)
        {

        }

        public TwitchException(string message, Exception innerException) : base(message, innerException)
        {

        }

        public TwitchException(string message, WebExceptionStatus status) : base(message, status)
        {

        }

        public TwitchException(string message, Exception innerException, WebExceptionStatus status, WebResponse response) : base(message, innerException, status, response)
        {

        }

        [SecuritySafeCritical]
        protected TwitchException(SerializationInfo serializationInfo, StreamingContext streamingContext) : base(serializationInfo, streamingContext)
        {

        }

        public override void GetObjectData(SerializationInfo serializationInfo, StreamingContext streamingContext)
        {
            base.GetObjectData(serializationInfo, streamingContext);
        }

    }

}
