using System;
using System.Threading.Tasks;
using Telegram.Bot.Args;
using Telegram.Bot.Types;

namespace FastBots.Commands
{
    public abstract class ACommand : IComparable
    {
        public string CommandName;

        public ACommand(string command)
        {
            CommandName = command;
        }

        public abstract void Execute(Message message);
        public abstract Task Execute(object sender, MessageEventArgs messageEventArgs);

        public int CompareTo(object o)
        {
            if (o is ACommand command)
                return String.Compare(command.CommandName, CommandName, StringComparison.Ordinal);

            throw new Exception("Can't cast to ACommand type!");
        }
    }
}