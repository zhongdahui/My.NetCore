using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// ZhimaOpenQerqQerqQueryModel Data Structure.
    /// </summary>
    public class ZhimaOpenQerqQerqQueryModel : AlipayObject
    {
        /// <summary>
        /// 123
        /// </summary>
        [JsonPropertyName("address")]
        public AgreementParams Address { get; set; }
    }
}
