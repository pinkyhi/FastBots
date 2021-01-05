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

        public async void Execute(Message message) // receive something like message
        {
            ElementAt(IndexOf(new Home(message.Text, null))).Execute(message);
        }
        
    }
}