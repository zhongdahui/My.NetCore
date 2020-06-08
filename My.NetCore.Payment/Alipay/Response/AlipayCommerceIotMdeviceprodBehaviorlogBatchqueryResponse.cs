﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceIotMdeviceprodBehaviorlogBatchqueryResponse.
    /// </summary>
    public class AlipayCommerceIotMdeviceprodBehaviorlogBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 日志关联的设备信息
        /// </summary>
        [JsonPropertyName("result_list")]
        public List<DeviceBehaviorLogResponse> ResultList { get; set; }
    }
}
