﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayIserviceCognitiveClassificationWasteQueryModel Data Structure.
    /// </summary>
    public class AlipayIserviceCognitiveClassificationWasteQueryModel : AlipayObject
    {
        /// <summary>
        /// 业务编码
        /// </summary>
        [JsonPropertyName("biz_code")]
        public string BizCode { get; set; }

        /// <summary>
        /// 市
        /// </summary>
        [JsonPropertyName("city_code")]
        public string CityCode { get; set; }

        /// <summary>
        /// 图片url，或者文本
        /// </summary>
        [JsonPropertyName("cognition_content")]
        public string CognitionContent { get; set; }

        /// <summary>
        /// 垃圾识别类型
        /// </summary>
        [JsonPropertyName("cognition_type")]
        public string CognitionType { get; set; }

        /// <summary>
        /// 纬度
        /// </summary>
        [JsonPropertyName("latitude")]
        public string Latitude { get; set; }

        /// <summary>
        /// 经度
        /// </summary>
        [JsonPropertyName("longitude")]
        public string Longitude { get; set; }

        /// <summary>
        /// 业务上游流量来源
        /// </summary>
        [JsonPropertyName("source")]
        public string Source { get; set; }

        /// <summary>
        /// 蚂蚁统一会员ID
        /// </summary>
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
