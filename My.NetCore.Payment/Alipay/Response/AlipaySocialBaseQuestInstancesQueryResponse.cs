using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipaySocialBaseQuestInstancesQueryResponse.
    /// </summary>
    public class AlipaySocialBaseQuestInstancesQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 用户实例的查询结果集
        /// </summary>
        [JsonPropertyName("instances")]
        public List<QuestInstanceDTO> Instances { get; set; }
    }
}
