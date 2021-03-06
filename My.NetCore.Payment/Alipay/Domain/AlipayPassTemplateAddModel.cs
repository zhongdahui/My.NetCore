﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// AlipayPassTemplateAddModel Data Structure.
    /// </summary>
    public class AlipayPassTemplateAddModel : AlipayObject
    {
        /// <summary>
        /// 模板内容信息，遵循JSON规范，详情参见tpl_content参数说明：https://doc.open.alipay.com/doc2/detail.htm?treeId=193&articleId=105249&docType=1#tpl_content
        /// </summary>
        [JsonPropertyName("tpl_content")]
        public string TplContent { get; set; }

        /// <summary>
        /// 商户用于控制模版的唯一性。（可以使用时间戳保证唯一性）
        /// </summary>
        [JsonPropertyName("unique_id")]
        public string UniqueId { get; set; }
    }
}
