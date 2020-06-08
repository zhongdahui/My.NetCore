using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenMiniDataPageQueryResponse.
    /// </summary>
    public class AlipayOpenMiniDataPageQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 页面访问数据结果
        /// </summary>
        [JsonPropertyName("page_visit_data_list_response")]
        public List<PageVisitDataResponse> PageVisitDataListResponse { get; set; }
    }
}
