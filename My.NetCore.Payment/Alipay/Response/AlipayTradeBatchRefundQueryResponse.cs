using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayTradeBatchRefundQueryResponse.
    /// </summary>
    public class AlipayTradeBatchRefundQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 退款明细信息
        /// </summary>
        [JsonPropertyName("result_details")]
        public List<BatchRefundDetailResult> ResultDetails { get; set; }
    }
}
