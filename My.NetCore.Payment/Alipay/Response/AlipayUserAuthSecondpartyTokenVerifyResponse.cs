using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayUserAuthSecondpartyTokenVerifyResponse.
    /// </summary>
    public class AlipayUserAuthSecondpartyTokenVerifyResponse : AlipayResponse
    {
        /// <summary>
        /// 淘宝用户id
        /// </summary>
        [JsonPropertyName("tb_user_id")]
        public string TbUserId { get; set; }
    }
}
