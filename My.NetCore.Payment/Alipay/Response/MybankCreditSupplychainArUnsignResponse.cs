﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// MybankCreditSupplychainArUnsignResponse.
    /// </summary>
    public class MybankCreditSupplychainArUnsignResponse : AlipayResponse
    {
        /// <summary>
        /// 解约结果：true/false
        /// </summary>
        [JsonPropertyName("invalid_result")]
        public bool InvalidResult { get; set; }
    }
}
