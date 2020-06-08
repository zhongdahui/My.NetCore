using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiRetailWmsInboundorderCreateResponse.
    /// </summary>
    public class KoubeiRetailWmsInboundorderCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 入库通知单id
        /// </summary>
        [JsonPropertyName("inbound_order_id")]
        public string InboundOrderId { get; set; }
    }
}
