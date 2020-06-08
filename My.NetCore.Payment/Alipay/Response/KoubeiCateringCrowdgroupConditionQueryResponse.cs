using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringCrowdgroupConditionQueryResponse.
    /// </summary>
    public class KoubeiCateringCrowdgroupConditionQueryResponse : AlipayResponse
    {
        /// <summary>
        /// isv创建的用户规则分组描述
        /// </summary>
        [JsonPropertyName("condition_list")]
        public List<UserCrowdConditions> ConditionList { get; set; }
    }
}
