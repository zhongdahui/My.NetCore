using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// MybankPaymentTradeBankRootQueryResponse.
    /// </summary>
    public class MybankPaymentTradeBankRootQueryResponse : AlipayResponse
    {
        /// <summary>
        /// Institution列表
        /// </summary>
        [JsonPropertyName("bank_details")]
        public List<Institution> BankDetails { get; set; }
    }
}
