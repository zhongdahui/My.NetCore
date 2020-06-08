using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEbppRechargeNotifySendResponse.
    /// </summary>
    public class AlipayEbppRechargeNotifySendResponse : AlipayResponse
    {
        /// <summary>
        /// 操作状态
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }
    }
}
