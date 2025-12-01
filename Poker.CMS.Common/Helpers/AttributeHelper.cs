using System.Reflection;
using System.Text.Json.Serialization;

namespace Poker.CMS.Common.Helpers
{
    public static class AttributeHelper
    {
        public static bool HasAttribute<T>(string propertyName, Type attributeType)
        {
            var property = typeof(T).GetProperty(propertyName);
            return property != null && Attribute.IsDefined(property, attributeType);
        }

        public static string GetJsonPropertyName<T>(string propertyName)
        {
            var prop = typeof(T).GetProperty(propertyName);
            var attr = prop?.GetCustomAttribute<JsonPropertyNameAttribute>();
            return attr?.Name ?? propertyName;
        }

        public static string GetJsonPropertyName(Type type, string propertyName)
        {
            var property = type.GetProperty(propertyName);
            var attr = property?.GetCustomAttribute<JsonPropertyNameAttribute>();
            return attr?.Name ?? propertyName;
        }

        public static TEnum? GetEnumByAttributeCode<TEnum, TAttribute>(string code)
        where TEnum : struct, System.Enum
        where TAttribute : Attribute
        {
            foreach (var field in typeof(TEnum).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attr = field.GetCustomAttribute<TAttribute>();
                if (attr != null)
                {
                    var codeProp = typeof(TAttribute).GetProperty("Code");
                    if (codeProp != null && codeProp.GetValue(attr) as string == code)
                    {
                        return (TEnum)field.GetValue(null)!;
                    }
                }
            }

            return null;
        }
    }
}