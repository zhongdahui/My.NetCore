﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniInnerappServicePublishResponse.
    /// </summary>
    public class AlipayOpenMiniInnerappServicePublishResponse : AlipayResponse
    {
        /// <summary>
        /// 服务ID
        /// </summary>
        [JsonPropertyName("merchandise_id")]
        public string MerchandiseId { get; set; }
    }
}
