﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayInsSceneSellerDataQueryResponse.
    /// </summary>
    public class AlipayInsSceneSellerDataQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 返回数据结果
        /// </summary>
        [JsonPropertyName("data")]
        public string Data { get; set; }
    }
}
