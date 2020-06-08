using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniMiniappHistoryQueryResponse.
    /// </summary>
    public class AlipayOpenMiniMiniappHistoryQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 小程序最近使用记录列表
        /// </summary>
        [JsonPropertyName("mini_app_history_infos")]
        public List<MiniAppHistoryInfo> MiniAppHistoryInfos { get; set; }
    }
}
