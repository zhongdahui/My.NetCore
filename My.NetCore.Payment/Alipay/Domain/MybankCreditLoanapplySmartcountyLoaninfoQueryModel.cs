using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// MybankCreditLoanapplySmartcountyLoaninfoQueryModel Data Structure.
    /// </summary>
    public class MybankCreditLoanapplySmartcountyLoaninfoQueryModel : AlipayObject
    {
        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
