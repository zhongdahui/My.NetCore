﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMsaasItapUserCertifyResponse.
    /// </summary>
    public class AlipayMsaasItapUserCertifyResponse : AlipayResponse
    {
        /// <summary>
        /// Itap统一返回结果模型
        /// </summary>
        [JsonPropertyName("payload")]
        public List<ItapResponsePayload> Payload { get; set; }

        /// <summary>
        /// 请求唯一ID
        /// </summary>
        [JsonPropertyName("request_id")]
        public string RequestId { get; set; }
    }
}
