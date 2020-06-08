using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiservicePriceoptimizerGetResponse.
    /// </summary>
    public class AlipayDataAiservicePriceoptimizerGetResponse : AlipayResponse
    {
        /// <summary>
        /// 推荐价格返回列表
        /// </summary>
        [JsonPropertyName("result")]
        public List<MakePriceResult> Result { get; set; }
    }
}
