using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiServindustryPortfolioOpusCreateResponse.
    /// </summary>
    public class KoubeiServindustryPortfolioOpusCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 作品列表
        /// </summary>
        [JsonPropertyName("opuses")]
        public OpusCreateResponse Opuses { get; set; }
    }
}
