﻿using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusSchedualtaskQueryResponse.
    /// </summary>
    public class AlipayDataAiserviceCloudbusSchedualtaskQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 结果
        /// </summary>
        [JsonPropertyName("result")]
        public ScheduleWorkResult Result { get; set; }
    }
}
