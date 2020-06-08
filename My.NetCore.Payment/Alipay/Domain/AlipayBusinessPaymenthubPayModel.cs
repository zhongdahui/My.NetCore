﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayBusinessPaymenthubPayModel Data Structure.
    /// </summary>
    public class AlipayBusinessPaymenthubPayModel : AlipayObject
    {
        /// <summary>
        /// 聚合支付的支付渠道，支付宝分配。
        /// </summary>
        [JsonPropertyName("channel")]
        public string Channel { get; set; }

        /// <summary>
        /// 商品详情
        /// </summary>
        [JsonPropertyName("goods_infos")]
        public List<GoodsDetailInfo> GoodsInfos { get; set; }

        /// <summary>
        /// 是否异步支付，true/false，不传默认为false。
        /// </summary>
        [JsonPropertyName("is_async_pay")]
        public bool IsAsyncPay { get; set; }

        /// <summary>
        /// 商户订单号，merchant_order_no唯一对应业务上一笔订单，相同的订单需传入相同的merchant_order_no
        /// </summary>
        [JsonPropertyName("merchant_order_no")]
        public string MerchantOrderNo { get; set; }

        /// <summary>
        /// 订单总金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]
        /// </summary>
        [JsonPropertyName("order_amount")]
        public string OrderAmount { get; set; }

        /// <summary>
        /// 支付金额，单位为元，精确到小数点后两位，取值范围[0.01,100000000]
        /// </summary>
        [JsonPropertyName("pay_amount")]
        public string PayAmount { get; set; }

        /// <summary>
        /// 支付模式，支付宝分配，目前只支持GUARANTEE_PAY(担保支付模式)
        /// </summary>
        [JsonPropertyName("pay_mode")]
        public string PayMode { get; set; }

        /// <summary>
        /// 支付请求号，对应一笔业务订单下的一次支付请求，不同支付请求需保证请求号唯一
        /// </summary>
        [JsonPropertyName("pay_request_no")]
        public string PayRequestNo { get; set; }

        /// <summary>
        /// 支付终端，指支付来源的设备端，支付宝分配，目前支持PC/APP
        /// </summary>
        [JsonPropertyName("pay_terminal")]
        public string PayTerminal { get; set; }

        /// <summary>
        /// 收款方信息
        /// </summary>
        [JsonPropertyName("payee")]
        public UserIdentity Payee { get; set; }

        /// <summary>
        /// 收款方的额外信息，包含会员信息和支付机构账号信息
        /// </summary>
        [JsonPropertyName("payee_ext")]
        public UserIdentityExt PayeeExt { get; set; }

        /// <summary>
        /// 付款方信息
        /// </summary>
        [JsonPropertyName("payer")]
        public UserIdentity Payer { get; set; }

        /// <summary>
        /// 付款方的额外信息，包含会员信息和支付机构账号信息
        /// </summary>
        [JsonPropertyName("payer_ext")]
        public UserIdentityExt PayerExt { get; set; }

        /// <summary>
        /// 支付说明
        /// </summary>
        [JsonPropertyName("remark")]
        public string Remark { get; set; }
    }
}
