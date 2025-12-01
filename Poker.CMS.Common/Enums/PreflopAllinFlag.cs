namespace Poker.CMS.Common.Enums
{
    [Flags]
    public enum PreflopAllinFlag
    {
        /// <summary>
        /// 無
        /// </summary>
        None = 0,

        /// <summary>
        /// 攤牌
        /// </summary>
        Showdown = 1 << 0,  // 1

        /// <summary>
        /// 起手 All-in
        /// </summary>
        PreflopAllin = 1 << 1  // 2
    }
}
