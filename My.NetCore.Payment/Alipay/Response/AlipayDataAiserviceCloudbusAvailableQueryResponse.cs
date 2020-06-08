﻿using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusAvailableQueryResponse.
    /// </summary>
    public class AlipayDataAiserviceCloudbusAvailableQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 城市可用时间和用户geohash可用额度
        /// </summary>
        [JsonPropertyName("result")]
        public CloudbusAvaliableItem Result { get; set; }
    }
}
