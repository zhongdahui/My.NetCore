using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// UserIdentityInfo Data Structure.
    /// </summary>
    public class UserIdentityInfo : AlipayObject
    {
        /// <summary>
        /// 校园码身份信息
        /// </summary>
        [JsonPropertyName("h_school_info")]
        public HSchoolInfo HSchoolInfo { get; set; }
    }
}
