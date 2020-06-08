﻿using System.Collections.Generic;
using My.NetCore.Payment.WeChatPay.Response;
using My.NetCore.Payment.WeChatPay.Utility;

namespace My.NetCore.Payment.WeChatPay.Request
{
    /// <summary>
    /// 转换短链接 (普通商户 / 服务商)
    /// </summary>
    public class WeChatPayToolsShortUrlRequest : IWeChatPayRequest<WeChatPayToolsShortUrlResponse>
    {
        /// <summary>
        /// URL链接
        /// </summary>
        public string LongUrl { get; set; }

        #region IWeChatPayRequest Members

        public string GetRequestUrl()
        {
            return "https://api.mch.weixin.qq.com/tools/shorturl";
        }

        public IDictionary<string, string> GetParameters()
        {
            var parameters = new WeChatPayDictionary
            {
                { "long_url", LongUrl }
            };
            return parameters;
        }

        public void PrimaryHandler(WeChatPayOptions options, WeChatPaySignType signType, WeChatPayDictionary sortedTxtParams)
        {
            sortedTxtParams.Add(WeChatPayConsts.nonce_str, WeChatPayUtility.GenerateNonceStr());
            sortedTxtParams.Add(WeChatPayConsts.appid, options.AppId);
            sortedTxtParams.Add(WeChatPayConsts.sub_appid, options.SubAppId);
            sortedTxtParams.Add(WeChatPayConsts.mch_id, options.MchId);
            sortedTxtParams.Add(WeChatPayConsts.sub_mch_id, options.SubMchId);

            sortedTxtParams.Add(WeChatPayConsts.sign, WeChatPaySignature.SignWithKey(sortedTxtParams, options.Key, signType));
        }

        #endregion
    }
}
