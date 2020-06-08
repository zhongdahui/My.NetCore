﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiServindustryReservationPayshopIdentifyResponse.
    /// </summary>
    public class KoubeiServindustryReservationPayshopIdentifyResponse : AlipayResponse
    {
        /// <summary>
        /// 是否付费店铺
        /// </summary>
        [JsonPropertyName("pay_shop")]
        public bool PayShop { get; set; }
    }
}
