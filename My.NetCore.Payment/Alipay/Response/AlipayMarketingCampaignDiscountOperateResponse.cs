﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCampaignDiscountOperateResponse.
    /// </summary>
    public class AlipayMarketingCampaignDiscountOperateResponse : AlipayResponse
    {
        /// <summary>
        /// 123
        /// </summary>
        [JsonPropertyName("camp_id")]
        public string CampId { get; set; }
    }
}
