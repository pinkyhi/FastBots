using FastBots.Tests.Localization.Templates;
using System;
using Xunit;

namespace FastBots.Tests.Localization
{
    public class ExcepionsLocalizationTest
    {
        [Fact]
        public void CheckLocalizationWithCaseAndParam()
        {
            try
            {
                throw new SomeException("ru", "pinkyhi");
            }
            catch(Exception ex)
            {
                Assert.Equal(actual: ex.Message, expected: "Текст первого случая с параметром pinkyhi");
            }
        }
    }
}
