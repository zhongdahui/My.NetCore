﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniMiniappFavoriteextAddResponse.
    /// </summary>
    public class AlipayOpenMiniMiniappFavoriteextAddResponse : AlipayResponse
    {
        /// <summary>
        /// 成功：true  失败：false
        /// </summary>
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
