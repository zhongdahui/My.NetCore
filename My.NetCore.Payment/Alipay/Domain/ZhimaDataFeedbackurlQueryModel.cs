using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// ZhimaDataFeedbackurlQueryModel Data Structure.
    /// </summary>
    public class ZhimaDataFeedbackurlQueryModel : AlipayObject
    {
        /// <summary>
        /// 在支付宝商户版注册支付宝账号id
        /// </summary>
        [JsonPropertyName("merchant_id")]
        public string MerchantId { get; set; }
    }
}
