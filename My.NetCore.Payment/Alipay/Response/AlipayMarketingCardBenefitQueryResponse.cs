﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCardBenefitQueryResponse.
    /// </summary>
    public class AlipayMarketingCardBenefitQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 会员卡模板外部权益列表
        /// </summary>
        [JsonPropertyName("mcard_template_benefit_query")]
        public List<McardTemplateBenefitQuery> McardTemplateBenefitQuery { get; set; }
    }
}
