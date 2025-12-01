using System.Reflection;
using System.Text.Json.Serialization;

namespace Poker.CMS.Common.Helpers
{
    public static class Converter
    {
        public static string ConvertJsonPropertyToModelProperty<T>(string jsonPropertyName)
        {
            var type = typeof(T);

            foreach (var property in type.GetProperties())
            {
                var jsonPropertyAttribute = property.GetCustomAttribute<JsonPropertyNameAttribute>();

                if (jsonPropertyAttribute != null && jsonPropertyAttribute.Name.Equals(jsonPropertyName, StringComparison.OrdinalIgnoreCase))
                {
                    return property.Name;
                }
            }

            return null;
        }
    }
}
