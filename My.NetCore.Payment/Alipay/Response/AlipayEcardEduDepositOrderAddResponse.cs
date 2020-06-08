using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEcardEduDepositOrderAddResponse.
    /// </summary>
    public class AlipayEcardEduDepositOrderAddResponse : AlipayResponse
    {
        /// <summary>
        /// 支付申请流水号
        /// </summary>
        [JsonPropertyName("order_no")]
        public string OrderNo { get; set; }
    }
}
