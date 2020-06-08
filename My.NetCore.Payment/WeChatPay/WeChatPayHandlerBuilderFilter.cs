using System;
using System.Net.Http;
using My.NetCore.Payment.WeChatPay.Utility;
using Microsoft.Extensions.Http;

namespace My.NetCore.Payment.WeChatPay
{
    public class WeChatPayHandlerBuilderFilter : IHttpMessageHandlerBuilderFilter
    {
        private readonly WeChatPayCertificateManager _certificateManager;

        public WeChatPayHandlerBuilderFilter(WeChatPayCertificateManager certificateManager)
        {
            _certificateManager = certificateManager;
        }

        public Action<HttpMessageHandlerBuilder> Configure(Action<HttpMessageHandlerBuilder> next)
        {
            if (next == null)
            {
                throw new ArgumentNullException(nameof(next));
            }

            return (builder) =>
            {
                next(builder);

                if (builder.PrimaryHandler is HttpClientHandler handler)
                {
                    if (builder.Name.Contains(WeChatPayClient.Prefix))
                    {
                        var hash = builder.Name.RemovePreFix(WeChatPayClient.Prefix);
                        if (_certificateManager.TryGetValue(hash, out var certificate))
                        {
                            handler.ClientCertificates.Add(certificate);
                        }
                    }
                }
            };
        }
    }
}
