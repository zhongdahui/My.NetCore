﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenAppReproCesCreateResponse.
    /// </summary>
    public class AlipayOpenAppReproCesCreateResponse : AlipayResponse
    {
        /// <summary>
        /// 21
        /// </summary>
        [JsonPropertyName("resname")]
        public List<Gavinmed> Resname { get; set; }

        /// <summary>
        /// 21
        /// </summary>
        [JsonPropertyName("result")]
        public List<string> Result { get; set; }
    }
}
