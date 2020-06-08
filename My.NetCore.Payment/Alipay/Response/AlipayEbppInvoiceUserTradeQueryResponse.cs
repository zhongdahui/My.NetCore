using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEbppInvoiceUserTradeQueryResponse.
    /// </summary>
    public class AlipayEbppInvoiceUserTradeQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 发票管家发票交易信息
        /// </summary>
        [JsonPropertyName("trade_info")]
        public InvoiceTradeInfo TradeInfo { get; set; }
    }
}
