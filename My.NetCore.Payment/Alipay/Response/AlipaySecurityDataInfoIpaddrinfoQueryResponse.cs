using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// AlipaySecurityDataInfoIpaddrinfoQueryResponse.
    /// </summary>
    public class AlipaySecurityDataInfoIpaddrinfoQueryResponse : AlipayResponse
    {
        /// <summary>
        /// ip_addr_lbs_info:IP地址归属地对象。其中province为IP地址归属地的省，city为IP地址归属地的城市
        /// </summary>
        [JsonPropertyName("ip_addr_lbs_info")]
        public IpAddrLbsInfo IpAddrLbsInfo { get; set; }
    }
}
