using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayPayCodecQrcodecacheAddResponse.
    /// </summary>
    public class AlipayPayCodecQrcodecacheAddResponse : AlipayResponse
    {
        /// <summary>
        /// true或者false
        /// </summary>
        [JsonPropertyName("success")]
        public string Success { get; set; }
    }
}
