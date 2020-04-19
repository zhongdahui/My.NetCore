﻿
using My.NetCore.Payment.Core.Gateways;

namespace My.NetCore.Payment.Core.Events
{
    /// <summary>
    /// 支付成功网关事件数据
    /// </summary>
    public class PaymentSucceedEventArgs : PaymentEventArgs
    {

        #region 构造函数

        /// <summary>
        /// 初始化支付成功网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public PaymentSucceedEventArgs(GatewayBase gateway)
            : base(gateway)
        {
        }

        #endregion
    }
}
