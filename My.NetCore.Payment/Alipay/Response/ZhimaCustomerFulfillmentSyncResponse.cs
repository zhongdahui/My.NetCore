using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// ZhimaCustomerFulfillmentSyncResponse.
    /// </summary>
    public class ZhimaCustomerFulfillmentSyncResponse : AlipayResponse
    {
        /// <summary>
        /// 合约号
        /// </summary>
        [JsonPropertyName("contract_nos")]
        public List<string> ContractNos { get; set; }
    }
}
