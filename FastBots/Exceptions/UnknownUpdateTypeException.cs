using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace FastBots.Exceptions
{
    public class UnknownUpdateTypeException : Exception
    {
        public Update Update { get; set; }

        public UnknownUpdateTypeException(Update update) : base()
        {
            this.Update = update;
        }
    }
}
