using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDaoweiWeikeTaskviewQueryResponse.
    /// </summary>
    public class AlipayDaoweiWeikeTaskviewQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 微客当前城市的任务视图列表
        /// </summary>
        [JsonPropertyName("task_views")]
        public List<WeikeTaskView> TaskViews { get; set; }
    }
}
