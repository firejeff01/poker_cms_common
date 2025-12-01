using Poker.CMS.Common.Helpers;

namespace Poker.CMS.Common.Test
{
    [TestClass]
    public sealed class TestSnowflakeIdGenerator
    {
        [TestMethod]
        public void TestNextId()
        {
            var set = new HashSet<long>();
            var snowflake = new SnowflakeIdGenerator(1, 1);

            for (int i = 0; i < 1000; i++)
            {
                var id = snowflake.NextId();
                set.Add(id);
            }

            Assert.IsTrue(set.Count == 1000);
        }

        /// <summary>
        /// 錯誤用法
        /// </summary>
        [TestMethod]
        public void TestNextId2()
        {
            var set = new HashSet<long>();

            for (int i = 0; i < 1000; i++)
            {
                // 把 instance 放在迴圈裡會產生重複的 id
                var snowflake = new SnowflakeIdGenerator(1, 1);
                var id = snowflake.NextId();
                set.Add(id);
            }

            Assert.IsFalse(set.Count == 1000);
        }
    }
}