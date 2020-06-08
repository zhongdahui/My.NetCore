using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusMetrodetailQueryResponse.
    /// </summary>
    public class AlipayDataAiserviceCloudbusMetrodetailQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 结果
        /// </summary>
        [JsonPropertyName("result")]
        public MetroOdDetailResult Result { get; set; }
    }
}
