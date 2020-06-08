using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenServicemarketOrderAcceptModel Data Structure.
    /// </summary>
    public class AlipayOpenServicemarketOrderAcceptModel : AlipayObject
    {
        /// <summary>
        /// 服务商品订单ID
        /// </summary>
        [JsonPropertyName("commodity_order_id")]
        public string CommodityOrderId { get; set; }
    }
}
