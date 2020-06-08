using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// ZhimaMerchantContractOfferQueryModel Data Structure.
    /// </summary>
    public class ZhimaMerchantContractOfferQueryModel : AlipayObject
    {
        /// <summary>
        /// 发约单单号
        /// </summary>
        [JsonPropertyName("offer_no")]
        public string OfferNo { get; set; }
    }
}
