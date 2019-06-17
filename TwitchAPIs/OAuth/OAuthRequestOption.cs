using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.OAuth
{
    public class OAuthRequestOption : OAuthRequest
    {
        private string _ResponseType;

        public OAuthRequestOption()
        {
            this._ResponseType = null;
        }

        public override string ResponseType => this._ResponseType;

        public void SetResponseType(string value)
        {
            this._ResponseType = value;
        }

    }

}
