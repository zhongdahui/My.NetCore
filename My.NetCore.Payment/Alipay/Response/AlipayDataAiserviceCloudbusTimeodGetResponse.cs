using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusTimeodGetResponse.
    /// </summary>
    public class AlipayDataAiserviceCloudbusTimeodGetResponse : AlipayResponse
    {
        /// <summary>
        /// od分时结果列表
        /// </summary>
        [JsonPropertyName("result")]
        public List<CloudbusTimeOdItem> Result { get; set; }
    }
}
