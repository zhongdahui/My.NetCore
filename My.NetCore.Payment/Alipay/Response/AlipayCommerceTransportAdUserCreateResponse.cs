using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceTransportAdUserCreateResponse.
    /// </summary>
    public class AlipayCommerceTransportAdUserCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 广告系统用户ID
        /// </summary>
        [JsonPropertyName("ad_user_id")]
        public string AdUserId { get; set; }
    }
}
