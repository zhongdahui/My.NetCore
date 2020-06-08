using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceCityfacilitatorFunctionQueryResponse.
    /// </summary>
    public class AlipayCommerceCityfacilitatorFunctionQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 支持的功能列表
        /// </summary>
        [JsonPropertyName("functions")]
        public List<SupportFunction> Functions { get; set; }
    }
}
