using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiTradeKbpaymentPayorderSyncResponse.
    /// </summary>
    public class KoubeiTradeKbpaymentPayorderSyncResponse : AlipayResponse
    {
        /// <summary>
        /// 请求id
        /// </summary>
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }
    }
}
