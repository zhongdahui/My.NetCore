using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataServiceOpenAnalyzeResponse.
    /// </summary>
    public class AlipayDataServiceOpenAnalyzeResponse : AlipayResponse
    {
        /// <summary>
        /// 调用返回
        /// </summary>
        [JsonPropertyName("result")]
        public AlipayDataServiceResult Result { get; set; }
    }
}
