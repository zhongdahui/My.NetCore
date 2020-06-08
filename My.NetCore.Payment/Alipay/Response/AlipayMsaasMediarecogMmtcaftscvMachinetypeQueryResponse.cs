using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMsaasMediarecogMmtcaftscvMachinetypeQueryResponse.
    /// </summary>
    public class AlipayMsaasMediarecogMmtcaftscvMachinetypeQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 视觉货柜机型信息列表
        /// </summary>
        [JsonPropertyName("machine_types")]
        public List<MachineType> MachineTypes { get; set; }
    }
}
