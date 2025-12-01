using Poker.CMS.Common.Attributes;
using Poker.CMS.Common.Enums;
using System.Reflection;

namespace Poker.CMS.Common.Helpers
{
    public static class GameLanguageHelper
    {
        public static string GetLanguageCodeByEnumValue(int value)
        {
            var gameLanguageEnum = (GameLanguage)value;
            var memberInfo = typeof(GameLanguage).GetMember(gameLanguageEnum.ToString());

            var attr = memberInfo[0].GetCustomAttribute<LanguageCode>();
            return attr.Code;
        }

        /// <summary>
        /// 取得所有 Language Code
        /// </summary>
        /// <returns>Language code 列表</returns>
        public static List<string> GetAllCultureCodes()
        {
            var list = new List<string>();

            foreach (var field in typeof(GameLanguage).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attr = field.GetCustomAttribute<LanguageCode>();
                if (attr != null)
                {
                    list.Add(attr.Code);
                }
            }

            return list;
        }
    }
}
