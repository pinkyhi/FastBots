using Advanced.Algorithms.DataStructures;
using Telegram.Bot.Types;

namespace FastBots.Commands
{
    public class CommandTree: SplayTree<ACommand>
    {
        public void AddCommand(ACommand command)
        {
            Insert(command);
        }

        public void Execute(Message message)
        {
            ElementAt(IndexOf(new Template(message.Text, null))).Execute(message);
        }
    }
}