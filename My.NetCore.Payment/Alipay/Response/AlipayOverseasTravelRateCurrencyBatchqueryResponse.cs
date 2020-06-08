using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOverseasTravelRateCurrencyBatchqueryResponse.
    /// </summary>
    public class AlipayOverseasTravelRateCurrencyBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 汇率币种列表
        /// </summary>
        [JsonPropertyName("currency_list")]
        public List<RateCurrency> CurrencyList { get; set; }
    }
}
