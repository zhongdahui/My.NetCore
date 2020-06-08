using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// CreditPayRefuseVO Data Structure.
    /// </summary>
    public class CreditPayRefuseVO : AlipayObject
    {
        /// <summary>
        /// 拒绝码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 拒绝详情
        /// </summary>
        [JsonPropertyName("msg")]
        public string Msg { get; set; }
    }
}
