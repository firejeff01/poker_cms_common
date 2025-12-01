namespace Poker.CMS.Common.Attributes
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    public class Module : Attribute
    {
        public string ModuleName { get; }

        public Module(string moduleName)
        {
            ModuleName = moduleName;
        }
    }
}
