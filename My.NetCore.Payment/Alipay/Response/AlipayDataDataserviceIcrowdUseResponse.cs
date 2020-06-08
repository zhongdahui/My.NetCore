using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayDataDataserviceIcrowdUseResponse.
    /// </summary>
    public class AlipayDataDataserviceIcrowdUseResponse : AlipayResponse
    {
        /// <summary>
        /// 接口返回内容
        /// </summary>
        [JsonPropertyName("icrowd_use_resp")]
        public IcrowdUseResp IcrowdUseResp { get; set; }
    }
}
