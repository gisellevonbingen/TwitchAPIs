# TwitchAPIs

Twithc API(New, V5)'s C# Wrapper

## Example

### Get Own User Information
```CSharp
var twitchAPI = new TwitchAPI();
twitchAPI.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
twitchAPI.AccessToken = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";

var user = twitchAPI.New.Users.GetUser();

Console.WriteLine();
Console.WriteLine($"Id = {user.Id}");
Console.WriteLine($"Login = {user.Login}");
Console.WriteLine($"DisplayName = {user.DisplayName}");
```

### Get Other User Information
```CSharp
var twitchAPI = new TwitchAPI();
twitchAPI.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

var userRequests = new List<UserRequest>();
userRequests.Add(new UserRequest(UserType.Login, "loginid, email"));

var users = twitchAPI.New.Users.GetUsers(userRequests);

foreach (var user in users)
{
    Console.WriteLine();
    Console.WriteLine($"Id = {user.Id}");
    Console.WriteLine($"Login = {user.Login}");
    Console.WriteLine($"DisplayName = {user.DisplayName}");
}
```

### Get User Followings
```CSharp
var twitchAPI = new TwitchAPI();
twitchAPI.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

var userId = "zzzzzzzzz";
var follows = twitchAPI.V5.Users.GetUserFollows(userId);

foreach (var follow in follows.Follows)
{
    Console.WriteLine();
    Console.WriteLine($"Channel = {follow.Channel.DisplayName}({follow.Channel.Name})");
    Console.WriteLine($"FollowedAt = {follow.CreatedAt}");
}
```

### Get User BlockList
```CSharp
var twitchAPI = new TwitchAPI();
twitchAPI.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";
twitchAPI.AccessToken = "yyyyyyyyyyyyyyyyyyyyyyyyyyyyyy";

var userId = "zzzzzzzzz";
var blockList = twitchAPI.V5.Users.GetUserBlockList(userId);

foreach (var block in blockList.Blocks)
{
    Console.WriteLine();
    Console.WriteLine($"Blocked User = {block.DisplayName}({block.Name})");
}
```

### Get Global+Channel Badges
```CSharp
var twitchAPI = new TwitchAPI();
var channelName = "xxxxxxx";
var badges = twitchAPI.Badges.GetIntegrationBadges(channelName);

var broadcasterBadge = badges.Get("broadcaster", "1");
var moderatorBadge = badges.Get("moderator", "1");
var subscriberBadge1 = badges.Get("subscriber", "6"); // 6-Month Subscriber
var subscriberBadge2 = badges.Get("subscriber", "12"); // 1-Year Subscriber

foreach (var namePair in badges.Set)
{
    var name = namePair.Key;
    var versionSet = namePair.Value;
    
    Console.WriteLine();
    Console.WriteLine($"Name = {name}");
    
    foreach (var versionPair in versionSet)
    {
        var key = versionPair.Key;
        var badge = versionPair.Value;
        
        Console.WriteLine();
        Console.WriteLine($"    Version = {key}");
        Console.WriteLine($"    Title = {badge.Title}");
        Console.WriteLine($"    Url = {badge.ImageUrl1x}");
    }

}
```

### OAuth Implicit Code Flow
```CSharp
[STAThread]
public static void Main(string[] args)
{
    var twitchAPI = new TwitchAPI();
    twitchAPI.ClientId = "xxxxxxxxxxxxxxxxxxxxxxxxxxxxxx";

    var authRequest = new OAuthRequestTokenCode();
    authRequest.RedirectUri = "Your Application's Redirect URI";
    authRequest.State = Guid.NewGuid().ToString();
    authRequest.Scopes.AddRange(new string[] { "scope1", "scope2", "scope3" });

    var authUri = twitchAPI.Authentication.GetCodeAuthorizeUri(authRequest);
    var responseUri = GetResponseUri(authRequest, authUri);

    if (responseUri == null)
    {
	Console.WriteLine("Authentication Fail");
    }
    else
    {
	var result = twitchAPI.Authentication.GetAuthenticationResult(responseUri, authRequest);
	Console.WriteLine($"Access Token = {result.AccessToken}");

	twitchAPI.AccessToken = result.AccessToken;
    }

}

private static Uri GetResponseUri(OAuthRequestTokenCode authRequest, string authUri)
{
    Application.EnableVisualStyles();
    Application.SetCompatibleTextRenderingDefault(false);

    Uri responseUri = null;
    var form = new Form();

    var browser = new WebBrowser();
    browser.Size = form.ClientSize;
    browser.Navigated += (sender, e) =>
    {
	var url = browser.Url;

	if (url.AbsoluteUri.StartsWith(authRequest.RedirectUri) == true)
	{
	    responseUri = url;
	    form.Close();
	}

    };

    form.Controls.Add(browser);
    form.SizeChanged += (sender, e) => { browser.Size = form.ClientSize; };

    browser.Navigate(authUri);
    Application.Run(form);

    return responseUri;
}
```

