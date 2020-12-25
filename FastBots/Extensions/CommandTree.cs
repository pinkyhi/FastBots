using System;
using Advanced.Algorithms.DataStructures;

namespace FastBots.Extensions
{
    public delegate void CommandHandler();

    public class CommandTree
    {
        private SplayTree<Command> _tree;

        public CommandTree()
        {
            _tree = new SplayTree<Command>();
        }
        public void AddCommand(string name, CommandHandler handler)
        {
            _tree.Insert(new Command(name, handler));
        }
    }

    public class Command : IComparable
    {
        public string Name;
        public CommandHandler Handler;

        public Command(string name, CommandHandler handler)
        {
            Name = name;
            Handler = handler;
        }

        public int CompareTo(object o)
        {
            if (o is Command command)
                return String.Compare(command.Name, Name, StringComparison.Ordinal);

            throw new Exception("Can't cast to Command type!");
        }
    }

    public class TestCommandTree
    {
        public void main()
        {
            CommandTree tree = new CommandTree();
            tree.AddCommand("/start", () => { });
        }
    }
}