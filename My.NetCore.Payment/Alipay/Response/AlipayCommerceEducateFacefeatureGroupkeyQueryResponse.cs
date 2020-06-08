using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayCommerceEducateFacefeatureGroupkeyQueryResponse.
    /// </summary>
    public class AlipayCommerceEducateFacefeatureGroupkeyQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 人脸库key
        /// </summary>
        [JsonPropertyName("group_key")]
        public string GroupKey { get; set; }
    }
}
