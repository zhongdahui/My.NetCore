using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenPublicPersonalizedMenuDeleteModel Data Structure.
    /// </summary>
    public class AlipayOpenPublicPersonalizedMenuDeleteModel : AlipayObject
    {
        /// <summary>
        /// 要删除的个性化菜单key
        /// </summary>
        [JsonPropertyName("menu_key")]
        public string MenuKey { get; set; }
    }
}
