using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusOdGetResponse.
    /// </summary>
    public class AlipayDataAiserviceCloudbusOdGetResponse : AlipayResponse
    {
        /// <summary>
        /// od结果
        /// </summary>
        [JsonPropertyName("result")]
        public List<CloudBusOdItem> Result { get; set; }
    }
}
