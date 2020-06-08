using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingDataDishdiagnosetypeBatchqueryResponse.
    /// </summary>
    public class KoubeiMarketingDataDishdiagnosetypeBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 菜品类型list
        /// </summary>
        [JsonPropertyName("item_diagnose_type_list")]
        public List<ItemDiagnoseType> ItemDiagnoseTypeList { get; set; }
    }
}
