using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayBossContractManagementQueryResponse.
    /// </summary>
    public class AlipayBossContractManagementQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 查询结果
        /// </summary>
        [JsonPropertyName("result_set")]
        public ContractBatchInfoOpenApiResult ResultSet { get; set; }
    }
}
