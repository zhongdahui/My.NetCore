using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringPosDishBatchqueryResponse.
    /// </summary>
    public class KoubeiCateringPosDishBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 菜谱中的菜品的列表
        /// </summary>
        [JsonPropertyName("cook_dish")]
        public PosCookDishQryModel CookDish { get; set; }
    }
}
