using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace FastBots.Exceptions
{
    public class WrongSequenceException : Exception
    {
        public Update Update { get; set; }
        public WrongSequenceException(Update update) : base()
        {
            this.Update = update;
        }
    }
}
