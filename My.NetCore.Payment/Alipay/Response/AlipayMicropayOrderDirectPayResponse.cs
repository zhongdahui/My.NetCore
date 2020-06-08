using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMicropayOrderDirectPayResponse.
    /// </summary>
    public class AlipayMicropayOrderDirectPayResponse : AlipayResponse
    {
        /// <summary>
        /// 单笔直接支付返回结果
        /// </summary>
        [JsonPropertyName("single_pay_detail")]
        public SinglePayDetail SinglePayDetail { get; set; }
    }
}
