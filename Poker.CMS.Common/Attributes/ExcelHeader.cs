namespace Poker.CMS.Common.Attributes
{
    /// <summary>
    /// 定義 excel 欄位名稱
    /// </summary>
    [AttributeUsage(AttributeTargets.Property)]
    public class ExcelHeader : Attribute
    {
        public string Name { get; }
        public int Sort { get; }

        public ExcelHeader(string name, int sort)
        {
            Name = name;
            Sort = sort;
        }
    }
}
