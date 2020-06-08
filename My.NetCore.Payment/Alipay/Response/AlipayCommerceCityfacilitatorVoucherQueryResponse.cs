﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceCityfacilitatorVoucherQueryResponse.
    /// </summary>
    public class AlipayCommerceCityfacilitatorVoucherQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 订单金额
        /// </summary>
        [JsonPropertyName("amount")]
        public string Amount { get; set; }

        /// <summary>
        /// 终点站
        /// </summary>
        [JsonPropertyName("end_station")]
        public string EndStation { get; set; }

        /// <summary>
        /// 终点站点名称
        /// </summary>
        [JsonPropertyName("end_station_name")]
        public string EndStationName { get; set; }

        /// <summary>
        /// 订单中包含的票数
        /// </summary>
        [JsonPropertyName("quantity")]
        public string Quantity { get; set; }

        /// <summary>
        /// 起点站
        /// </summary>
        [JsonPropertyName("start_station")]
        public string StartStation { get; set; }

        /// <summary>
        /// 起始站点名称
        /// </summary>
        [JsonPropertyName("start_station_name")]
        public string StartStationName { get; set; }

        /// <summary>
        /// 查询的该笔订单当前状态(SUCCESS、TRANSFER、FAIL等)
        /// </summary>
        [JsonPropertyName("status")]
        public string Status { get; set; }

        /// <summary>
        /// 票单价
        /// </summary>
        [JsonPropertyName("ticket_price")]
        public string TicketPrice { get; set; }

        /// <summary>
        /// 描述票种类
        /// </summary>
        [JsonPropertyName("ticket_type")]
        public string TicketType { get; set; }

        /// <summary>
        /// 支付宝交易号
        /// </summary>
        [JsonPropertyName("trade_no")]
        public string TradeNo { get; set; }
    }
}
