using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringDishSyncResponse.
    /// </summary>
    public class KoubeiCateringDishSyncResponse : AlipayResponse
    {
        /// <summary>
        /// 返回的菜品模型
        /// </summary>
        [JsonPropertyName("kb_dish_info")]
        public KbdishInfo KbDishInfo { get; set; }
    }
}
