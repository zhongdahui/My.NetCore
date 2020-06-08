using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusTotalodQueryResponse.
    /// </summary>
    public class AlipayDataAiserviceCloudbusTotalodQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 客流总量结果
        /// </summary>
        [JsonPropertyName("result")]
        public CloudbusTotalOdItem Result { get; set; }
    }
}
