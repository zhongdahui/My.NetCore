using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiMerchantKbdeviceDispenserQueryModel Data Structure.
    /// </summary>
    public class KoubeiMerchantKbdeviceDispenserQueryModel : AlipayObject
    {
        /// <summary>
        /// 取餐柜的唯一设备ID
        /// </summary>
        [JsonPropertyName("device_id")]
        public string DeviceId { get; set; }
    }
}
