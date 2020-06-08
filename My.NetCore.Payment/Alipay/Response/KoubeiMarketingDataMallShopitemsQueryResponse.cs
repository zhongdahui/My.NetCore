﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiMarketingDataMallShopitemsQueryResponse.
    /// </summary>
    public class KoubeiMarketingDataMallShopitemsQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 店铺信息
        /// </summary>
        [JsonPropertyName("shop_list")]
        public List<TBMiniShopBo> ShopList { get; set; }
    }
}
