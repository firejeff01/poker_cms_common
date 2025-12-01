namespace Poker.CMS.Common.Attributes
{
    /// <summary>
    /// 定義 Enum 的簡短名稱
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ShortNameAttribute : Attribute
    {
        public string Name { get; }

        public ShortNameAttribute(string name)
        {
            Name = name;
        }
    }
}

