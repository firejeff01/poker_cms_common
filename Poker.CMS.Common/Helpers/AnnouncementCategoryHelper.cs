using Poker.CMS.Common.Attributes;
using Poker.CMS.Common.Enums;
using System.Reflection;

namespace Poker.CMS.Common.Helpers
{
    public static class AnnouncementCategoryHelper
    {
        /// <summary>
        /// 取得所有公告分類列舉中標註的 Culture Code
        /// </summary>
        /// <returns>Culture code 列表</returns>
        public static List<string> GetAllCultureCodes()
        {
            var list = new List<string>();

            foreach (var field in typeof(AnnouncementCategory).GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                var attr = field.GetCustomAttribute<Culture>();
                if (attr != null)
                {
                    list.Add(attr.Code);
                }
            }

            return list;
        }
    }
}
