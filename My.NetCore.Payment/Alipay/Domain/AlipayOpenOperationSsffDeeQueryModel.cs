﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenOperationSsffDeeQueryModel Data Structure.
    /// </summary>
    public class AlipayOpenOperationSsffDeeQueryModel : AlipayObject
    {
        /// <summary>
        /// 1
        /// </summary>
        [JsonPropertyName("df")]
        public string Df { get; set; }
    }
}
