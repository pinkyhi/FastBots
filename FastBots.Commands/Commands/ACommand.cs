using System;
using Advanced.Algorithms.DataStructures;

namespace FastBots.Commands
{
    public abstract class ACommand : IComparable
    {
        public string CommandName;

        public ACommand(string command)
        {
            CommandName = command;
        }

        public abstract void Execute();

        public int CompareTo(object o)
        {
            if (o is ACommand command)
                return String.Compare(command.CommandName, CommandName, StringComparison.Ordinal);

            throw new Exception("Can't cast to ACommand type!");
        }
    }
}