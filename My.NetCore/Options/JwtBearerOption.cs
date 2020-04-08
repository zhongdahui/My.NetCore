using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace My.NetCore.Options
{
    public class JwtBearerOption
    {
        public string AuthenticationScheme { get; set; } = "Bearer";
        /// <summary>
        /// //是否验证SecurityKey
        /// </summary>
        public bool ValidateIssuerSigningKey { get; set; } = true;
        /// <summary>
        /// 拿到SecurityKey
        /// </summary>
        public string SecurityKey { get; set; } = "d0ecd23c-dfdb-4005-a2ea-0fea210c858a";

        /// <summary>
        /// 是否验证Issuer
        /// </summary>
        public bool ValidateIssuer { get; set; } = true;
        /// <summary>
        /// Issuer，这两项和前面签发jwt的设置一致
        /// </summary>
        public string Issuer { get; set; } = "jwtIssuertest";

        /// <summary>
        /// 是否验证Audience
        /// </summary>
        public bool ValidateAudience { get; set; } = true;
        /// <summary>
        /// Audience
        /// </summary>
        public string Audience { get; set; } = "jwtIssuertest";

        /// <summary>
        /// //是否验证失效时间
        /// </summary>
        public bool ValidateLifetime { get; set; } = true;
        /// <summary>
        /// 失效时间（秒）
        /// </summary>
        public double ExpireSeconds { get; set; } = 7200;
    }
}
