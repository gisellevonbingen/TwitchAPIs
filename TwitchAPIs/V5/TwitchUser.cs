using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

namespace TwitchAPIs.V5
{
    public class TwitchUser
    {
        public string Id { get; set; }
        public string BIO { get; set; }
        public DateTime CreatedAt { get; set; }
        public string DisplayName { get; set; }
        public string Email { get; set; }
        public bool EmailVerified { get; set; }
        public string Logo { get; set; }
        public string Name { get; set; }
        public TwitchUserNotifications Notifications { get; set; }
        public bool Partnered { get; set; }
        public bool TwitterConnected { get; set; }
        public string Type { get; set; }
        public DateTime UpdatedAt { get; set; }

        public TwitchUser()
        {

        }

        public TwitchUser Read(JToken jToken)
        {
            this.Id = jToken.Value<string>("_id");
            this.BIO = jToken.Value<string>("bio");
            this.CreatedAt = jToken.Value<DateTime>("created_at");
            this.DisplayName = jToken.Value<string>("display_name");
            this.Email = jToken.Value<string>("email");
            this.EmailVerified = jToken.Value<bool>("email_verified");
            this.Logo = jToken.Value<string>("logo");
            this.Name = jToken.Value<string>("name");
            this.Notifications = jToken.ReadIfExist("notifications", t => new TwitchUserNotifications().Read(t));
            this.Partnered = jToken.Value<bool>("partnered");
            this.TwitterConnected = jToken.Value<bool>("twitter_connected");
            this.Type = jToken.Value<string>("type");
            this.UpdatedAt = jToken.Value<DateTime>("updated_at");

            return this;
        }

    }

}
