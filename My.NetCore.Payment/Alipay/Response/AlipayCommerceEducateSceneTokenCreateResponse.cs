using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceEducateSceneTokenCreateResponse.
    /// </summary>
    public class AlipayCommerceEducateSceneTokenCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 请求生成场景token
        /// </summary>
        [JsonPropertyName("token")]
        public string Token { get; set; }
    }
}
