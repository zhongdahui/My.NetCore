using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// CloudUserInfo Data Structure.
    /// </summary>
    public class CloudUserInfo : AlipayObject
    {
        /// <summary>
        /// 口碑主账号ID
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }

        /// <summary>
        /// 口碑主账号名称
        /// </summary>
        [JsonPropertyName("user_name")]
        public string UserName { get; set; }
    }
}
