﻿using My.NetCore.Payment.Core.Gateways;
using My.NetCore.Payment.Core.Interfaces;
using System;

namespace My.NetCore.Payment.Core.Events
{
    /// <summary>
    /// 支付事件数据的基类
    /// </summary>
    public abstract class PaymentEventArgs : EventArgs
    {

        #region 私有字段

        protected GatewayBase _gateway;
        private readonly string _notifyServerHostAddress;

        #endregion

        #region 构造函数

        /// <summary>
        /// 初始化支付事件数据的基类
        /// </summary>
        /// <param name="gateway">支付网关</param>
        protected PaymentEventArgs(GatewayBase gateway)
        {
            _gateway = gateway;
//#if DEBUG
//            _notifyServerHostAddress = "127.0.0.1";
//#else
//            _notifyServerHostAddress = HttpUtil.RemoteIpAddress.ToString();
//#endif
        }

        #endregion

        #region 属性

        /// <summary>
        /// 发送支付通知的网关IP地址
        /// </summary>
        public string NotifyServerHostAddress
        {
            get
            {
                return _notifyServerHostAddress;
            }
        }

        /// <summary>
        /// 支付网关的数据
        /// </summary>
        public GatewayData GatewayData
        {
            get
            {
                return _gateway.GatewayData;
            }
        }

        /// <summary>
        /// 支付网关类型
        /// </summary>
        public Type GatewayType
        {
            get
            {
                return _gateway.GetType();
            }
        }

        /// <summary>
        /// 通知数据
        /// </summary>
        public INotify Notify
        {
            get
            {
                return _gateway.Notify;
            }
        }

        #endregion
    }
}