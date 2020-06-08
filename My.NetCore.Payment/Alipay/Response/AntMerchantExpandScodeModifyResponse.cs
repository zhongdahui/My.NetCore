using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AntMerchantExpandScodeModifyResponse.
    /// </summary>
    public class AntMerchantExpandScodeModifyResponse : AlipayResponse
    {
        /// <summary>
        /// 更新码值返回结果
        /// </summary>
        [JsonPropertyName("update_code_response")]
        public UpdateCodeResponse UpdateCodeResponse { get; set; }
    }
}
