using Poker.CMS.Common.Enums;
using Poker.CMS.Common.Extensions;
using Poker.CMS.Common.Localization;
using System.Globalization;

namespace Poker.CMS.Common.Test
{
    [TestClass]
    public sealed class TestLocalization
    {
        [TestMethod]
        public void Test()
        {
            var localizer = new JsonStringLocalizer();

            CultureInfo.CurrentCulture = new CultureInfo("zh-TW");
            var newFormat1 = localizer["agent.ga_name"];
            var newFormat2 = localizer["common.ga_name"];
            var oldFormat = localizer["ga_name"];

            Assert.AreEqual("總代理編號", newFormat1);
            Assert.AreEqual("總代理編號", newFormat2);
            Assert.AreEqual("總代理編號", oldFormat);
        }

        [TestMethod]
        public void TestEnum1()
        {
            var localizer = new JsonStringLocalizer();
            CultureInfo.CurrentCulture = new CultureInfo("zh-TW");
            var textDeposit = GoldCause.Deposit.GetText();
            Assert.AreEqual("上分", textDeposit);
        }

        [TestMethod]
        public void TestEnum2()
        {
            var localizer = new JsonStringLocalizer();
            CultureInfo.CurrentCulture = new CultureInfo("zh-TW");

            var textDeposit2 = localizer["enum.gold_cause.deposit"];
            Assert.AreEqual("上分", textDeposit2);
        }
    }
}