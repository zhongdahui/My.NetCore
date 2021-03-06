﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayGotoneMessageMailSendResponse.
    /// </summary>
    public class AlipayGotoneMessageMailSendResponse : AlipayResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonPropertyName("result_code")]
        public string ResultCode { get; set; }
    }
}
