using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniBizdataTemplatemessageUploadResponse.
    /// </summary>
    public class AlipayOpenMiniBizdataTemplatemessageUploadResponse : AlipayResponse
    {
        /// <summary>
        /// 成功：true 失败：false
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
