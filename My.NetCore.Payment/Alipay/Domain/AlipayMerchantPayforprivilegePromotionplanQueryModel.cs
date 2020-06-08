﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayMerchantPayforprivilegePromotionplanQueryModel Data Structure.
    /// </summary>
    public class AlipayMerchantPayforprivilegePromotionplanQueryModel : AlipayObject
    {
        /// <summary>
        /// 充享惠方案ID
        /// </summary>
        [JsonPropertyName("promotion_plan_id")]
        public string PromotionPlanId { get; set; }
    }
}