## Reference
* [Twitch Developers Reference](https://dev.twitch.tv/docs/api/reference/)
* [Badge API](https://discuss.dev.twitch.tv/t/beta-badge-api/6388)
  * Global - https://badges.twitch.tv/v1/badges/global/display
  * Channel - https://badges.twitch.tv/v1/badges/channels/{channelId}/display
  * Integration(Global+Channel) - https://cbenni.com/api/badges/{channelName}

## Dependencies
* [Giselle.Commons](https://github.com/gisellevonbingen/Giselle.Commons)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* System.Web

## Support functions
* Authentication
  * Getting Tokens: OAuth
    * [OAuth Implicit Code Flow](https://dev.twitch.tv/docs/authentication/getting-tokens-oauth/#oauth-implicit-code-flow)
    * [OAuth Authorization Code Flow](https://dev.twitch.tv/docs/authentication/getting-tokens-oauth/#oauth-authorization-code-flow)
    * [OAuth Client Credentials Flow](https://dev.twitch.tv/docs/authentication/getting-tokens-oauth/#oauth-client-credentials-flow)
  * [Refreshing Access Tokens](https://dev.twitch.tv/docs/authentication/#refreshing-access-tokens)
* New
  * Clips
    * [Get Clips](https://dev.twitch.tv/docs/api/reference/#get-clips)
  * Games
    * [Get Games](https://dev.twitch.tv/docs/api/reference/#get-games)
    * [Get Top Games](https://dev.twitch.tv/docs/api/reference/#get-top-games)
  * Tags
    * [Get All Stream Tags](https://dev.twitch.tv/docs/api/reference/#get-all-stream-tags)
  * Users
    * [Get Users](https://dev.twitch.tv/docs/api/reference/#get-users)
    * [Get Users Follows](https://dev.twitch.tv/docs/api/reference/#get-users-follows)
    * [Update User](https://dev.twitch.tv/docs/api/reference/#update-user)
  * Webhooks
    * [Get Webhook Subscriptions](https://dev.twitch.tv/docs/api/reference/#get-webhook-subscriptions)
    * [Subscribe To/Unsubscribe From Events](https://dev.twitch.tv/docs/api/webhooks-reference/#subscribe-tounsubscribe-from-events)
* V5
  * Bits
    * [Get Cheermotes](https://dev.twitch.tv/docs/v5/reference/bits/#get-cheermotes)
  * Channels
    * [Get Channel](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel)
    * [Get Channel by ID](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-by-id)
    * [Get Channel Editors](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-editors)
    * [Get Channel Followers](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-followers)
    * [Get Channel Teams](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-teams)
    * [Get Channel Subscribers](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-subscribers)
    * [Check Channel Subscription by User](https://dev.twitch.tv/docs/v5/reference/channels/#check-channel-subscription-by-user)
  * Chat
    * [Get Chat Rooms by Channel](https://dev.twitch.tv/docs/v5/reference/chat/#get-chat-rooms-by-channel)
  * Clips
    * [Get Clip](https://dev.twitch.tv/docs/v5/reference/clips/#get-clip)
    * [Get Top Clips](https://dev.twitch.tv/docs/v5/reference/clips/#get-top-clips)
    * [Get Followed Clips](https://dev.twitch.tv/docs/v5/reference/clips/#get-followed-clips)
  * Games
    * [Get Top Games](https://dev.twitch.tv/docs/v5/reference/games/#get-top-games)
  * Search
    * [Search Channels](https://dev.twitch.tv/docs/v5/reference/search/#search-channels)
    * [Search Games](https://dev.twitch.tv/docs/v5/reference/search/#search-games)
  * Teams
    * [Get All Teams](https://dev.twitch.tv/docs/v5/reference/teams/#get-all-teams)
    * [Get Team](https://dev.twitch.tv/docs/v5/reference/teams/#get-team)
  * Users
    * [Get User](https://dev.twitch.tv/docs/v5/reference/users/#get-user)
    * [Get User by ID](https://dev.twitch.tv/docs/v5/reference/users/#get-user-by-id)
    * [Get Users](https://dev.twitch.tv/docs/v5/reference/users/#get-users)
    * [Get User Emotes](https://dev.twitch.tv/docs/v5/reference/users/#get-user-emotes)
    * [Check User Subscription by Channel](https://dev.twitch.tv/docs/v5/reference/users/#check-user-subscription-by-channel)
    * [Get User Follows](https://dev.twitch.tv/docs/v5/reference/users/#get-user-follows)
    * [Check User Follows by Channel](https://dev.twitch.tv/docs/v5/reference/users/#check-user-follows-by-channel)
    * [Follow Channel](https://dev.twitch.tv/docs/v5/reference/users/#follow-channel)
    * [Unfollow Channel](https://dev.twitch.tv/docs/v5/reference/users/#unfollow-channel)
    * [Get User Block List](https://dev.twitch.tv/docs/v5/reference/users/#get-user-block-list)
    * [Block User](https://dev.twitch.tv/docs/v5/reference/users/#block-user)
    * [Unblock User](https://dev.twitch.tv/docs/v5/reference/users/#unblock-user)
* Other
  * Badges
    * Get Global Badges
    * Get Channel Badges
    * Get Integration(Global+Channel) Badges

# TwitchAPIs.Test

Function test and example

Include all functions of TwitchAPIs

## Dependencies
* [Giselle.Commons](https://github.com/gisellevonbingen/Giselle.Commons)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* System.Web
* System.Drawing
* System.Windows.Forms

# TwitchAPIs.WebhooksTest

test, example for Webhooks functions

## Dependencies
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* [uHttpSharp](https://github.com/Code-Sharp/uHttpSharp)
