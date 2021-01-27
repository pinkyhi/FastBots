using System;
using System.Collections.Generic;
using System.Text;

namespace FastBots.Types.Options
{
    public class FastBotsOptions
    {
        public string Name { get; set; }

        public string ProjectName { get; set; }

        public string Token { get; set; }

        public string WebHookUrl { get; set; }

        public char Separator { get; set; }
    }
}
