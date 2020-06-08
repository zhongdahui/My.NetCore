using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingCampaignActivityQueryResponse.
    /// </summary>
    public class KoubeiMarketingCampaignActivityQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 活动详情
        /// </summary>
        [JsonPropertyName("camp_detail")]
        public CampDetail CampDetail { get; set; }
    }
}
