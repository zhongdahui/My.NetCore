﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniInnerbaseinfoPrecreateResponse.
    /// </summary>
    public class AlipayOpenMiniInnerbaseinfoPrecreateResponse : AlipayResponse
    {
        /// <summary>
        /// 小程序ID
        /// </summary>
        [JsonPropertyName("mini_app_id")]
        public string MiniAppId { get; set; }
    }
}
