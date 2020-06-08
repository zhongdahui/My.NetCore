using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipaySecurityProdAfsrcWhitehatinfoQueryResponse.
    /// </summary>
    public class AlipaySecurityProdAfsrcWhitehatinfoQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 白帽子信息
        /// </summary>
        [JsonPropertyName("data")]
        public WhitehatInfo Data { get; set; }
    }
}
