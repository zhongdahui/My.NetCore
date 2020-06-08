using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiSalesKbassetStuffQrcodereturnSyncResponse.
    /// </summary>
    public class KoubeiSalesKbassetStuffQrcodereturnSyncResponse : AlipayResponse
    {
        /// <summary>
        /// 供应商回传码值被处理结果
        /// </summary>
        [JsonPropertyName("return_qrcode_results")]
        public List<AccessReturnQrcodeResult> ReturnQrcodeResults { get; set; }
    }
}
