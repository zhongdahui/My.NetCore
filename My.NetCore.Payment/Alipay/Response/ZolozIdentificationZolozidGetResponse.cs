﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// ZolozIdentificationZolozidGetResponse.
    /// </summary>
    public class ZolozIdentificationZolozidGetResponse : AlipayResponse
    {
        /// <summary>
        /// zcif结果
        /// </summary>
        [JsonPropertyName("result_info")]
        public string ResultInfo { get; set; }
    }
}
