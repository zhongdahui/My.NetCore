using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringDishRecommendQueryResponse.
    /// </summary>
    public class KoubeiCateringDishRecommendQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 推荐菜品列表
        /// </summary>
        [JsonPropertyName("dish_list")]
        public List<DishRecommend> DishList { get; set; }
    }
}
