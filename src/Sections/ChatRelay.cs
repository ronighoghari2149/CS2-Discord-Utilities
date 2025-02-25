using CounterStrikeSharp.API;
using Discord.WebSocket;

namespace DiscordUtilities
{
    public partial class DiscordUtilities
    {
        public void PerformChatRelay(SocketGuildUser user, SocketMessage message)
        {
            string messageFormat = Config.DiscordRelay.MessageFormat;
            var replacedData = new Dictionary<string, string>
            {
                { "{Discord.UserNickName}", user.Nickname },
                { "{Discord.UserDisplayName}", user.DisplayName },
                { "{Discord.UserGlobalName}", user.GlobalName },
                { "{Discord.UserID}", user.Id.ToString() },
                { "{Discord.ChannelName}", message.Channel.Name },
                { "{Discord.ChannelID}", message.Channel.Id.ToString() },
                { "{Discord.Message}", message.Content }
            };

            foreach (var item in replacedData)
            {
                if (messageFormat.Contains(item.Key))
                    messageFormat = messageFormat.Replace(item.Key, item.Value);
            }
            
            messageFormat = ReplaceColors(messageFormat);
            Server.PrintToChatAll(messageFormat);
        }
    }
}