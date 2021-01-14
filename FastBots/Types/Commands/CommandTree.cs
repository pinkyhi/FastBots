using Advanced.Algorithms.DataStructures;
using FastBots.Exceptions;
using FastBots.Types;
using FastBots.Types.Options;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace FastBots.Types.Commands
{
    public class CommandTree : SplayTree<IComparable>
    {
        private readonly char commandsSeparator;

        public CommandTree(IServiceProvider services, FastBotsOptions options)
        {
            this.commandsSeparator = options.Separator;

            // Initialize commands here
            IEnumerable<Command> commands = Assembly.GetAssembly(typeof(Command)).GetTypes().Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Command))).Select(t => ActivatorUtilities.CreateInstance(services, t)).Cast<Command>().AsEnumerable();
            foreach(Command command in commands)
            {
                this.AddCommand(command);
            }
        }

        public void AddCommand(Command command)
        {
            if (command.Code.Contains(commandsSeparator))
            {
                throw new ArgumentException($"Separator in signature \'{command.Code}\'");
            }
            int index = this.IndexOf(command);
            if(index != -1)
            {
                throw new ArgumentOutOfRangeException($"Concurrent signature \'{command.Code}\'");
            }

            this.Insert(command);
        }

        public async Task FindAndExecute<TUser>(Update update, TUser user) where TUser : TelegramUser
        {
            string commandKey = update.Message.Text;
            int index = this.IndexOf(commandKey);
            if(index > -1)
            {
                Command commandNow = this.ElementAt(index) as Command;
                if(commandNow.IsConsistent(update, user))
                {
                    await commandNow.Execute(update, user);
                }
                else
                {
                    throw new WrongSequenceException(update);
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Command not found");
            }
        }
    }
}