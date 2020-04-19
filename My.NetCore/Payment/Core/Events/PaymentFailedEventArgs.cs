﻿
using My.NetCore.Payment.Core.Gateways;

namespace My.NetCore.Payment.Core.Events
{
    /// <summary>
    /// 支付失败网关事件数据
    /// </summary>
    public class PaymentFailedEventArgs : PaymentEventArgs
    {

        #region 构造函数

        /// <summary>
        /// 初始化支付失败网关事件数据
        /// </summary>
        /// <param name="gateway">支付网关</param>
        public PaymentFailedEventArgs(GatewayBase gateway)
            : base(gateway)
        {
        }

        #endregion

        #region 属性

        /// <summary>
        /// 支付失败信息
        /// </summary>
        public string Message { get; set; }

        #endregion
    }
}
