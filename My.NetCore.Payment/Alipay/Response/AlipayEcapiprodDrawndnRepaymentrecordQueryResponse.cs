﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEcapiprodDrawndnRepaymentrecordQueryResponse.
    /// </summary>
    public class AlipayEcapiprodDrawndnRepaymentrecordQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 还款流水
        /// </summary>
        [JsonPropertyName("repayment_records")]
        public List<RepaymentRecords> RepaymentRecords { get; set; }

        /// <summary>
        /// 唯一标识这次请求
        /// </summary>
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }
    }
}
