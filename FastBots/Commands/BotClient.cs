using Telegram.Bot;
using Telegram.Bot.Args;
using Telegram.Bot.Types.Enums;

namespace FastBots.Commands
{
    public class BotClient : TelegramBotClient
    {
        public static CommandTree commands;

        public BotClient(string token, string webHookUrl) : base(token)
        {
            SetWebhookAsync(webHookUrl);
            commands = new CommandTree();

            OnMessage += BotOnMessageReceived;
        }

        private static async void BotOnMessageReceived(object sender, MessageEventArgs messageEventArgs)
        {
            var message = messageEventArgs.Message;
            if (message == null || message.Type != MessageType.Text)
                return;

            commands.Execute(message);
        }
    }
}