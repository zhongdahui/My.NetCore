using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicArticlesummaryDataBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicArticlesummaryDataBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 文章分析数据列表
        /// </summary>
        [JsonPropertyName("data_list")]
        public List<ArticleSummaryAnalysisData> DataList { get; set; }
    }
}
