using Poker.CMS.Common.Api.Response.Enum;
using Poker.CMS.Common.Extensions;


namespace Poker.CMS.Common.Helpers
{
    public static class EnumHelper
    {
        public static IEnumerable<Record> Get(string enumName)
        {
            string fullTypeName = $"Poker.CMS.Common.Enums.{enumName}";
            Type enumType = Type.GetType(fullTypeName);

            if (enumType == null || !enumType.IsEnum)
            {
                throw new ArgumentException($"'{enumName}' is not a valid enum type.");
            }

            return System.Enum.GetValues(enumType)
                       .Cast<System.Enum>()
                       .Select(x => new Record
                       {
                           Id = Convert.ToInt32(x),
                           Name = x.GetText()
                       });
        }

        public static IEnumerable<string> GetNames()
        {
            return AppDomain.CurrentDomain
                .GetAssemblies()
                .SelectMany(a => a.GetTypes())
                .Where(t => t.IsEnum && t.Namespace == "Poker.CMS.Common.Enums")
                .Select(t => t.Name)
                .Distinct()
                .OrderBy(name => name);
        }
    }
}
