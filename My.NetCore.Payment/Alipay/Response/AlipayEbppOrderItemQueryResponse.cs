using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEbppOrderItemQueryResponse.
    /// </summary>
    public class AlipayEbppOrderItemQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 订单项
        /// </summary>
        [JsonPropertyName("item")]
        public EbppOrderItem Item { get; set; }
    }
}
