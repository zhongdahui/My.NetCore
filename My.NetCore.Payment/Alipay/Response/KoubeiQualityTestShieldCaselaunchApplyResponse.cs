using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiQualityTestShieldCaselaunchApplyResponse.
    /// </summary>
    public class KoubeiQualityTestShieldCaselaunchApplyResponse : AlipayResponse
    {
        /// <summary>
        /// 拓展信息
        /// </summary>
        [JsonPropertyName("ext_infos")]
        public string ExtInfos { get; set; }
    }
}
