namespace Poker.CMS.Common.Enums
{
    public enum PlayerFeatureType
    {
        // All-in
        AllinRate,
        PreflopAllinRate,
        AllinAvgSeconds,
        WeakHandAllInRate,

        // 玩家等級
        NewRegisteredDays,
        NewRegisteredRounds,
        BeginnerAvgRounds,
        JuniorAvgRounds,
        IntermediateAvgRounds,
        SeniorAvgRounds,
        ProfessionalAvgRounds,
        ExpertAvgRounds,
        TopAvgRounds,

        // 多帳號
        MultiAccountDeviceLoginCount,

        // 共用帳號
        SharedAccountIpDeviceCount,
        SharedAccountSwitchCount,

        // 異地登入 + 盜用
        RemoteLoginDistance,

        // 單向讓分
        OneWayTransferScore,
        OneWayTransferSameTableCount,
        OneWayTransferFoldCount,

        // AI / BOT
        AiBotAvgBetSec,
        AiBotBetErrorSec
    }
}
