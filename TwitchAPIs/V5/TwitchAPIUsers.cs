using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitchAPIs.V5
{
    public class TwitchAPIUsers : TwitchAPIPart
    {
        public TwitchAPIUsers(TwitchAPI parent) : base(parent)
        {

        }

        public TwitchUserFollows GetUserFollowsV5(string userId, int? limit = null, int? offset = null, FollowSortDirection? direction = null, FollowSortMode? sortby = null)
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

            var follows = new TwitchUserFollows();
            follows.Total = jToken.Value<int>("_total");
            follows.Follows = jToken.ReadArray("follows", t => new TwitchFollow().Read(t)) ?? new TwitchFollow[0];

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
                if (response.Impl.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    this.Parent.ReadAsJsonThrowIfError(response);
                }

            }

        }

        public TwitchFollow FollowChannel(string userId, string channelId, bool? notifications = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/follows/channels/{channelId}";
            apiRequest.Method = "PUT";
            apiRequest.QueryValues.Add("notifications", notifications);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var follow = new TwitchFollow().Read(jToken);

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

        public TwitchUser GetUser()
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"user";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchUserOwn().Read(jToken);
        }

        public TwitchUser GetUserByID(string userId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchUser().Read(jToken);
        }

        public TwitchUser[] GetUsers(IEnumerable<string> logins)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("login", string.Join(",", logins));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("users", t => new TwitchUser().Read(t)) ?? new TwitchUser[0];
        }

        public TwitchUserBlockList GetUserBlockList(string userId, int? limit = null, int? offset = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/blocks";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("offset", offset);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            var blockList = new TwitchUserBlockList();
            blockList.Total = jToken.Value<int>("_total");
            blockList.Blocks = jToken.ReadArray("blocks", t => new TwitchUser().Read(t["user"])) ?? new TwitchUser[0];

            return blockList;
        }

        public TwitchUser BlockUser(string sourceUserId, string targetUserId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{sourceUserId}/blocks/{targetUserId}";
            apiRequest.Method = "PUT";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchUser().Read(jToken["user"]);
        }

        public void UnblockUser(string sourceUserId, string targetUserId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{sourceUserId}/blocks/{targetUserId}";
            apiRequest.Method = "DELETE";

            using (var response = this.Parent.Request(apiRequest))
            {
                if (response.Impl.StatusCode != System.Net.HttpStatusCode.NoContent)
                {
                    this.Parent.ReadAsJsonThrowIfError(response);
                }

            }

        }

    }

}
