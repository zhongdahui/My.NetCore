﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOfflineMarketingVoucherCodeUploadResponse.
    /// </summary>
    public class AlipayOfflineMarketingVoucherCodeUploadResponse : AlipayResponse
    {
        /// <summary>
        /// 码库id
        /// </summary>
        [JsonPropertyName("code_inventory_id")]
        public string CodeInventoryId { get; set; }
    }
}
