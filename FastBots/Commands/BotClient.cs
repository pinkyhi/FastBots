using Telegram.Bot;

namespace FastBots.Commands
{
    public class BotClient : TelegramBotClient
    {
        public CommandTree commands;

        public BotClient(string token, string webHookUrl) : base(token)
        {
            SetWebhookAsync(webHookUrl);
            commands = new CommandTree(this);
        }
    }
}