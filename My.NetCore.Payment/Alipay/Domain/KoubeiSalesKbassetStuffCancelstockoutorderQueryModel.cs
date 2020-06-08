﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// KoubeiSalesKbassetStuffCancelstockoutorderQueryModel Data Structure.
    /// </summary>
    public class KoubeiSalesKbassetStuffCancelstockoutorderQueryModel : AlipayObject
    {
        /// <summary>
        /// 扩展字段，备用
        /// </summary>
        [JsonPropertyName("ext_info")]
        public string ExtInfo { get; set; }

        /// <summary>
        /// 分页查询当前查询页码
        /// </summary>
        [JsonPropertyName("page_no")]
        public long PageNo { get; set; }

        /// <summary>
        /// 分页查询每页数据量
        /// </summary>
        [JsonPropertyName("page_size")]
        public long PageSize { get; set; }
    }
}
