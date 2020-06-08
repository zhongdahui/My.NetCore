using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataIotdataBusinessPointQueryResponse.
    /// </summary>
    public class AlipayDataIotdataBusinessPointQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 业务点位信息列表
        /// </summary>
        [JsonPropertyName("data")]
        public List<BusinessPoint> Data { get; set; }
    }
}
