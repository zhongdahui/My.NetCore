using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniTinyappExistQueryResponse.
    /// </summary>
    public class AlipayOpenMiniTinyappExistQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 是否是小程序开发者
        /// </summary>
        [JsonPropertyName("exist_mini")]
        public string ExistMini { get; set; }
    }
}
