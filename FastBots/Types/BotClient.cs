using FastBots.Types.Commands;
using FastBots.Types.Options;
using Telegram.Bot;

namespace FastBots.Types
{
    public class BotClient : TelegramBotClient
    {
        public BotClient(FastBotsOptions options) : base(options.Token)
        {
            // Init bot here
            // Find cert if u want before WebHookAsync
            SetWebhookAsync(options.WebHookUrl);
        }
    }
}
