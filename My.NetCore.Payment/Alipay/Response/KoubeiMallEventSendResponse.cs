using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMallEventSendResponse.
    /// </summary>
    public class KoubeiMallEventSendResponse : AlipayResponse
    {
        /// <summary>
        /// 事件ID
        /// </summary>
        [JsonPropertyName("event_id")]
        public string EventId { get; set; }
    }
}
