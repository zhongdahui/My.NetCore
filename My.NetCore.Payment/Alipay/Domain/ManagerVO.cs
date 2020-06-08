using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// ManagerVO Data Structure.
    /// </summary>
    public class ManagerVO : AlipayObject
    {
        /// <summary>
        /// 管理人员名称
        /// </summary>
        [JsonPropertyName("manager_name")]
        public string ManagerName { get; set; }

        /// <summary>
        /// 职务
        /// </summary>
        [JsonPropertyName("manager_position")]
        public string ManagerPosition { get; set; }
    }
}
