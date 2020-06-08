using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMerchantPayforprivilegeProfileQueryResponse.
    /// </summary>
    public class AlipayMerchantPayforprivilegeProfileQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 充享惠卡模板设置
        /// </summary>
        [JsonPropertyName("card_template_config")]
        public PayForPrivilegeCardTemplateConfig CardTemplateConfig { get; set; }
    }
}
