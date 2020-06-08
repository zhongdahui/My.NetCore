using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMallScanpurchasePreorderQueryResponse.
    /// </summary>
    public class KoubeiMallScanpurchasePreorderQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 预订单信息
        /// </summary>
        [JsonPropertyName("advance_order")]
        public AdvanceOrder AdvanceOrder { get; set; }
    }
}
