﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayMarketingCardBenefitDeleteModel Data Structure.
    /// </summary>
    public class AlipayMarketingCardBenefitDeleteModel : AlipayObject
    {
        /// <summary>
        /// 权益ID
        /// </summary>
        [JsonPropertyName("benefit_id")]
        public string BenefitId { get; set; }

        /// <summary>
        /// 会员卡模板ID
        /// </summary>
        [JsonPropertyName("template_id")]
        public string TemplateId { get; set; }
    }
}
