﻿using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMarketingDataDashboardBatchqueryResponse.
    /// </summary>
    public class AlipayMarketingDataDashboardBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 仪表盘列表信息
        /// </summary>
        [JsonPropertyName("dashboard_list")]
        public List<DashBoardMeta> DashboardList { get; set; }

        /// <summary>
        /// 报表总页数
        /// </summary>
        [JsonPropertyName("total_page_count")]
        public string TotalPageCount { get; set; }
    }
}
