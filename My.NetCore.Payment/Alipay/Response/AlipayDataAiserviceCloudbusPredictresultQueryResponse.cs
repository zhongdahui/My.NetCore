using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusPredictresultQueryResponse.
    /// </summary>
    public class AlipayDataAiserviceCloudbusPredictresultQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 预测线路结果
        /// </summary>
        [JsonPropertyName("result")]
        public CloudbusPredictResult Result { get; set; }
    }
}
