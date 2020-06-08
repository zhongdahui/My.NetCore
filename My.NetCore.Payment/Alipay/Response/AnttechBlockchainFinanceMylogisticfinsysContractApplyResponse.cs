﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AnttechBlockchainFinanceMylogisticfinsysContractApplyResponse.
    /// </summary>
    public class AnttechBlockchainFinanceMylogisticfinsysContractApplyResponse : AlipayResponse
    {
        /// <summary>
        /// 错误码
        /// </summary>
        [JsonPropertyName("code")]
        public override string Code { get; set; }
    }
}
