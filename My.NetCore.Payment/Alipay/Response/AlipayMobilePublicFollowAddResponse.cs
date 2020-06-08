using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMobilePublicFollowAddResponse.
    /// </summary>
    public class AlipayMobilePublicFollowAddResponse : AlipayResponse
    {
        /// <summary>
        /// 成功与否的标志
        /// </summary>
        [JsonPropertyName("code")]
        public override string Code { get; set; }
    }
}
