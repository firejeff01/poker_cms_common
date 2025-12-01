using Poker.CMS.Common.Enums;

namespace Poker.CMS.Common.OperationLog
{
    [AttributeUsage(AttributeTargets.Method)]
    public class OperationLogAttribute : Attribute
    {
        public OperationLogAction Action { get; set; }

        /// <summary>
        /// 指定模組名稱, 取代 Module Attribute 的設定
        /// </summary>
        public string? Module { get; set; }

        /// <summary>
        /// 指定子模組名稱, GM 指令、玩家上下分等 需補充說明的才需要指定
        /// </summary>
        public string? SubModule { get; set; }

        public OperationLogAttribute(OperationLogAction action, string? module = null, string? subModule = null)
        {
            Action = action;
            Module = module;
            SubModule = subModule;
        }
    }
}