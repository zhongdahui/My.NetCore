using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEbppProductSearchResponse.
    /// </summary>
    public class AlipayEbppProductSearchResponse : AlipayResponse
    {
        /// <summary>
        /// 产品(学校)模型列表
        /// </summary>
        [JsonPropertyName("exproductconfs")]
        public List<ExproductconfResponse> Exproductconfs { get; set; }
    }
}
