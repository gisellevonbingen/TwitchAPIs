using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.New
{
    public class TwitchAPIWebhooks : TwitchAPIPart
    {
        public TwitchAPIWebhooks(TwitchAPI parent) : base(parent)
        {

        }

        public string GetTopicUserFollows(string fromId, string toId)
        {
            var apiRequest = this.Parent.New.Users.GetUserFollowsRequest(null, 1, fromId, toId);
            var webRequest = this.Parent.CreateWebRequest(apiRequest);

            return webRequest.Uri;
        }

        public string PostHub(string callback, HubMode mode, string topic, int? leaseSeconds = null, string sercet = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "webhooks/hub";
            apiRequest.Method = "POST";

            var jToken = new JObject();
            jToken["hub.callback"] = callback;
            jToken["hub.mode"] = mode?.Value;
            jToken["hub.topic"] = topic;

            if (leaseSeconds.HasValue == true)
            {
                jToken["hub.lease_seconds"] = leaseSeconds;
            }

            if (string.IsNullOrWhiteSpace(sercet) == false)
            {
                jToken["hub.secret"] = sercet;
            }

            var webRequest = this.Parent.CreateWebRequest(apiRequest);
            webRequest.ContentType = "application/json";
            webRequest.WriteParameter = jToken.ToString(Newtonsoft.Json.Formatting.Indented);

            using (var webResponse = this.Parent.Web.Request(webRequest))
            {
                var response = webResponse.ReadAsString();
                return response;
            }

        }

        public TwitchWebhookSubscriptions GetWebhookSubscriptions(string after = null, int? first = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "webhooks/subscriptions";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("after", after);
            apiRequest.QueryValues.Add("first", first);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var subscriptions = new TwitchWebhookSubscriptions();
            subscriptions.Total = jToken.Value<int>("total");
            subscriptions.Subscriptions = jToken.ReadArray("data", t => new TwitchWebhookSubscription(t));
            subscriptions.Pagination = jToken.ReadIfExist("pagination", t => new Pagination(t));

            return subscriptions;
        }

    }

}
