using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AntfortuneEquityInstpointTransQueryResponse.
    /// </summary>
    public class AntfortuneEquityInstpointTransQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 查询到的结果
        /// </summary>
        [JsonPropertyName("trans_info")]
        public List<PointTransInfo> TransInfo { get; set; }
    }
}
