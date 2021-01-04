using System;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace FastBots.Commands
{
    class Home : ACommand
    {
        public Home(string command) : base(command)
        {
        }

        public override async void Execute(Message message)
        {
            Console.WriteLine("Home!");
        }

        public override async Task Execute(object sender, MessageEventArgs messageEventArgs)
        {
            
        }
    }
}