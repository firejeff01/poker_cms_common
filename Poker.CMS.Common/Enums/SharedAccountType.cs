using Poker.CMS.Common.Attributes;
using System.ComponentModel;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 共用帳號類型
    /// </summary>
    public enum SharedAccountType
    {
        /// <summary>
        /// 同時段多城市多設備登入
        /// </summary>
        [Description("MultiCityDeviceSameTime")]
        [Text("multi_city_device_same_time")]
        MultiCityDeviceSameTime = 1,

        /// <summary>
        /// 極短時間內異地登入
        /// </summary>
        [Description("RapidLocationChange")]
        [Text("rapid_location_change")]
        RapidLocationChange,

        /// <summary>
        /// 頻繁切換IP或設備
        /// </summary>
        [Description("FrequentIpOrDeviceSwitch")]
        [Text("frequent_ip_or_device_switch")]
        FrequentIpOrDeviceSwitch


    }
}
