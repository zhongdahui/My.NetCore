﻿using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayBossContractManagementIdentifyResponse.
    /// </summary>
    public class AlipayBossContractManagementIdentifyResponse : AlipayResponse
    {
        /// <summary>
        /// 识别结果
        /// </summary>
        [JsonPropertyName("result_set")]
        public InterTradeConsultOpenApiResult ResultSet { get; set; }
    }
}
