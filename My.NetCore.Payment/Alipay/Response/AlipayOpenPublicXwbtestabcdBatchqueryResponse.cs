using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayOpenPublicXwbtestabcdBatchqueryResponse.
    /// </summary>
    public class AlipayOpenPublicXwbtestabcdBatchqueryResponse : AlipayResponse
    {
        /// <summary>
        /// 1111
        /// </summary>
        [JsonPropertyName("b")]
        public string B { get; set; }
    }
}
