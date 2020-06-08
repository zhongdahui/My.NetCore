using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataIotdataUserBusinessQueryResponse.
    /// </summary>
    public class AlipayDataIotdataUserBusinessQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 用户管理的业务列表
        /// </summary>
        [JsonPropertyName("data")]
        public List<UserBusiness> Data { get; set; }
    }
}
