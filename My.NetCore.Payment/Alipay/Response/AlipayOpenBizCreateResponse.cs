using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenBizCreateResponse.
    /// </summary>
    public class AlipayOpenBizCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 1
        /// </summary>
        [JsonPropertyName("a")]
        public string A { get; set; }

        /// <summary>
        /// 211
        /// </summary>
        [JsonPropertyName("b")]
        public GavintestNewonline B { get; set; }

        /// <summary>
        /// 1
        /// </summary>
        [JsonPropertyName("c")]
        public string C { get; set; }
    }
}
