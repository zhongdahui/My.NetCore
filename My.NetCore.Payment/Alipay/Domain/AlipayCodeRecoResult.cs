﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayCodeRecoResult Data Structure.
    /// </summary>
    public class AlipayCodeRecoResult : AlipayObject
    {
        /// <summary>
        /// 识别的验证码内容
        /// </summary>
        [JsonPropertyName("content")]
        public string Content { get; set; }
    }
}
