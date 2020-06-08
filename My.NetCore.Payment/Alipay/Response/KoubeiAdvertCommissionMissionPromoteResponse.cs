using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiAdvertCommissionMissionPromoteResponse.
    /// </summary>
    public class KoubeiAdvertCommissionMissionPromoteResponse : AlipayResponse
    {
        /// <summary>
        /// 广告详情
        /// </summary>
        [JsonPropertyName("advert")]
        public KbAdvertAdvResponse Advert { get; set; }

        /// <summary>
        /// true:可以二级分佣配置  false:不可以
        /// </summary>
        [JsonPropertyName("can_cascade_mission")]
        public string CanCascadeMission { get; set; }
    }
}
