﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipaySamsungEbppRechargeResponse.
    /// </summary>
    public class AlipaySamsungEbppRechargeResponse : AlipayResponse
    {
        /// <summary>
        /// 直接返回页面
        /// </summary>
        [JsonPropertyName("page_retrun")]
        public string PageRetrun { get; set; }
    }
}
