﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiCateringPosPrintQueryModel Data Structure.
    /// </summary>
    public class KoubeiCateringPosPrintQueryModel : AlipayObject
    {
        /// <summary>
        /// 门店id
        /// </summary>
        [JsonPropertyName("shop_id")]
        public string ShopId { get; set; }
    }
}
