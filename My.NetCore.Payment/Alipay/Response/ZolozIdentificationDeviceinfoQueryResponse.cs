using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// ZolozIdentificationDeviceinfoQueryResponse.
    /// </summary>
    public class ZolozIdentificationDeviceinfoQueryResponse : AlipayResponse
    {
        /// <summary>
        /// device_info
        /// </summary>
        [JsonPropertyName("device_info")]
        public ZolozDeviceInfo DeviceInfo { get; set; }
    }
}
