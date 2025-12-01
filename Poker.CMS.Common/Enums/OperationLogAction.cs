using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 操作記錄的動作類型
    /// </summary>
    public enum OperationLogAction
    {
        /// <summary>
        /// 下載檔案
        /// </summary>
        [Text("download")]
        Download = 2,

        /// <summary>
        /// 新增資料
        /// </summary>
        [Text("insert")]
        Insert = 3,

        /// <summary>
        /// 編輯資料
        /// </summary>
        [Text("update")]
        Update = 4,

        /// <summary>
        /// 刪除資料 (包含軟刪除)
        /// </summary>
        [Text("delete")]
        Delete = 5,

        /// <summary>
        /// 同步資料至遊戲伺服器
        /// </summary>
        [Text("sync")]
        Sync = 6,

        /// <summary>
        /// 操作 GM 指令
        /// </summary>
        [Text("gm_command")]
        GMCommand = 7,

        /// <summary>
        /// 登入
        /// </summary>
        [Text("login")]
        Login = 8,

        /// <summary>
        /// 匯入
        /// </summary>
        [Text("import")]
        Import = 9,
    }
}