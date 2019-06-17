﻿using System;
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
            follows.Follows = jToken["follows"].ReadArray(t => new TwitchFollow().Read(t)) ?? new TwitchFollow[0];

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

    }

}