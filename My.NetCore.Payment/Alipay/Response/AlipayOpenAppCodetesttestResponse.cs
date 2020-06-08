using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenAppCodetesttestResponse.
    /// </summary>
    public class AlipayOpenAppCodetesttestResponse : AlipayResponse
    {
        /// <summary>
        /// 测试测试测试
        /// </summary>
        [JsonPropertyName("testtesttest")]
        public string Testtesttest { get; set; }
    }
}
