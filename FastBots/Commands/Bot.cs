using Telegram.Bot;

namespace FastBots.Commands
{
    public class Bot : TelegramBotClient
    {
        public CommandTree commands;

        public Bot(string token, string webHookUrl) : base(token)
        {
            SetWebhookAsync(webHookUrl);
            commands = new CommandTree();
        }
    }
}