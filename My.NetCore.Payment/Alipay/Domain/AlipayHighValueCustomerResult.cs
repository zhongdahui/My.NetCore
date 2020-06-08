﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayHighValueCustomerResult Data Structure.
    /// </summary>
    public class AlipayHighValueCustomerResult : AlipayObject
    {
        /// <summary>
        /// Z0-Z7
        /// </summary>
        [JsonPropertyName("level")]
        public string Level { get; set; }
    }
}
