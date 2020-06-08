using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayIserviceMindvJobsbyuserQueryResponse.
    /// </summary>
    public class AlipayIserviceMindvJobsbyuserQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 用户填写的任务id列表
        /// </summary>
        [JsonPropertyName("job_ids")]
        public List<long> JobIds { get; set; }
    }
}
