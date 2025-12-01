using Microsoft.Extensions.Localization;
using Poker.CMS.Common.Attributes;
using Poker.CMS.Common.Localization;
using System.ComponentModel;
using System.Reflection;

namespace Poker.CMS.Common.Extensions
{
    public static class EnumExtensions
    {
        /// <summary>
        /// 語系處理過的 Description
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string GetLocalizedDescription(this System.Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return null;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            IStringLocalizer localizer = new JsonStringLocalizer();
            return localizer[attribute.Description];
        }

        public static string GetDescription(this System.Enum value)
        {
            FieldInfo fieldInfo = value.GetType().GetField(value.ToString());
            if (fieldInfo == null) return null;
            var attribute = (DescriptionAttribute)fieldInfo.GetCustomAttribute(typeof(DescriptionAttribute));
            return attribute.Description;
        }

        public static T GetEnumValueFromDateModeAttr<T>(string frontEndValue) where T : System.Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                var attribute = field.GetCustomAttribute<DateMode>();
                if (attribute != null && attribute.FrontEndValue == frontEndValue)
                {
                    return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException($"No enum value with description '{frontEndValue}' found in {typeof(T)}.");
        }

        public static TEnum GetEnumValueFromAttribute<TEnum, TAttribute>(string value, string prop)
            where TEnum : System.Enum
            where TAttribute : System.Attribute
        {
            var debug = typeof(TEnum).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static);
            foreach (var field in typeof(TEnum).GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            {
                var attribute = field.GetCustomAttribute<TAttribute>();

                if (attribute != null)
                {
                    var property = typeof(TAttribute).GetProperty(prop);
                    if (property != null)
                    {
                        var attributeValue = property.GetValue(attribute)?.ToString();
                        if (attributeValue == value)
                        {
                            return (TEnum)field.GetValue(null);
                        }
                    }
                }
            }

            throw new ArgumentException($"No enum value with description '{value}' found in {typeof(TEnum)}.");
        }

        /// <summary>
        /// 取得 enum 的多國語言文字
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetText(this System.Enum value)
        {
            if (value == null) return string.Empty;

            var key = GetTextKeyWithFullName(value);
            IStringLocalizer localizer = new JsonStringLocalizer();
            return localizer[key] ?? value.ToString();
        }

        /// <summary>
        /// 取得 enum Text attribute 的 key (完整的翻譯檔名稱路徑)
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetTextKeyWithFullName(this System.Enum value)
        {
            if (value == null) return string.Empty;

            var key = GetTextKey(value);

            var fullName = $"enum.{value.GetType().Name.ToSnakeCase()}.{key}";
            return fullName;
        }

        /// <summary>
        /// 取得 enum Text attribute 的 key
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetTextKey(this System.Enum value)
        {
            if (value == null) return string.Empty;

            // Get the field info
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field == null) return string.Empty;

            // Get the Text attribute, if exists
            Text attribute = field.GetCustomAttribute<Text>();

            return attribute?.Key ?? string.Empty;
        }

        /// <summary>
        /// 取得 enum ShortName attribute 的值
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns></returns>
        public static string GetShortName(this System.Enum value)
        {
            if (value == null) return string.Empty;

            // Get the field info
            FieldInfo field = value.GetType().GetField(value.ToString());

            if (field == null) return string.Empty;

            // Get the ShortName attribute, if exists
            ShortNameAttribute attribute = field.GetCustomAttribute<ShortNameAttribute>();

            return attribute?.Name ?? string.Empty;
        }
    }
}