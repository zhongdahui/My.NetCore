﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayGotoneMessageSmsSendResponse.
    /// </summary>
    public class AlipayGotoneMessageSmsSendResponse : AlipayResponse
    {
        /// <summary>
        /// 返回结果
        /// </summary>
        [JsonPropertyName("result_code")]
        public string ResultCode { get; set; }
    }
}
