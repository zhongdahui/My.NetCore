using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusHistorygeoQueryResponse.
    /// </summary>
    public class AlipayDataAiserviceCloudbusHistorygeoQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 地图问题geo hash码
        /// </summary>
        [JsonPropertyName("result")]
        public List<string> Result { get; set; }
    }
}
