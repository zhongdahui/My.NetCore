﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCampaignActivityOfflineTriggerResponse.
    /// </summary>
    public class AlipayMarketingCampaignActivityOfflineTriggerResponse : AlipayResponse
    {
        /// <summary>
        /// 外部奖品ID
        /// </summary>
        [JsonPropertyName("out_prize_id")]
        public string OutPrizeId { get; set; }
    }
}
