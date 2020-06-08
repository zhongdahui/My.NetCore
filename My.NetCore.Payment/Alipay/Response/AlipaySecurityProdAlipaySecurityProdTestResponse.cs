using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipaySecurityProdAlipaySecurityProdTestResponse.
    /// </summary>
    public class AlipaySecurityProdAlipaySecurityProdTestResponse : AlipayResponse
    {
        /// <summary>
        /// ddd
        /// </summary>
        [JsonPropertyName("admin")]
        public string Admin { get; set; }
    }
}
