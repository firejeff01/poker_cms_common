using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    public enum Language
    {
        [Culture("de-DE", "de")]
        [Text("germany")]
        Germany = 0,

        [Culture("en-US", "en")]
        [Text("english")]
        English = 1,

        [Culture("es-ES", "es")]
        [Text("spanish")]
        Spanish = 2,

        [Culture("it-IT", "it")]
        [Text("italian")]
        Italian = 3,

        [Culture("ja-JP", "ja")]
        [Text("japanese")]
        Japanese = 4,

        [Culture("ru-RU", "ru")]
        [Text("russian")]
        Russian = 5,

        [Culture("zh-CN", "zh_CN")]
        [Text("chinese_simplified")]
        ChineseSimplified = 6,

        [Culture("zh-TW", "zh_TW")]
        [Text("chinese_traditional")]
        ChineseTraditional = 7,
    }
}