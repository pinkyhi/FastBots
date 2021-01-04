using System;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace FastBots.Commands
{
    public abstract class ACommand : IComparable
    {
        public string command;
        public BotClient client;

        public ACommand(string command, BotClient client)
        {
            this.command = command;
            this.client = client;
        }

        public abstract void Execute(Message message);
        public abstract Task Execute(object sender, MessageEventArgs messageEventArgs);

        public int CompareTo(object o)
        {
            if (o is ACommand command)
                return String.Compare(command.command, this.command, StringComparison.Ordinal);

            throw new Exception("Can't cast to ACommand type!");
        }
    }
}