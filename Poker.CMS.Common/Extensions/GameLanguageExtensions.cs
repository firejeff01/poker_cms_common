using Poker.CMS.Common.Attributes;
using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Extensions
{
    public static class GameLanguageExtensions
    {
        public static string GetLanguageCode(this GameLanguage language)
        {
            var fieldInfo = language.GetType().GetField(language.ToString());

            var attribute = fieldInfo.GetCustomAttributes(typeof(LanguageCode), false)
                                     .FirstOrDefault() as LanguageCode;

            return attribute?.Code ?? "en";
        }
    }
}
