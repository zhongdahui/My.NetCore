using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMerchantOperatorFreezeResponse.
    /// </summary>
    public class KoubeiMerchantOperatorFreezeResponse : AlipayResponse
    {
        /// <summary>
        /// 操作结果 true:success, false: failed
        /// </summary>
        [JsonPropertyName("result")]
        public bool Result { get; set; }
    }
}
