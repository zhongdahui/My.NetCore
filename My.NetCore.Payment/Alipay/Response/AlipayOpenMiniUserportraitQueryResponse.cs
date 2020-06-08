using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniUserportraitQueryResponse.
    /// </summary>
    public class AlipayOpenMiniUserportraitQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 用户画像
        /// </summary>
        [JsonPropertyName("portrait_distributions")]
        public List<PortraitDistribution> PortraitDistributions { get; set; }
    }
}
