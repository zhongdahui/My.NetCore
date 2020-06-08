using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AntMerchantExpandScodeEledeSignResponse.
    /// </summary>
    public class AntMerchantExpandScodeEledeSignResponse : AlipayResponse
    {
        /// <summary>
        /// 打标接口返回结果
        /// </summary>
        [JsonPropertyName("add_tag_response")]
        public AddTagResponse AddTagResponse { get; set; }
    }
}
