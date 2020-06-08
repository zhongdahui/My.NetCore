using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayCommerceTransportAdUserCreateModel Data Structure.
    /// </summary>
    public class AlipayCommerceTransportAdUserCreateModel : AlipayObject
    {
        /// <summary>
        /// 广告主用户信息，参见文档
        /// </summary>
        [JsonPropertyName("ad_user")]
        public AdUser AdUser { get; set; }
    }
}
