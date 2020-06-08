using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayBossFncUserinvoiceinfoQueryResponse.
    /// </summary>
    public class AlipayBossFncUserinvoiceinfoQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 查询返回结果：开票资料
        /// </summary>
        [JsonPropertyName("result_set")]
        public UserInvoiceInfoOpenApiResponse ResultSet { get; set; }
    }
}
