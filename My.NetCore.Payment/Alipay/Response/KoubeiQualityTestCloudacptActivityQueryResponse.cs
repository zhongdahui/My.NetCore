﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiQualityTestCloudacptActivityQueryResponse.
    /// </summary>
    public class KoubeiQualityTestCloudacptActivityQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 活动列表
        /// </summary>
        [JsonPropertyName("activity_list")]
        public List<OpenActivity> ActivityList { get; set; }
    }
}
