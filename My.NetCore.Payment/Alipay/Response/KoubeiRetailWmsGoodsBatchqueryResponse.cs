﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiRetailWmsGoodsBatchqueryResponse.
    /// </summary>
    public class KoubeiRetailWmsGoodsBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 货品信息
        /// </summary>
        [JsonPropertyName("goods")]
        public List<GoodsVO> Goods { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>
        [JsonPropertyName("total_count")]
        public string TotalCount { get; set; }
    }
}
