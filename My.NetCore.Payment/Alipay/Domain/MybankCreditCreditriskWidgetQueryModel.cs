﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// MybankCreditCreditriskWidgetQueryModel Data Structure.
    /// </summary>
    public class MybankCreditCreditriskWidgetQueryModel : AlipayObject
    {
        /// <summary>
        /// 支付宝userid
        /// </summary>
        [JsonPropertyName("alipay_user_id")]
        public string AlipayUserId { get; set; }
    }
}
