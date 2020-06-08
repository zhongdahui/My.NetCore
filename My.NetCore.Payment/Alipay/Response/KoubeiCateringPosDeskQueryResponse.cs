using System.Collections.Generic;
using System.Text.Json.Serialization;
using My.NetCore.Payment.Alipay.Domain;

namespace My.NetCore.Payment.Alipay.Response
{
    /// <summary>
    /// KoubeiCateringPosDeskQueryResponse.
    /// </summary>
    public class KoubeiCateringPosDeskQueryResponse : AlipayResponse
    {
        /// <summary>
        /// 餐台信息
        /// </summary>
        [JsonPropertyName("pos_desk_list")]
        public List<DeskEntity> PosDeskList { get; set; }
    }
}
