﻿using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayInsMarketingCampaignQueryResponse.
    /// </summary>
    public class AlipayInsMarketingCampaignQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 保险营销活动信息
        /// </summary>
        [JsonPropertyName("mkt_campaign")]
        public InsMktCampaignDTO MktCampaign { get; set; }
    }
}
