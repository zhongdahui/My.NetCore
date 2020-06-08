﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceTransportAdStocktaskBatchqueryResponse.
    /// </summary>
    public class AlipayCommerceTransportAdStocktaskBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 库存查询任务
        /// </summary>
        [JsonPropertyName("stock_task")]
        public List<StockTask> StockTask { get; set; }
    }
}
