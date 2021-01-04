using Telegram.Bot;

namespace FastBots.Commands
{
    public class Bot : TelegramBotClient
    {
        public CommandTree commands;

        public Bot(string token) : base(token)
        {
#if USE_PROXY
            var Proxy = new WebProxy(Configuration.Proxy.Host, Configuration.Proxy.Port) { UseDefaultCredentials = true };
            Bot = new TelegramBotClient(Configuration.BotToken, webProxy: Proxy);
#else
            Bot = new TelegramBotClient(Configuration.BotToken);
#endif
            commands = new CommandTree();
        }
    }
}