using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringDishConditionBatchqueryResponse.
    /// </summary>
    public class KoubeiCateringDishConditionBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 菜品分页信息
        /// </summary>
        [JsonPropertyName("kb_dish_page_info")]
        public PaginationDish KbDishPageInfo { get; set; }
    }
}
