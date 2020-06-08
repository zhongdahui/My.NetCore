using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingCampaignItemQueryResponse.
    /// </summary>
    public class KoubeiMarketingCampaignItemQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 商品详情，包含门店信息
        /// </summary>
        [JsonPropertyName("item")]
        public PromoItemInfo Item { get; set; }
    }
}
