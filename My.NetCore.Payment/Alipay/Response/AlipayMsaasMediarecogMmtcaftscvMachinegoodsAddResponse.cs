using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipayMsaasMediarecogMmtcaftscvMachinegoodsAddResponse.
    /// </summary>
    public class AlipayMsaasMediarecogMmtcaftscvMachinegoodsAddResponse : AlipayResponse
    {
        /// <summary>
        /// 柜内区域状态
        /// </summary>
        [JsonPropertyName("regions")]
        public List<RegionState> Regions { get; set; }
    }
}
