﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEbppConfigCitySearchResponse.
    /// </summary>
    public class AlipayEbppConfigCitySearchResponse : AlipayResponse
    {
        /// <summary>
        /// 接口主要输出参数列表: AreaInfoResult{List{ areaInfo：{province, cityList<String>}} }
        /// </summary>
        [JsonPropertyName("area_info_result")]
        public List<AreaInfo> AreaInfoResult { get; set; }
    }
}
