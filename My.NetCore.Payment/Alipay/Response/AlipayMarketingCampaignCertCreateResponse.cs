﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingCampaignCertCreateResponse.
    /// </summary>
    public class AlipayMarketingCampaignCertCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 凭证id
        /// </summary>
        [JsonPropertyName("lot_number")]
        public string LotNumber { get; set; }
    }
}
