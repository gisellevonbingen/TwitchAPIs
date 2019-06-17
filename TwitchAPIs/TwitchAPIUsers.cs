using Giselle.Commons;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace TwitchAPIs
{
    public class TwitchAPIUsers : TwitchAPIPart
    {
        public TwitchAPIUsers(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchUserFollowsV5 GetUserFollowsV5(string userId, int? limit = null, int? offset = null, FollowSortDirection? direction = null, FollowSortMode? sortby = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/follows/channels";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("offset", offset);
            apiRequest.QueryValues.Add("direction", direction);
            apiRequest.QueryValues.Add("sortby", sortby);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var follows = new TwitchUserFollowsV5();
            follows.Total = jToken.Value<int>("_total");
            follows.Follows = jToken["follows"].ReadArray(t => new TwitchFollowV5().Read(t)) ?? new TwitchFollowV5[0];

            return follows;
        }

        public void UnfollowChannel(string userId, string channelId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/follows/channels/{channelId}";
            apiRequest.Method = "DELETE";

            using (var response = this.Parent.Request(apiRequest))
            {
                if (response.Impl.StatusCode == System.Net.HttpStatusCode.NoContent)
                {

                }
                else
                {
                    this.Parent.ReadAsJsonThrowIfError(response);
                }

            }

        }

        public TwitchFollowV5 FollowChannel(string userId, string channelId, bool? notifications = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/follows/channels/{channelId}";
            apiRequest.Method = "PUT";
            apiRequest.QueryValues.Add("notifications", notifications);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var follow = new TwitchFollowV5().Read(jToken);

            return follow;
        }

        public TwitchEmoticonSets GetUserEmotes(string userId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/emotes";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var set = new TwitchEmoticonSets().Read(jToken);

            return set;
        }

        public TwitchUser UpdateUser(string description)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users";
            apiRequest.Method = "PUT";
            apiRequest.QueryValues.Add("description", HttpUtility.UrlEncode(description));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return this.ParseUsers(jToken).FirstOrDefault();
        }

        public TwitchUserFollowsNew GetUserFollowsNew(FollowsType type, string id, string cursor = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users/follows";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add($"{type.Request}_id", id);
            apiRequest.QueryValues.Add($"after", cursor);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var uerFollows = new TwitchUserFollowsNew();
            uerFollows.Total = jToken.Value<int>("total");
            uerFollows.Cursor = this.Parent.GetPaination(jToken)?.Cursor;
            uerFollows.Follows = jToken.ReadArray("data", t => new TwitchFollowNew().Read(t, type)) ?? new TwitchFollowNew[0];

            return uerFollows;
        }

        public TwitchUser GetUser(UserRequest request)
        {
            var users = this.GetUsers(new UserRequest[] { request });
            return users.FirstOrDefault();
        }

        public TwitchUser[] GetUsers(IEnumerable<UserRequest> requests)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.New;
            apiRequest.Path = "users";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.AddRange(requests.Select(r => new QueryValue(r.Type.ToString().ToLowerInvariant(), r.Value)));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return this.ParseUsers(jToken);
        }

        private TwitchUser[] ParseUsers(JToken token)
        {
            return token.ReadArray("data", t => new TwitchUser().Read(t)) ?? new TwitchUser[0];
        }

    }

}
