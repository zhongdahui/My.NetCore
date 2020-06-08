using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringPosQrcodeSyncResponse.
    /// </summary>
    public class KoubeiCateringPosQrcodeSyncResponse : AlipayResponse
    {
        /// <summary>
        /// 桌台ID
        /// </summary>
        [JsonPropertyName("desk_ids")]
        public List<string> DeskIds { get; set; }
    }
}
