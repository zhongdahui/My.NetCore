using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AntMerchantExpandDeliveryProcessSyncModel Data Structure.
    /// </summary>
    public class AntMerchantExpandDeliveryProcessSyncModel : AlipayObject
    {
        /// <summary>
        /// 发货计划反馈信息
        /// </summary>
        [JsonPropertyName("asset_delivery_process_info")]
        public AssetDeliveryProcessInfo AssetDeliveryProcessInfo { get; set; }
    }
}
