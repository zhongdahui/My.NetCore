using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// BFActivityOpenApiResult Data Structure.
    /// </summary>
    public class BFActivityOpenApiResult : AlipayObject
    {
        /// <summary>
        /// 活动信息
        /// </summary>
        [JsonPropertyName("activity_infos")]
        public List<BFActivityOpenApiInfo> ActivityInfos { get; set; }
    }
}
