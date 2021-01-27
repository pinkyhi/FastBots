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

        public CommandTree(IServiceProvider provider, FastBotsOptions options)
        {
            this.commandsSeparator = options.Separator;
            
            // Initialize commands here
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.StartsWith(options.ProjectName)).ToList();
                        IEnumerable<Type> commandsTypes = assemblies.SelectMany(n => n.GetTypes()
                    .Where(myType => myType.IsClass && !myType.IsAbstract && myType.IsSubclassOf(typeof(Command))).ToList(),
                (n, c) => c).ToList();
            IEnumerable<Command> commands = commandsTypes.Select(t => ActivatorUtilities.CreateInstance(provider, t)).Cast<Command>().ToList();
            foreach (Command command in commands)
            {
                this.AddCommand(command);
            }
        }

        private void AddCommand(Command command)
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

        public async Task FindAndExecute(Update update, TelegramUser user)
        {
            var commandSignature = new CommandSignature() 
            { 
                Status = user.CurrentStatus
            };
            switch (update.Type)
            {
                case (Telegram.Bot.Types.Enums.UpdateType.CallbackQuery):
                    {
                        break;
                    }
                case (Telegram.Bot.Types.Enums.UpdateType.Message):
                    {
                        if (update.Message.Text.StartsWith('/'))
                        {
                            int spaceIndex = update.Message.Text.Trim().IndexOf(' ');
                            if(spaceIndex == -1)
                            {
                                commandSignature.Code = update.Message.Text.Substring(0);
                            }
                            else
                            {
                                commandSignature.Code = update.Message.Text.Substring(0, spaceIndex);
                            }
                        }
                        break;
                    }
                default:
                    {
                        throw new UnknownUpdateTypeException(update);
                    }
            }
            int index = this.IndexOf(commandSignature);
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