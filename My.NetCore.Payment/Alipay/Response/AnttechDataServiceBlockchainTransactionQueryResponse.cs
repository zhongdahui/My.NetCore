using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AnttechDataServiceBlockchainTransactionQueryResponse.
    /// </summary>
    public class AnttechDataServiceBlockchainTransactionQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 交易列表
        /// </summary>
        [JsonPropertyName("transaction_list")]
        public List<BlockChainTransactionApiDO> TransactionList { get; set; }
    }
}
