using System.Reflection;
using Poker.CMS.Common.Attributes;
using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Extensions
{
    public static class LanguageExtensions
    {
        public static string GetCultureCode(this Language language)
        {
            var fieldInfo = language.GetType().GetField(language.ToString());

            var attribute = fieldInfo.GetCustomAttributes(typeof(Culture), false)
                                     .FirstOrDefault() as Culture;

            return attribute?.Code ?? "en-US";
        }

        public static GameLanguage ToGameLanguage(this Language language)
        {
            // 取得 Language enum 的 Text
            var langMember = typeof(Language).GetMember(language.ToString()).FirstOrDefault();
            var textAttr = langMember?.GetCustomAttribute<Text>();

            string langText = textAttr?.Key;

            if (string.IsNullOrEmpty(langText))
                return GameLanguage.English; // fallback 預設英文

            // 取得所有 GameLanguage 欄位
            var gameLangFields = typeof(GameLanguage).GetFields(BindingFlags.Public | BindingFlags.Static);

            // 用 TextAttribute.Text 比對
            var matchByText = gameLangFields
                .Select(f => new
                {
                    Field = f,
                    Text = f.GetCustomAttribute<Text>()?.Key
                })
                .FirstOrDefault(x => !string.IsNullOrEmpty(x.Text) && x.Text.Equals(langText, StringComparison.OrdinalIgnoreCase));

            if (matchByText == null)
                return GameLanguage.English; // fallback 預設英文

            return (GameLanguage)matchByText.Field.GetValue(null)!;
        }
    }
}
