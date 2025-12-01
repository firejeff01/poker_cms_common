using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Extensions
{
    public static class MongoCollectionExtensions
    {
        public static string GetCollectionName<T>()
        {
            var attribute = typeof(T).GetCustomAttributes(typeof(CollectionNameAttribute), true).FirstOrDefault() as CollectionNameAttribute;
            return attribute?.Name ?? typeof(T).Name;
        }
    }
}
