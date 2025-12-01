namespace Poker.CMS.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class LanguageCode : Attribute
    {
        public string Code { get; }

        public LanguageCode(string code)
        {
            Code = code;
        }
    }
}
