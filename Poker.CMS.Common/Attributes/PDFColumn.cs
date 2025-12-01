using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.Attributes
{
    /// <summary>
    /// PDF 的欄位
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class PDFColumn : Attribute
    {
        public string Name { get; }
        public int Sort { get; }

        public PDFColumType Type { get; }

        public bool IsHideForEmpty { get; }

        /// <summary>
        /// PDF 的欄位
        /// </summary>
        /// <param name="name">名稱</param>
        /// <param name="sort">排序</param>
        /// <param name="type">類型</param>
        /// <param name="isHideForEmpty">沒有值的時候是否不顯示此欄位</param>
        public PDFColumn(string name, int sort, PDFColumType type = PDFColumType.Text, bool isHideForEmpty = false)
        {
            Name = name;
            Sort = sort;
            Type = type;
            IsHideForEmpty = isHideForEmpty;
        }
    }
}
