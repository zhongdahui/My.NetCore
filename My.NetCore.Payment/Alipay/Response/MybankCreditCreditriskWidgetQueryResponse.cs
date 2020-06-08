﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// MybankCreditCreditriskWidgetQueryResponse.
    /// </summary>
    public class MybankCreditCreditriskWidgetQueryResponse : AlipayResponse
    {
        /// <summary>
        /// widget json数据
        /// </summary>
        [JsonPropertyName("widgetjson")]
        public string Widgetjson { get; set; }
    }
}
