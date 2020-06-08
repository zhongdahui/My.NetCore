﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOverseasRemitWithdrawNotifyResponse.
    /// </summary>
    public class AlipayOverseasRemitWithdrawNotifyResponse : AlipayResponse
    {
        /// <summary>
        /// JSON map
        /// </summary>
        [JsonPropertyName("pass_through_info")]
        public string PassThroughInfo { get; set; }
    }
}
