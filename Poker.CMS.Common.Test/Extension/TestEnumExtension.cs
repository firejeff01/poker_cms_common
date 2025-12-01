using Poker.CMS.Common.Enums;
using Poker.CMS.Common.Extensions;

namespace Poker.CMS.Common.Test.Extension
{
    [TestClass]
    public sealed class TestEnumExtension
    {
        [TestMethod]
        public void TestGetTextKeyWithFullName()
        {
            var enumValue = GameServerApiCode.DuplicateClick;
            var textKey = enumValue.GetTextKeyWithFullName();

            Assert.AreEqual("enum.game_server_api_code.duplicate_click", textKey);
        }

        [TestMethod]
        public void TestGetTextKey()
        {
            var enumValue = GameServerApiCode.DuplicateClick;
            var textKey = enumValue.GetTextKey();

            Assert.AreEqual("duplicate_click", textKey);
        }
    }
}
