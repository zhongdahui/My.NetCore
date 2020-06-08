﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceIotMdeviceprodShopCreateResponse.
    /// </summary>
    public class AlipayCommerceIotMdeviceprodShopCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 虚拟门店ID
        /// </summary>
        [JsonPropertyName("shop_id")]
        public string ShopId { get; set; }
    }
}
