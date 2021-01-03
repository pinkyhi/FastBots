using Advanced.Algorithms.DataStructures;

namespace FastBots.Commands
{
    public class CommandTree
    {
        private SplayTree<ACommand> _tree;

        public CommandTree()
        {
            _tree = new SplayTree<ACommand>();
        }

        public void AddCommand(ACommand command)
        {
            _tree.Insert(command);
        }
    }
}