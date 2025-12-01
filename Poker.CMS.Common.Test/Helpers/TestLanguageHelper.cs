using Poker.CMS.Common.Enums;
using Poker.CMS.Common.Helpers;

namespace Poker.CMS.Common.Test.Helpers
{
    [TestClass]
    public class TestLanguageHelper
    {
        [TestMethod]
        public void TestGet()
        {
            var code = "zh-TW";
            var result = LanguageHelper.ConvertToEnumFromCultureCode(code);
            Assert.AreEqual(Language.ChineseTraditional, result);
        }
    }
}
