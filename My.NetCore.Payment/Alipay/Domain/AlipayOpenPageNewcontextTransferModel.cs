﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenPageNewcontextTransferModel Data Structure.
    /// </summary>
    public class AlipayOpenPageNewcontextTransferModel : AlipayObject
    {
        /// <summary>
        /// 参数1
        /// </summary>
        [JsonPropertyName("param_one")]
        public string ParamOne { get; set; }

        /// <summary>
        /// 参数3
        /// </summary>
        [JsonPropertyName("param_three")]
        public string ParamThree { get; set; }

        /// <summary>
        /// 参数2
        /// </summary>
        [JsonPropertyName("param_two")]
        public string ParamTwo { get; set; }
    }
}
