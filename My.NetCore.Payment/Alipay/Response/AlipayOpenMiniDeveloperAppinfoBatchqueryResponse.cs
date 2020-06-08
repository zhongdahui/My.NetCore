using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniDeveloperAppinfoBatchqueryResponse.
    /// </summary>
    public class AlipayOpenMiniDeveloperAppinfoBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 多端应用信息
        /// </summary>
        [JsonPropertyName("app_base_info_list")]
        public List<MiniAppBaseInfoQueryResponse> AppBaseInfoList { get; set; }
    }
}
