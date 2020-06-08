using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayInsSceneApplicationBatchqueryResponse.
    /// </summary>
    public class AlipayInsSceneApplicationBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 投保单列表
        /// </summary>
        [JsonPropertyName("applications")]
        public List<InsApplicationQuery> Applications { get; set; }
    }
}
