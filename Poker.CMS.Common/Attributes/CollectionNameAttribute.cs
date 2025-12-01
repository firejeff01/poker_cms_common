namespace Poker.CMS.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CollectionNameAttribute : Attribute
    {
        public string Name { get; }

        public CollectionNameAttribute(string name)
        {
            Name = name;
        }
    }
}