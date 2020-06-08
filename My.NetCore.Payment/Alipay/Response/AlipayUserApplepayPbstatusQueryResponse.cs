using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayUserApplepayPbstatusQueryResponse.
    /// </summary>
    public class AlipayUserApplepayPbstatusQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 卡状态列表
        /// </summary>
        [JsonPropertyName("pass_status_list")]
        public OpenApiPassStatus PassStatusList { get; set; }

        /// <summary>
        /// ApplePay公用响应头
        /// </summary>
        [JsonPropertyName("response_header")]
        public OpenApiResponseHeader ResponseHeader { get; set; }
    }
}
