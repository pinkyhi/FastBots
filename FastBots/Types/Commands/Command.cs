using FastBots.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FastBots.Types.Commands
{
    public abstract class Command : SignatureCommand
    {
        public abstract bool IsConsistent<TUser>(Telegram.Bot.Types.Update update, TUser user) where TUser : TelegramUser;
        
        public abstract Task Execute<TUser>(Telegram.Bot.Types.Update update, TUser user) where TUser : TelegramUser;
    }
}
