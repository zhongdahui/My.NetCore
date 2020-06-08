﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiCateringDishRuleModifyModel Data Structure.
    /// </summary>
    public class KoubeiCateringDishRuleModifyModel : AlipayObject
    {
        /// <summary>
        /// 菜品规则通用模型
        /// </summary>
        [JsonPropertyName("kb_dish_rule_info")]
        public KbdishRuleInfo KbDishRuleInfo { get; set; }
    }
}
