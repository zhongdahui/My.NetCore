﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayOpenMiniPublicRelationQueryModel Data Structure.
    /// </summary>
    public class AlipayOpenMiniPublicRelationQueryModel : AlipayObject
    {
        /// <summary>
        /// 小程序ID
        /// </summary>
        [JsonPropertyName("mini_app_id")]
        public string MiniAppId { get; set; }
    }
}
