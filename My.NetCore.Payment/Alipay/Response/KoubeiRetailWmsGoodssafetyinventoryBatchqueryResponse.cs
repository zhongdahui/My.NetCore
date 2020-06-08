﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiRetailWmsGoodssafetyinventoryBatchqueryResponse.
    /// </summary>
    public class KoubeiRetailWmsGoodssafetyinventoryBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 货品安全库存列表
        /// </summary>
        [JsonPropertyName("goods_safety_inventory_vo_list")]
        public List<GoodsSafetyInventoryVO> GoodsSafetyInventoryVoList { get; set; }
    }
}
