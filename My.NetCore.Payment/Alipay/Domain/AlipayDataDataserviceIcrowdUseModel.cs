using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayDataDataserviceIcrowdUseModel Data Structure.
    /// </summary>
    public class AlipayDataDataserviceIcrowdUseModel : AlipayObject
    {
        /// <summary>
        /// icrowd接口请求参数＋唯一不可空
        /// </summary>
        [JsonPropertyName("icrowd_use_param")]
        public IcrowdUseParam IcrowdUseParam { get; set; }
    }
}
