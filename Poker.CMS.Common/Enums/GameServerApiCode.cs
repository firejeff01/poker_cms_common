using Poker.CMS.Common.Attributes;

namespace Poker.CMS.Common.Enums
{
    /// <summary>
    /// 遊戲伺服器API回應的狀態碼
    /// </summary>
    public enum GameServerApiCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Text("success")]
        Success = 1,

        /// <summary>
        /// 失敗
        /// </summary>
        [Text("failed")]
        Failed = -2,

        /// <summary>
        /// 含有不安全的字元
        /// </summary>
        [Text("contains_unsafe_characters")]
        ContainsUnsafeCharacters = -6,

        /// <summary>
        /// 無效的命令
        /// </summary>
        [Text("invalid_command")]
        InvalidCommand = -7,

        /// <summary>
        /// Server尚未準備好
        /// </summary>
        [Text("server_not_ready")]
        ServerNotReady = -8,

        /// <summary>
        /// 解密失敗
        /// </summary>
        [Text("decryption_failed")]
        DecryptionFailed = -10,

        /// <summary>
        /// 參數錯誤
        /// </summary>
        [Text("parameter_error")]
        ParameterError = -12,

        /// <summary>
        /// 該API已達到查詢次數限制
        /// </summary>
        [Text("this_api_has_reached_the_query_limit")]
        ThisApiHasReachedTheQueryLimit = -21,

        /// <summary>
        /// 每次請求查詢需間隔30秒以上
        /// </summary>
        [Text("each_query_request_must_be_spaced_at_least_30_seconds_apart")]
        EachQueryRequestMustBeSpacedAtLeast30SecondsApart = -22,

        /// <summary>
        /// 工作程序繁忙中，請稍後
        /// </summary>
        [Text("the_process_is_busy_please_try_again_later")]
        TheProcessIsBusyPleaseTryAgainLater = -23,

        /// <summary>
        /// 不合法的查詢時間，起始時間大於結束時間
        /// </summary>
        [Text("invalid_query_time_start_time_is_greater_than_end_time")]
        InvalidQueryTimeStartTimeIsGreaterThanEndTime = -24,

        /// <summary>
        /// 不合法的查詢時間，查詢時間區間不合法
        /// </summary>
        [Text("invalid_query_time_the_time_interval_is_not_valid")]
        InvalidQueryTimeTheTimeIntervalIsNotValid = -25,

        /// <summary>
        /// 不合法的查詢時間，查詢時間超過可允許範圍
        /// </summary>
        [Text("invalid_query_time_the_query_time_exceeds_the_allowable_range")]
        InvalidQueryTimeTheQueryTimeExceedsTheAllowableRange = -26,

        /// <summary>
        /// 重複登入
        /// </summary>
        [Text("duplicate_login")]
        DuplicateLogin = -100,

        /// <summary>
        /// 帳號重複
        /// </summary>
        [Text("duplicate_account")]
        DuplicateAccount = -101,

        /// <summary>
        /// 工作已滿
        /// </summary>
        [Text("job_is_full")]
        JobIsFull = -102,

        /// <summary>
        /// 帳號不存在
        /// </summary>
        [Text("account_does_not_exist")]
        AccountDoesNotExist = -103,

        /// <summary>
        /// 密碼錯誤
        /// </summary>
        [Text("incorrect_password")]
        IncorrectPassword = -104,

        /// <summary>
        /// JSON 解碼失敗
        /// </summary>
        [Text("json_decoding_failed")]
        JsonDecodingFailed = -105,

        /// <summary>
        /// Token 錯誤
        /// </summary>
        [Text("invalid_token")]
        InvalidToken = -106,

        /// <summary>
        /// Token 逾期
        /// </summary>
        [Text("token_expired")]
        TokenExpired = -107,

        /// <summary>
        /// Server 斷線
        /// </summary>
        [Text("server_disconnected")]
        ServerDisconnected = -108,

        /// <summary>
        /// 該帳號在其它遊戲中
        /// </summary>
        [Text("this_account_is_logged_into_another_game")]
        ThisAccountIsLoggedIntoAnotherGame = -109,

        /// <summary>
        /// 不合法的金幣類別
        /// </summary>
        [Text("invalid_coin_type")]
        InvalidCoinType = -110,

        /// <summary>
        /// 金幣不足
        /// </summary>
        [Text("insufficient_coins")]
        InsufficientCoins = -111,

        /// <summary>
        /// 金幣太多
        /// </summary>
        [Text("too_many_coins")]
        TooManyCoins = -112,

        /// <summary>
        /// 金幣超過上限
        /// </summary>
        [Text("coin_limit_exceeded")]
        CoinLimitExceeded = -113,

        /// <summary>
        /// 金幣增加失敗
        /// </summary>
        [Text("failed_to_add_coins")]
        FailedToAddCoins = -114,

        /// <summary>
        /// 該帳號有牌局尚未結束
        /// </summary>
        [Text("this_account_has_an_unfinished_game")]
        ThisAccountHasAnUnfinishedGame = -115,

        /// <summary>
        /// 無法取得遊戲資料
        /// </summary>
        [Text("unable_to_retrieve_game_data")]
        UnableToRetrieveGameData = -116,

        /// <summary>
        /// 重複點擊
        /// </summary>
        [Text("duplicate_click")]
        DuplicateClick = -117,

        /// <summary>
        /// 帳號快取並不存在
        /// </summary>
        [Text("account_cache_does_not_exist")]
        AccountCacheDoesNotExist = -118,

        /// <summary>
        /// 金幣異動失敗
        /// </summary>
        [Text("failed_to_modify_coins")]
        FailedToModifyCoins = -119,

        /// <summary>
        /// 系統忙碌中
        /// </summary>
        [Text("system_is_busy")]
        SystemIsBusy = -120,

        /// <summary>
        /// 字串不安全
        /// </summary>
        [Text("string_contains_unsafe_characters")]
        StringContainsUnsafeCharacters = -121,

        /// <summary>
        /// 錯誤的時間
        /// </summary>
        [Text("incorrect_time")]
        IncorrectTime = -122,

        /// <summary>
        /// 時間範圍太大
        /// </summary>
        [Text("time_range_is_too_large")]
        TimeRangeIsTooLarge = -123,

        /// <summary>
        /// 時間驗證失敗
        /// </summary>
        [Text("time_verification_failed")]
        TimeVerificationFailed = -124,

        /// <summary>
        /// 簽名驗證失敗
        /// </summary>
        [Text("signature_verification_failed")]
        SignatureVerificationFailed = -125,

        /// <summary>
        /// 找不到代理商
        /// </summary>
        [Text("agent_not_found")]
        AgentNotFound = -126,

        /// <summary>
        /// 保證金不足
        /// </summary>
        [Text("insufficient_deposit")]
        InsufficientDeposit = -131,

        /// <summary>
        /// 保證金太多
        /// </summary>
        [Text("too_much_deposit")]
        TooMuchDeposit = -132,

        /// <summary>
        /// 上分金額不合法
        /// </summary>
        [Text("invalid_deposit_amount")]
        InvalidDepositAmount = -133,
    }
}
