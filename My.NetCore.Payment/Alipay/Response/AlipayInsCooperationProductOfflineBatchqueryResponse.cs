using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayInsCooperationProductOfflineBatchqueryResponse.
    /// </summary>
    public class AlipayInsCooperationProductOfflineBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 返回给机构的线下产品信息列表
        /// </summary>
        [JsonPropertyName("product_list")]
        public List<InsOffilneProduct> ProductList { get; set; }
    }
}
