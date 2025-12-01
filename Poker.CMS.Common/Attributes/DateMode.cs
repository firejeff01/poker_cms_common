namespace Poker.CMS.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public class DateMode : Attribute
    {
        public string FrontEndValue { get; }

        public DateMode(string value)
        {
            FrontEndValue = value;
        }
    }
}
