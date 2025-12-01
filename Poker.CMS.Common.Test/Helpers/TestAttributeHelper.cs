using Poker.CMS.Common.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Poker.CMS.Common.Test.Helpers
{
    [TestClass]
    public class TestAttributeHelper
    {
        [TestMethod]
        public void TestGetJsonPropertyName()
        {
            var propertyName = "TestProperty";

            var jsonPropertyName = AttributeHelper.GetJsonPropertyName<TestClass>(propertyName);

            Assert.AreEqual("test_property", jsonPropertyName);
        }

        [TestMethod]
        public void TestGetJsonPropertyName2()
        {
            var propertyName = "TestProperty";

            var jsonPropertyName = AttributeHelper.GetJsonPropertyName(typeof(TestClass), propertyName);

            Assert.AreEqual("test_property", jsonPropertyName);
        }
    }

    public class TestClass
    {
        [JsonPropertyName("test_property")]
        public string TestProperty { get; set; }
    }
}
