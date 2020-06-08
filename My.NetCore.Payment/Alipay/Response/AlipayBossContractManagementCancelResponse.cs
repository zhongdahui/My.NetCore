﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayBossContractManagementCancelResponse.
    /// </summary>
    public class AlipayBossContractManagementCancelResponse : AlipayResponse
    {
        /// <summary>
        /// 撤销操作提示
        /// </summary>
        [JsonPropertyName("result_set")]
        public string ResultSet { get; set; }
    }
}
