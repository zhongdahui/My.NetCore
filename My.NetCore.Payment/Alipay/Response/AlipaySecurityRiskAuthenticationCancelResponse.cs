﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipaySecurityRiskAuthenticationCancelResponse.
    /// </summary>
    public class AlipaySecurityRiskAuthenticationCancelResponse : AlipayResponse
    {
        /// <summary>
        /// 返回取消结果
        /// </summary>
        [JsonPropertyName("biz_result")]
        public string BizResult { get; set; }
    }
}
