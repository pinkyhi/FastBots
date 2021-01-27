using FastBots.Types.Commands;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Telegram.Bot.Types;

namespace FastBots.Types
{
    public class TelegramUser
    {
        [Key]
        public int Id { get; set; }

        public bool IsBot { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Username { get; set; }

        public string LanguageCode { get; set; }

        public int CurrentStatus { get; set; }
    }
}
