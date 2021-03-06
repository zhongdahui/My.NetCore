﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// MetroOdDetailResult Data Structure.
    /// </summary>
    public class MetroOdDetailResult : AlipayObject
    {
        /// <summary>
        /// 返回码
        /// </summary>
        [JsonPropertyName("code")]
        public string Code { get; set; }

        /// <summary>
        /// 结果
        /// </summary>
        [JsonPropertyName("data")]
        public MetroOdItem Data { get; set; }

        /// <summary>
        /// 消息描述
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }
    }
}
