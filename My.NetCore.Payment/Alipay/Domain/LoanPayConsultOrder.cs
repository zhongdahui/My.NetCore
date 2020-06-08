﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// LoanPayConsultOrder Data Structure.
    /// </summary>
    public class LoanPayConsultOrder : AlipayObject
    {
        /// <summary>
        /// 外部平台订单号，如果传给支付宝收单时带着前缀，此处也需要
        /// </summary>
        [JsonPropertyName("out_order_no")]
        public string OutOrderNo { get; set; }

        /// <summary>
        /// 卖家支付宝账户ID
        /// </summary>
        [JsonPropertyName("seller_user_id")]
        public string SellerUserId { get; set; }
    }
}
