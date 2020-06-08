using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiAdvertCommissionChannelCreateModel Data Structure.
    /// </summary>
    public class KoubeiAdvertCommissionChannelCreateModel : AlipayObject
    {
        /// <summary>
        /// 新增渠道列表
        /// </summary>
        [JsonPropertyName("channels")]
        public List<KbAdvertAddChannelRequest> Channels { get; set; }
    }
}
