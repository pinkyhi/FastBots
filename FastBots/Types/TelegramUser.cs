using FastBots.Types.Commands;
using System;
using System.Collections.Generic;
using System.Text;
using Telegram.Bot.Types;

namespace FastBots.Types
{
    public partial class TelegramUser
    {
        public int Id { get; set; }

        public bool IsBot { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string LanguageCode { get; set; }

        public int CurrentStatus { get; set; }
    }
}
