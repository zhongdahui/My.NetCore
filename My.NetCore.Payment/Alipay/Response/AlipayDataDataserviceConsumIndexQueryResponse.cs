using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataDataserviceConsumIndexQueryResponse.
    /// </summary>
    public class AlipayDataDataserviceConsumIndexQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 指数结果详情
        /// </summary>
        [JsonPropertyName("index_detail")]
        public List<IndexDetail> IndexDetail { get; set; }
    }
}
