﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOverseasTransferCertifyResponse.
    /// </summary>
    public class AlipayOverseasTransferCertifyResponse : AlipayResponse
    {
        /// <summary>
        /// 透传信息
        /// </summary>
        [JsonPropertyName("pass_through_info")]
        public string PassThroughInfo { get; set; }
    }
}
