﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayBossBaseProcessInstanceQueryModel Data Structure.
    /// </summary>
    public class AlipayBossBaseProcessInstanceQueryModel : AlipayObject
    {
        /// <summary>
        /// 流程全局唯一ID
        /// </summary>
        [JsonPropertyName("puid")]
        public string Puid { get; set; }
    }
}
