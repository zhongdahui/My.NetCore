using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingToolFengdieSitesQueryResponse.
    /// </summary>
    public class AlipayMarketingToolFengdieSitesQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 站点查询返回值
        /// </summary>
        [JsonPropertyName("data")]
        public FengdieSitesQueryRespModel Data { get; set; }
    }
}
