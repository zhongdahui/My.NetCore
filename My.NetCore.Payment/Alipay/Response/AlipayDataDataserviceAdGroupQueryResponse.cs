using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataDataserviceAdGroupQueryResponse.
    /// </summary>
    public class AlipayDataDataserviceAdGroupQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 单元详情
        /// </summary>
        [JsonPropertyName("group_detail")]
        public OuterGroup GroupDetail { get; set; }
    }
}
