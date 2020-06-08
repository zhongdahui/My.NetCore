﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceIotSupplierAssetModifyResponse.
    /// </summary>
    public class AlipayCommerceIotSupplierAssetModifyResponse : AlipayResponse
    {
        /// <summary>
        /// 记录id
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}
