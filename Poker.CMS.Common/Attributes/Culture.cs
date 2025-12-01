namespace Poker.CMS.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class Culture : Attribute
    {
        public string Code { get; }
        public string DbValue { get; }

        public Culture(string code, string dbValue)
        {
            Code = code;
            DbValue = dbValue;
        }
    }
}
