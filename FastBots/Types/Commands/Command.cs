﻿using FastBots.Types;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FastBots.Types.Commands
{
    /// <summary>
    /// If Code is null then it's input<br/>
    /// If Status is null then it's command<br/>
    /// If Code and Status aren't null then it's callback
    /// </summary>
    public abstract class Command<TUser> : CommandSignature where TUser : TelegramUser
    {
        public abstract void ValidateEnvironment(Telegram.Bot.Types.Update update, TUser user);
        
        public abstract Task Execute(Telegram.Bot.Types.Update update, TUser user);
    }
}
