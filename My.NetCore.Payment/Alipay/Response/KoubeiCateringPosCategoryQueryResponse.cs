using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringPosCategoryQueryResponse.
    /// </summary>
    public class KoubeiCateringPosCategoryQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 菜类信息
        /// </summary>
        [JsonPropertyName("dish_category_entity")]
        public DishCategoryEntity DishCategoryEntity { get; set; }
    }
}
