using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringPosStalldetailQueryResponse.
    /// </summary>
    public class KoubeiCateringPosStalldetailQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 档口模型
        /// </summary>
        [JsonPropertyName("stall_entity")]
        public StallEntity StallEntity { get; set; }
    }
}
