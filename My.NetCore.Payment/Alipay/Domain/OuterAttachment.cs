﻿using System.Text.Json.Serialization;

namespace My.NetCore.Payment.Alipay.Domain
{
    /// <summary>
    /// OuterAttachment Data Structure.
    /// </summary>
    public class OuterAttachment : AlipayObject
    {
        /// <summary>
        /// 资质类型：ISV_ICP_LICENCE-代理商营业执照；ICP_LICENCE-营业执照；PORTRAIT_AUTH_LICENSE-肖像授权文件；TRADE_MARK_LICENSE - 商标注册证；SPECIAL_BUSINESS_LICENSE - 特殊行业资质；OTHER_FILE - 其他文件
        /// </summary>
        [JsonPropertyName("attachment_type")]
        public string AttachmentType { get; set; }

        /// <summary>
        /// oss key
        /// </summary>
        [JsonPropertyName("file_key")]
        public string FileKey { get; set; }

        /// <summary>
        /// 有效结束日期；格式：YYYY-MM-DD
        /// </summary>
        [JsonPropertyName("validate_end_time")]
        public string ValidateEndTime { get; set; }

        /// <summary>
        /// 有效开始日期，格式：YYYY-MM-DD
        /// </summary>
        [JsonPropertyName("validate_start_time")]
        public string ValidateStartTime { get; set; }
    }
}
