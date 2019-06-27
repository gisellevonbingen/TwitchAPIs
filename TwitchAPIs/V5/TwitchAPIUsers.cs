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

        public TwitchUser GetUser()
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"user";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchUserOwn(jToken);
        }

        public TwitchUser GetUserByID(string userId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchUser(jToken);
        }

        public TwitchUser[] GetUsers(IEnumerable<string> logins)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("login", string.Join(",", logins));
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadArray("users", t => new TwitchUser(t));
        }

        public TwitchEmoticonSets GetUserEmotes(string userId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/emotes";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchEmoticonSets(jToken);
        }

        public TwitchUserSubscription CheckUserSubscriptionByChannel(string userId, string channelId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/subscriptions/{channelId}";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchUserSubscription(jToken);
        }

        public TwitchUserFollows GetUserFollows(string userId, int? limit = null, int? offset = null, SortDirection direction = null, FollowSortMode sortby = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/follows/channels";
            apiRequest.Method = "GET";
            apiRequest.QueryValues.Add("limit", limit);
            apiRequest.QueryValues.Add("offset", offset);
            apiRequest.QueryValues.Add("direction", direction?.Value);
            apiRequest.QueryValues.Add("sortby", sortby?.Value);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchUserFollows(jToken);
        }

        public TwitchFollow FollowChannel(string userId, string channelId, bool? notifications = null)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/follows/channels/{channelId}";
            apiRequest.Method = "PUT";
            apiRequest.QueryValues.Add("notifications", notifications);
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchFollow(jToken);
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

        public TwitchFollow CheckUserFollowsByChannel(string userId, string channelId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{userId}/follows/channels/{channelId}";
            apiRequest.Method = "GET";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return new TwitchFollow(jToken);
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

            return new TwitchUserBlockList(jToken);
        }

        public TwitchUser BlockUser(string sourceUserId, string targetUserId)
        {
            var apiRequest = new TwitchAPIRequest();
            apiRequest.Version = APIVersion.V5;
            apiRequest.Path = $"users/{sourceUserId}/blocks/{targetUserId}";
            apiRequest.Method = "PUT";
            var jToken = this.Parent.RequestAsJson(apiRequest);

            return jToken.ReadIfExist("user", t => new TwitchUser(t));
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
