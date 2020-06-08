using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayUserAccountGetResponse.
    /// </summary>
    public class AlipayUserAccountGetResponse : AlipayResponse
    {
        /// <summary>
        /// 支付宝用户账户信息
        /// </summary>
        [JsonPropertyName("alipay_account")]
        public AlipayAccount AlipayAccount { get; set; }
    }
}
