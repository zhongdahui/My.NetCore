﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenMiniSafedomainDeleteModel Data Structure.
    /// </summary>
    public class AlipayOpenMiniSafedomainDeleteModel : AlipayObject
    {
        /// <summary>
        /// httpRequest域白名单
        /// </summary>
        [JsonPropertyName("safe_domain")]
        public string SafeDomain { get; set; }
    }
}
