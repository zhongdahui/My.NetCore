﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingCampaignUserAssetQueryResponse.
    /// </summary>
    public class KoubeiMarketingCampaignUserAssetQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 券资产详情信息
        /// </summary>
        [JsonPropertyName("voucher_asset_list")]
        public List<VoucherDetailInfo> VoucherAssetList { get; set; }

        /// <summary>
        /// 券资产数量
        /// </summary>
        [JsonPropertyName("voucher_asset_num")]
        public long VoucherAssetNum { get; set; }
    }
}
