using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// MybankPaymentTradeNormalpayOrderQueryModel Data Structure.
    /// </summary>
    public class MybankPaymentTradeNormalpayOrderQueryModel : AlipayObject
    {
        /// <summary>
        /// 创建订单时返回的订单号
        /// </summary>
        [JsonPropertyName("order_no")]
        public string OrderNo { get; set; }
    }
}
