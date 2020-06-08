﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiMarketingDataCustomreportDeleteModel Data Structure.
    /// </summary>
    public class KoubeiMarketingDataCustomreportDeleteModel : AlipayObject
    {
        /// <summary>
        /// 自定义报表规则的KEY
        /// </summary>
        [JsonPropertyName("condition_key")]
        public string ConditionKey { get; set; }
    }
}
