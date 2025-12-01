using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 商品類別
    /// </summary>
    public enum ShopV2Type
    {
        /// <summary>
        /// 鑽石商品
        /// </summary>
        [Description("Diamond")]
        [Text("diamond")]
        Diamond = 0,

        /// <summary>
        /// 商品
        /// </summary>
        [Description("Product")]
        [Text("product")]
        Product = 1
    }
}
