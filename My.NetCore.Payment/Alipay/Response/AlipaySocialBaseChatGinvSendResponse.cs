using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipaySocialBaseChatGinvSendResponse.
    /// </summary>
    public class AlipaySocialBaseChatGinvSendResponse : AlipayResponse
    {
        /// <summary>
        /// 结果提示信息
        /// </summary>
        [JsonPropertyName("result_tip")]
        public string ResultTip { get; set; }
    }
}
