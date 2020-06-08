using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayInsSceneProductAgreementCancelResponse.
    /// </summary>
    public class AlipayInsSceneProductAgreementCancelResponse : AlipayResponse
    {
        /// <summary>
        /// 返回成功或者失败
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
