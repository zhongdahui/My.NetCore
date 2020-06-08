using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingDataShopCategoryGetResponse.
    /// </summary>
    public class KoubeiMarketingDataShopCategoryGetResponse : AlipayResponse
    {
        /// <summary>
        /// 指定数量的店铺分类信息
        /// </summary>
        [JsonPropertyName("category_list")]
        public List<Category> CategoryList { get; set; }

        /// <summary>
        /// 剩余的店铺分类
        /// </summary>
        [JsonPropertyName("other")]
        public Category Other { get; set; }
    }
}
