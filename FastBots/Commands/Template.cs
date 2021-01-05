using System;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace FastBots.Commands
{
    class Template : ACommand
    {
        public Template(string command, BotClient client) : base(command, client)
        {
        }

        public override async void Execute(Message message)
        {
            Console.WriteLine("Template!");
        }

        public override async Task Execute(object sender, MessageEventArgs messageEventArgs)
        {
            await client.SendTextMessageAsync(messageEventArgs.Message.Chat.Id, "Hello command!");
        }
    }
}