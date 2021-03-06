﻿using System.Xml.Serialization;

namespace My.NetCore.Payment.WeChatPay.Response
{
    [XmlRoot("xml")]
    public class WeChatPayDownloadBillResponse : WeChatPayResponse
    {
        /// <summary>
        /// 返回状态码
        /// </summary>
        [XmlElement("return_code")]
        public string ReturnCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        [XmlElement("return_msg")]
        public string ReturnMsg { get; set; }
    }
}
