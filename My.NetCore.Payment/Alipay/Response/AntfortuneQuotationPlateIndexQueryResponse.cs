﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AntfortuneQuotationPlateIndexQueryResponse.
    /// </summary>
    public class AntfortuneQuotationPlateIndexQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 用于返回板块的信息
        /// </summary>
        [JsonPropertyName("plate_list")]
        public List<PlateInfoForYiCai> PlateList { get; set; }

        /// <summary>
        /// 板块数据
        /// </summary>
        [JsonPropertyName("res")]
        public string Res { get; set; }
    }
}
