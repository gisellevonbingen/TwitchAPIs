# Twitch API (New, V5) C# Wrapper
'Test' project has simple example

# Reference
* [Twitch Developers Reference](https://dev.twitch.tv/docs/api/reference/)
* [Badge API](https://discuss.dev.twitch.tv/t/beta-badge-api/6388)
  * Global - https://badges.twitch.tv/v1/badges/global/display
  * Channel - https://badges.twitch.tv/v1/badges/channels/{channelId}/display
  * Integration(Global+Channel) - https://cbenni.com/api/badges/{channelName}

# Requires
* [Giselle.Commons](https://github.com/gisellevonbingen/Giselle.Commons)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* System.Web

# Test.Requires
* [Giselle.Commons](https://github.com/gisellevonbingen/Giselle.Commons)
* [Newtonsoft.Json](https://www.newtonsoft.com/json)
* System.Web
* System.Drawing
* System.Windows.Forms

# Support functions
* OAuth
  * [OAuth Implicit Code Flow](https://dev.twitch.tv/docs/authentication/getting-tokens-oauth/#oauth-implicit-code-flow)
  * [OAuth Authorization Code Flow](https://dev.twitch.tv/docs/authentication/getting-tokens-oauth/#oauth-authorization-code-flow)
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
* V5
  * Bits
    * [Get Cheermotes](https://dev.twitch.tv/docs/v5/reference/bits/#get-cheermotes)
  * Channels
    * [Get Channel](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel)
    * [Get Channel by ID](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-by-id)
    * [Get Channel Editors](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-editors)
    * [Get Channel Followers](https://dev.twitch.tv/docs/v5/reference/channels/#get-channel-followers)
  * Chat
    * [Get Chat Rooms by Channel](https://dev.twitch.tv/docs/v5/reference/chat/#get-chat-rooms-by-channel)
  * Games
    * [Get Top Games](https://dev.twitch.tv/docs/v5/reference/games/#get-top-games)
  * Search
    * [Search Channels](https://dev.twitch.tv/docs/v5/reference/search/#search-channels)
    * [Search Games](https://dev.twitch.tv/docs/v5/reference/search/#search-games)
  * Users
    * [Get User](https://dev.twitch.tv/docs/v5/reference/users/#get-user)
    * [Get User by ID](https://dev.twitch.tv/docs/v5/reference/users/#get-user-by-id)
    * [Get Users](https://dev.twitch.tv/docs/v5/reference/users/#get-users)
    * [Get User Emotes](https://dev.twitch.tv/docs/v5/reference/users/#get-user-emotes)
    * [Get User Follows](https://dev.twitch.tv/docs/v5/reference/users/#get-user-follows)
    * [Follow Channel](https://dev.twitch.tv/docs/v5/reference/users/#follow-channel)
    * [Unfollow Channel](https://dev.twitch.tv/docs/v5/reference/users/#unfollow-channel)
    * [Get User Block List](https://dev.twitch.tv/docs/v5/reference/users/#get-user-block-list)
    * [Block User](https://dev.twitch.tv/docs/v5/reference/users/#block-user)
    * [Unblock User](https://dev.twitch.tv/docs/v5/reference/users/#unblock-user)
* Other
  * Get Global Badges
  * Get Channel Badges
  * Get Integration(Global+Channel) Badges
