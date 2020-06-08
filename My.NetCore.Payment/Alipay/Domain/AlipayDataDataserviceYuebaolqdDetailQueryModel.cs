﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayDataDataserviceYuebaolqdDetailQueryModel Data Structure.
    /// </summary>
    public class AlipayDataDataserviceYuebaolqdDetailQueryModel : AlipayObject
    {
        /// <summary>
        /// 服务入参，格式为yyyymmdd
        /// </summary>
        [JsonPropertyName("report_date")]
        public string ReportDate { get; set; }
    }
}
