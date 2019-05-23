using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitchAPI
{
    public static class HttpUtility2
    {
        public static NameValueCollection ParseQueryString(string str, string prefix)
        {
            if (str.StartsWith(prefix) == true)
            {
                str = str.Substring(prefix.Length);
            }

            return HttpUtility.ParseQueryString(str);
        }

    }

}
