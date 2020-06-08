﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingMallShoppromoinfoQueryResponse.
    /// </summary>
    public class KoubeiMarketingMallShoppromoinfoQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 店铺营销信息详情
        /// </summary>
        [JsonPropertyName("shop_promo_infos")]
        public List<ShopPromoInfo> ShopPromoInfos { get; set; }
    }
}
