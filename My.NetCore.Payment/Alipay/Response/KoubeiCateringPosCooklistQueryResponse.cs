using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringPosCooklistQueryResponse.
    /// </summary>
    public class KoubeiCateringPosCooklistQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 菜谱列表
        /// </summary>
        [JsonPropertyName("cook_models")]
        public List<PosDishCookModel> CookModels { get; set; }
    }
}
