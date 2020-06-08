using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayBossOrderDiagnosisGetResponse.
    /// </summary>
    public class AlipayBossOrderDiagnosisGetResponse : AlipayResponse
    {
        /// <summary>
        /// 诊断模型
        /// </summary>
        [JsonPropertyName("diagnosis_result")]
        public List<DiagnosisInfo> DiagnosisResult { get; set; }
    }
}
