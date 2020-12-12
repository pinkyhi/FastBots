using FastBots.Localization;
using System;
using System.Collections.Generic;
using System.Text;

namespace FastBots.Tests.Localization.Templates
{
    public class SomeException : Exception
    {
        static Dictionary<int, Dictionary<string, string>> LocalizationMap = new Dictionary<int, Dictionary<string, string>>
        {
            { 1, new Dictionary<string, string>
                {
                    { "en", "First case text with parameter {0}" },
                    { "ru", "Текст первого случая с параметром {0}" }
                }
            },
            { 2, new Dictionary<string, string>
                {
                    { "en", "Second case text with parameter {0}" },
                    {  "ru", "Текст второго случая с параметром {0}" }
                }
            },
        };

        public SomeException(string languageCode, string username) : base(String.Format(Localizer.Localize(LocalizationMap, 1, languageCode), username))
        {
        }
    }
}
