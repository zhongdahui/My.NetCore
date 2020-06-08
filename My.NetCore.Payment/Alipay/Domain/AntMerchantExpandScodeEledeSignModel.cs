﻿using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AntMerchantExpandScodeEledeSignModel Data Structure.
    /// </summary>
    public class AntMerchantExpandScodeEledeSignModel : AlipayObject
    {
        /// <summary>
        /// 打标请求参数
        /// </summary>
        [JsonPropertyName("add_tag_request")]
        public List<AddTagRequest> AddTagRequest { get; set; }
    }
}
