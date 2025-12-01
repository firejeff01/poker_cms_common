namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// Game Server重載DB的DataType
    /// </summary>
    [Flags]
    public enum ReloadDataType
    {
        /// <summary>
        /// 通知server全部重load
        /// </summary>
        AllRelod = 0,

        /// <summary>
        /// 1：IP名單
        /// </summary>
        IpList = 1 << 0,

        /// <summary>
        /// 2：系統設定
        /// </summary>
        SystemSetting = 1 << 1,

        /// <summary>
        /// 4：總代理商列表
        /// </summary>
        Ga = 1 << 2,

        /// <summary>
        /// 8：代理商列表(包含保證金、遊戲規則、牌桌列表)
        /// </summary>
        Agent = 1 << 3,

        /// <summary>
        /// 16：遊戲列表
        /// </summary>
        Game = 1 << 4,

        /// <summary>
        /// 32：商城資料
        /// </summary>
        Shop = 1 << 5,

        /// <summary>
        /// 64：Banner
        /// </summary>
        Banner = 1 << 6,

        /// <summary>
        /// 128：跑馬燈
        /// </summary>
        Ticker = 1 << 7,

        /// <summary>
        /// 256：公告
        /// </summary>
        Announcement = 1 << 8,

        /// <summary>
        /// 512：虛寶定義
        /// </summary>
        VirtualItem = 1 << 9
    }
}
