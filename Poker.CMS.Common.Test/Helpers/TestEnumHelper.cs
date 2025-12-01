using Poker.CMS.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poker.CMS.Common.Test.Helpers
{
    [TestClass]
    public class TestEnumHelper
    {
        [TestMethod]
        public void TestGet()
        {
            var enumName = "GoldCause";

            var result = EnumHelper.Get(enumName);

            Assert.IsTrue(result.Any());
        }

        [TestMethod]
        public void TestGetName()
        {
            var result = EnumHelper.GetNames();

            Assert.IsTrue(result.Any());
        }
    }
}