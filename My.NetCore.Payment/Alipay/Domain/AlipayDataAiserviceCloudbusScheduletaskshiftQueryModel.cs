﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayDataAiserviceCloudbusScheduletaskshiftQueryModel Data Structure.
    /// </summary>
    public class AlipayDataAiserviceCloudbusScheduletaskshiftQueryModel : AlipayObject
    {
        /// <summary>
        /// 接口版本号
        /// </summary>
        [JsonPropertyName("app_version")]
        public string AppVersion { get; set; }

        /// <summary>
        /// 任务id
        /// </summary>
        [JsonPropertyName("plan_id")]
        public string PlanId { get; set; }
    }
}
