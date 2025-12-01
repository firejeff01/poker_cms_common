using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 裝備部位
    /// </summary>
    public enum EquipSlot
    {
        /// <summary>
        /// 任意部位
        /// </summary>
        [Text("any_slot")]
        AnySlot = -1,

        /// <summary>
        /// 不可裝備
        /// </summary>
        [Text("not_equippable")]
        NotEquippable = 0,

        /// <summary>
        /// 部位n
        /// </summary>
        [Text("slot_n")]
        SlotN = 1,
    }
}
