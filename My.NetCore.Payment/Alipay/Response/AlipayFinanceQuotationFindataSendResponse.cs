﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayFinanceQuotationFindataSendResponse.
    /// </summary>
    public class AlipayFinanceQuotationFindataSendResponse : AlipayResponse
    {
        /// <summary>
        /// 是否投递成功
        /// </summary>
        [JsonPropertyName("send_result")]
        public bool SendResult { get; set; }
    }
}
