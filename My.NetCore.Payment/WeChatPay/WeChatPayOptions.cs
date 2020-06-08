﻿using My.NetCore.Payment.Security;

namespace My.NetCore.Payment.WeChatPay
{
    /// <summary>
    /// WeChatPay 配置选项
    /// </summary>
    public class WeChatPayOptions
    {
        internal string CertificateHash;

        private string certificate;
        private string certificatePassword;

        /// <summary>
        /// 应用密钥
        /// 如：目前仅调用"企业红包API"时，使用企业微信的Secret。
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// 应用号
        /// 如：公众平台AppId/开放平台AppId/小程序AppId/企业微信CorpId等
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        /// 商户号
        /// </summary>
        public string MchId { get; set; }

        /// <summary>
        /// 子商户应用号
        /// 仅服务商时使用
        /// </summary>
        public string SubAppId { get; set; }

        /// <summary>
        /// 子商户号
        /// 仅服务商时使用
        /// </summary>
        public string SubMchId { get; set; }

        /// <summary>
        /// API密钥
        /// </summary>
        public string Key { get; set; }

        /// <summary>
        /// API证书(文件名/文件的Base64编码)
        /// </summary>
        public string Certificate
        {
            get => certificate;
            set
            {
                if (!string.IsNullOrEmpty(value))
                {
                    certificate = value;
                    CertificateHash = MD5.Compute(certificate);
                }
            }
        }

        /// <summary>
        /// API证书密码
        /// 默认为商户号
        /// </summary>
        public string CertificatePassword
        {
            get => string.IsNullOrEmpty(certificatePassword) ? MchId : certificatePassword;
            set => certificatePassword = value;
        }

        /// <summary>
        /// RSA公钥
        /// 目前仅调用"企业付款到银行卡API"时使用，执行"获取RSA加密公钥API"即可获取。
        /// </summary>
        public string RsaPublicKey { get; set; }
    }
}
