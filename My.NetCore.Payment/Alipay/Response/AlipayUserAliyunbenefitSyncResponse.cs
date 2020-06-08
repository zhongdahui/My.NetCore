﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayUserAliyunbenefitSyncResponse.
    /// </summary>
    public class AlipayUserAliyunbenefitSyncResponse : AlipayResponse
    {
        /// <summary>
        /// 权益Id
        /// </summary>
        [JsonPropertyName("benefit_id")]
        public string BenefitId { get; set; }
    }
}
