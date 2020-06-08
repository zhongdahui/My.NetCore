﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayTradeRepaybillCreateResponse.
    /// </summary>
    public class AlipayTradeRepaybillCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 支付宝账单编号
        /// </summary>
        [JsonPropertyName("bill_no")]
        public string BillNo { get; set; }
    }
}
