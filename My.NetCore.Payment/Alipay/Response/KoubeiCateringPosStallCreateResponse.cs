﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringPosStallCreateResponse.
    /// </summary>
    public class KoubeiCateringPosStallCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 档口id
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
