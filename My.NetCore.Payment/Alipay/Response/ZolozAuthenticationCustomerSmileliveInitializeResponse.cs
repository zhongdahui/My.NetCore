using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// ZolozAuthenticationCustomerSmileliveInitializeResponse.
    /// </summary>
    public class ZolozAuthenticationCustomerSmileliveInitializeResponse : AlipayResponse
    {
        /// <summary>
        /// result
        /// </summary>
        [JsonPropertyName("result")]
        public string Result { get; set; }
    }
}
