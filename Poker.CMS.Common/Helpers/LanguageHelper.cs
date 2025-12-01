using Poker.CMS.Common.Attributes;
using Poker.CMS.Common.Enums;
using Poker.CMS.Common.Extensions;
using System.Globalization;
using System.Reflection;

namespace Poker.CMS.Common.Helpers
{
    public static class LanguageHelper
    {
        /// <summary>
        /// 轉換 DB users.lang 欄位的值為 enum
        /// </summary>
        /// <param name="dbValue"></param>
        /// <returns></returns>
        [Obsolete("這是舊版的, v2 請改用新的 ConvertToEnumFromCultureCode 方法")]
        public static Language ConvertToEnum(string dbValue)
        {
            return EnumExtensions.GetEnumValueFromAttribute<Language, Culture>(dbValue, "DbValue");
        }

        /// <summary>
        /// conver DB user.lang to Language enum
        /// </summary>
        /// <param name="code">code 的範例 zh-TW</param>
        /// <returns></returns>
        public static Language ConvertToEnumFromCultureCode(string code)
        {
            return EnumExtensions.GetEnumValueFromAttribute<Language, Culture>(code, "Code");
        }

        /// <summary>
        /// 設定多國語系文化資訊
        /// </summary>
        /// <param name="culture"></param>
        public static void SetCultureInfo(string culture)
        {
            var cultureInfo = new CultureInfo(culture);
            CultureInfo.CurrentCulture = cultureInfo;
            CultureInfo.CurrentUICulture = cultureInfo;
        }

        /// <summary>
        /// 根據 DB 的短代碼（如 zh_TW）找到語系代碼（如 zh-TW）
        /// </summary>
        /// <param name="shortCode">例如 zh_TW</param>
        /// <returns>例如 zh-TW</returns>
        public static string? GetFullCultureFromShortCode(string shortCode)
        {
            foreach (var field in typeof(Language).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attr = field.GetCustomAttribute<Culture>();
                if (attr != null && attr.DbValue.Equals(shortCode, StringComparison.OrdinalIgnoreCase))
                {
                    return attr.Code;
                }
            }

            return null;
        }

        /// <summary>
        /// 取得所有語言列舉中標註的 Culture Code（如 zh-TW, en-US 等）
        /// </summary>
        /// <returns>Culture code 列表</returns>
        public static List<string> GetAllCultureCodes()
        {
            var list = new List<string>();

            foreach (var field in typeof(Language).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attr = field.GetCustomAttribute<Culture>();
                if (attr != null)
                {
                    list.Add(attr.Code);
                }
            }

            return list;
        }

        /// <summary>
        /// 根據 Enum 數字值取得 Culture Code
        /// </summary>
        /// <param name="value">Enum 數字值</param>
        /// <returns>對應的 Culture Code 或 null</returns>
        public static string GetCultureCodeByEnumValue(int value)
        {
            var languageEnum = (Language)value;
            var memberInfo = typeof(Language).GetMember(languageEnum.ToString());

            var attr = memberInfo[0].GetCustomAttribute<Culture>();
            return attr.Code;

        }

        /// <summary>
        /// 根據 Enum 數字值取得 DbValue
        /// </summary>
        /// <param name="value">Enum 數字值</param>
        /// <returns>對應的 DbValue 或 null</returns>
        public static string GetDbValueByEnumValue(int value)
        {
            var languageEnum = (Language)value;
            var memberInfo = typeof(Language).GetMember(languageEnum.ToString());

            var attr = memberInfo[0].GetCustomAttribute<Culture>();
            return attr.DbValue;

        }

        /// <summary>
        /// 根據 Culture Code (如 "en-US") 取得對應的 Enum 數字值
        /// </summary>
        /// <param name="cultureCode">Culture Code，例如 "en-US"</param>
        /// <returns>對應的 Enum 數字值，若無法找到則返回 null</returns>
        public static int GetEnumValueFromCultureCode(string cultureCode)
        {
            foreach (Language lang in System.Enum.GetValues(typeof(Language)))
            {
                var memberInfo = typeof(Language).GetMember(lang.ToString());

                var attr = memberInfo[0].GetCustomAttribute<Culture>();
                if (attr != null && attr.Code.Equals(cultureCode, StringComparison.OrdinalIgnoreCase))
                {
                    return (int)lang;
                }
            }

            return 0;
        }
    }
}
