using Poker.CMS.Common.Extensions;

namespace Poker.CMS.Common.Test.Extension
{
    [TestClass]
    public sealed class TestExceptionExtension
    {
        [TestMethod]
        public void TestGetMessage()
        {
            var exception = new NotImplementedException("Test exception");

            var mesage = exception.GetMessage();

            Assert.IsTrue(mesage.Contains("🚨 Exception Alert 🚨"));
        }
    }
}