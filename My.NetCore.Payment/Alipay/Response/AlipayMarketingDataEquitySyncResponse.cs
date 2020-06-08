using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingDataEquitySyncResponse.
    /// </summary>
    public class AlipayMarketingDataEquitySyncResponse : AlipayResponse
    {
        /// <summary>
        /// true/false
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
