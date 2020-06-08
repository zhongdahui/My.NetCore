using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// ZhimaCreditEpSceneFulfillmentSyncResponse.
    /// </summary>
    public class ZhimaCreditEpSceneFulfillmentSyncResponse : AlipayResponse
    {
        /// <summary>
        /// 履约单号
        /// </summary>
        [JsonPropertyName("fulfillment_order_no")]
        public string FulfillmentOrderNo { get; set; }
    }
}
