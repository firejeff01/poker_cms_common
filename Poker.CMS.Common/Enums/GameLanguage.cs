using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    public enum GameLanguage
    {
        [LanguageCode("en")]
        [Description("en")]
        [Text("english")]
        English = 1,

        [LanguageCode("zh")]
        [Description("zh")]
        [Text("chinese_simplified")]
        ChineseSimplified = 2,

        [LanguageCode("zh-TW")]
        [Description("zh-TW")]
        [Text("chinese_traditional")]
        ChineseTraditional = 3,

        [LanguageCode("tl")]
        [Description("tl")]
        [Text("filipino")]
        Filipino = 4,

        [LanguageCode("th")]
        [Description("th")]
        [Text("thai")]
        Thai = 5,

        [LanguageCode("vi")]
        [Description("vi")]
        [Text("vietnamese")]
        Vietnamese = 6,

        [LanguageCode("id")]
        [Description("id")]
        [Text("indonesian")]
        Indonesian = 7,

        [LanguageCode("pt")]
        [Description("pt")]
        [Text("portuguese")]
        Portuguese = 8,

        [LanguageCode("es")]
        [Description("es")]
        [Text("spanish")]
        Spanish = 9,

        [LanguageCode("ja")]
        [Description("ja")]
        [Text("japanese")]
        Japanese = 10,

        [LanguageCode("ko")]
        [Description("ko")]
        [Text("korean")]
        Korean = 11,

        [LanguageCode("fr")]
        [Description("fr")]
        [Text("french")]
        French = 12,
    }
}
