using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiRetailWmsCategoryQueryModel Data Structure.
    /// </summary>
    public class KoubeiRetailWmsCategoryQueryModel : AlipayObject
    {
        /// <summary>
        /// 根据类目ID查询
        /// </summary>
        [JsonPropertyName("category_id")]
        public string CategoryId { get; set; }

        /// <summary>
        /// 操作上下文
        /// </summary>
        [JsonPropertyName("operate_context")]
        public OperateContext OperateContext { get; set; }
    }
}
