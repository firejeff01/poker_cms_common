namespace Poker.CMS.Common.Attributes
{
    /// <summary>
    /// 定義多國語系檔案的 key
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class Text : Attribute
    {
        public string Key { get; }

        public Text(string key)
        {
            Key = key;
        }
    }
}