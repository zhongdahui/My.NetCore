﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayUserAccountFreezeGetResponse.
    /// </summary>
    public class AlipayUserAccountFreezeGetResponse : AlipayResponse
    {
        /// <summary>
        /// 冻结金额列表
        /// </summary>
        [JsonPropertyName("freeze_items")]
        public List<AccountFreeze> FreezeItems { get; set; }

        /// <summary>
        /// 冻结总条数
        /// </summary>
        [JsonPropertyName("total_results")]
        public string TotalResults { get; set; }
    }
}
