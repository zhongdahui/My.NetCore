using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayBossFncSettleReceivableConfirmResponse.
    /// </summary>
    public class AlipayBossFncSettleReceivableConfirmResponse : AlipayResponse
    {
        /// <summary>
        /// 应收确认结果列表
        /// </summary>
        [JsonPropertyName("result_set")]
        public List<ConfirmReceivableDTO> ResultSet { get; set; }
    }
}
