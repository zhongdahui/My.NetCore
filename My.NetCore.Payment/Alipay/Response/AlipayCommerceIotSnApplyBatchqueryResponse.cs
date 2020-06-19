﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceIotSnApplyBatchqueryResponse.
    /// </summary>
    public class AlipayCommerceIotSnApplyBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 申请单列表
        /// </summary>
        [JsonPropertyName("apply_list")]
        public List<SnApplyInfo> ApplyList { get; set; }

        /// <summary>
        /// 历史sn生成成功的操作总数
        /// </summary>
        [JsonPropertyName("total")]
        public long Total { get; set; }
    }
}