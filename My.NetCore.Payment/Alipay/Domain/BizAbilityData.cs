using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// BizAbilityData Data Structure.
    /// </summary>
    public class BizAbilityData : AlipayObject
    {
        /// <summary>
        /// 业务能力数据json值
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }

        /// <summary>
        /// 数据key
        /// </summary>
        [JsonPropertyName("key")]
        public string Key { get; set; }
    }
}
