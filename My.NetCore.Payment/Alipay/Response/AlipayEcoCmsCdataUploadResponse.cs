using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayEcoCmsCdataUploadResponse.
    /// </summary>
    public class AlipayEcoCmsCdataUploadResponse : AlipayResponse
    {
        /// <summary>
        /// 投放消息ID
        /// </summary>
        [JsonPropertyName("id")]
        public long Id { get; set; }
    }
}
