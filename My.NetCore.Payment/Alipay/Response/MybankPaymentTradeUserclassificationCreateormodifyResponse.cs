using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// MybankPaymentTradeUserclassificationCreateormodifyResponse.
    /// </summary>
    public class MybankPaymentTradeUserclassificationCreateormodifyResponse : AlipayResponse
    {
        /// <summary>
        /// 打标结果
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
