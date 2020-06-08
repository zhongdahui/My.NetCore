using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEcoLogisticsExpressNonserviceQueryResponse.
    /// </summary>
    public class AlipayEcoLogisticsExpressNonserviceQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 非服务区区域代码列表
        /// </summary>
        [JsonPropertyName("area_codes")]
        public List<AreaCode> AreaCodes { get; set; }
    }
}
