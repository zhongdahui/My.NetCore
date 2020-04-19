﻿using My.NetCore.Payment.Core.Events;
using My.NetCore.Payment.Core.Interfaces;
using My.NetCore.Payment.Core.Utils;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace My.NetCore.Payment.Core.Gateways
{
    /// <summary>
    /// 网关的抽象基类
    /// </summary>
    public abstract class GatewayBase
    {
        #region 公共字段

        public const string TRUE = "true";
        public const string FALSE = "false";
        public const string SUCCESS = "success";
        public const string FAILURE = "failure";
        public const string FAIL = "FAIL";
        public const string TIME_FORMAT = "yyyy-MM-dd HH:mm:ss";
        public const string TIMEFORMAT = "yyyyMMddHHmmss";

        #endregion

        #region 私有字段

        private GatewayAuxiliaryType _gatewayAuxiliaryType;

        #endregion

        #region 构造函数

        /// <summary>
        /// 构造函数
        /// </summary>
        protected GatewayBase()
            : this(new GatewayData())
        {
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="merchant">商户数据</param>
        protected GatewayBase(IMerchant merchant)
            : this(new GatewayData())
        {
            Merchant = merchant;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="merchant">商户数据</param>
        /// <param name="gatewayData">网关数据</param>
        protected GatewayBase(IMerchant merchant, GatewayData gatewayData)
        {
            Merchant = merchant;
            GatewayData = gatewayData;
        }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="gatewayData">网关数据</param>
        protected GatewayBase(GatewayData gatewayData)
        {
            GatewayData = gatewayData;
        }

        #endregion

        #region 属性

        /// <summary>
        /// 订单数据
        /// </summary>
        public IOrder Order { get; set; }

        /// <summary>
        /// 商户数据
        /// </summary>
        public IMerchant Merchant { get; set; }

        /// <summary>
        /// 通知数据
        /// </summary>
        public INotify Notify { get; set; }

        /// <summary>
        /// 网关的地址
        /// </summary>
        public abstract string GatewayUrl { get; set; }

        /// <summary>
        /// 网关的交易类型
        /// </summary>
        public GatewayTradeType GatewayTradeType { get; set; }

        /// <summary>
        /// 网关数据
        /// </summary>
        public GatewayData GatewayData { get; set; }

        /// <summary>
        /// 是否成功支付
        /// </summary>
        protected abstract bool IsSuccessPay { get; }

        /// <summary>
        /// 是否等待支付
        /// </summary>
        protected abstract bool IsWaitPay { get; }

        /// <summary>
        /// 需要验证的参数名称数组，用于识别不同的网关类型。
        /// </summary>
        protected internal abstract string[] NotifyVerifyParameter { get; }

        #endregion

        #region 方法

        #region 抽象方法

        /// <summary>
        /// 检验网关返回的通知，确认订单是否支付成功
        /// </summary>
        protected internal abstract Task<bool> ValidateNotifyAsync();

        /// <summary>
        /// 当接收到支付网关通知并验证无误时按照支付网关要求格式输出表示成功接收到网关通知的字符串
        /// </summary>
        protected internal virtual void WriteSuccessFlag()
        {
            HttpUtil.Write(SUCCESS);
        }

        /// <summary>
        /// 当接收到支付网关通知并验证有误时按照支付网关要求格式输出表示失败接收到网关通知的字符串
        /// </summary>
        protected internal virtual void WriteFailureFlag()
        {
            HttpUtil.Write(FAILURE);
        }

        #endregion

        #region 私有方法

        /// <summary>
        /// 验证订单
        /// </summary>
        /// <param name="order">订单</param>
        private void ValidateOrder(IOrder order)
        {
            if (order is null)
            {
                throw new ArgumentNullException(nameof(order));
            }

            ValidateParameter(order);
            ValidateParameter(Merchant);
            Order = order;
        }

        /// <summary>
        /// 验证辅助
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        private void ValidateAuxiliary(IAuxiliary auxiliary)
        {
            if (auxiliary is null)
            {
                throw new ArgumentNullException(nameof(auxiliary));
            }

            ValidateParameter(auxiliary);
            ValidateParameter(Merchant);
        }

        /// <summary>
        /// 验证参数
        /// </summary>
        /// <param name="instance">验证对象</param>
        private void ValidateParameter(object instance)
        {
            ValidateUtil.Validate(instance, new Dictionary<object, object>
            {
                {nameof(My.NetCore.Payment.Core.Gateways.GatewayTradeType), GatewayTradeType },
                {nameof(GatewayAuxiliaryType), _gatewayAuxiliaryType }
            });
        }

        protected void OnPaymentFailed(PaymentFailedEventArgs e) => PaymentFailed?.Invoke(this, e);

        protected void OnPaymentSucceed(PaymentSucceedEventArgs e) => PaymentSucceed?.Invoke(this, e);

        #endregion

        #region 公共方法

        #region 支付

        /// <summary>
        /// 支付
        /// </summary>
        /// <param name="order">订单</param>
        /// <returns></returns>
        public string Payment(IOrder order)
        {
            ValidateOrder(order);

            switch (GatewayTradeType)
            {
                case GatewayTradeType.App:
                    {
                        if (this is IAppPayment appPayment)
                        {
                            return appPayment.BuildAppPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Wap:
                    {
                        if (this is IUrlPayment urlPayment)
                        {
                            HttpUtil.Redirect(urlPayment.BuildUrlPayment());
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Web:
                    {
                        if (this is IFormPayment formPayment)
                        {
                            HttpUtil.Write(formPayment.BuildFormPayment());
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Scan:
                    {
                        if (this is IScanPayment scanPayment)
                        {
                            return scanPayment.BuildScanPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Public:
                    {
                        if (this is IPublicPayment publicPayment)
                        {
                            return publicPayment.BuildPublicPayment();
                        }
                    }
                    break;
                case GatewayTradeType.Barcode:
                    {
                        if (this is IBarcodePayment barcodePayment)
                        {
                            barcodePayment.BuildBarcodePayment();
                            return null;
                        }
                    }
                    break;
                case GatewayTradeType.Applet:
                    {
                        if (this is IAppletPayment appletPayment)
                        {
                            return appletPayment.BuildAppletPayment();
                        }
                    }
                    break;
                default:
                    break;
            }

            throw new NotSupportedException($"{GetType()} 没有实现 {GatewayTradeType} 接口");
        }

        #endregion

        #region 查询

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        public INotify Query(IAuxiliary auxiliary)
        {
            _gatewayAuxiliaryType = GatewayAuxiliaryType.Query;
            ValidateAuxiliary(auxiliary);

            if (this is IQuery query)
            {
                return query.BuildQuery(auxiliary);
            }

            throw new NotSupportedException($"{GetType()} 没有实现 IQuery 接口");
        }

        #endregion

        #region 撤销

        /// <summary>
        /// 撤销
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        public INotify Cancel(IAuxiliary auxiliary)
        {
            _gatewayAuxiliaryType = GatewayAuxiliaryType.Cancel;
            ValidateAuxiliary(auxiliary);

            if (this is ICancel cancel)
            {
                return cancel.BuildCancel(auxiliary);
            }

            throw new NotSupportedException($"{GetType()} 没有实现 ICancel 接口");
        }

        #endregion

        #region 关闭

        /// <summary>
        /// 关闭
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        public INotify Close(IAuxiliary auxiliary)
        {
            _gatewayAuxiliaryType = GatewayAuxiliaryType.Close;
            ValidateAuxiliary(auxiliary);

            if (this is IClose close)
            {
                return close.BuildClose(auxiliary);
            }

            throw new NotSupportedException($"{GetType()} 没有实现 IClose 接口");
        }

        #endregion

        #region 退款

        /// <summary>
        /// 退款
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        public INotify Refund(IAuxiliary auxiliary)
        {
            _gatewayAuxiliaryType = GatewayAuxiliaryType.Refund;
            ValidateAuxiliary(auxiliary);

            if (this is IRefund refund)
            {
                return refund.BuildRefund(auxiliary);
            }

            throw new NotSupportedException($"{GetType()} 没有实现 IRefund 接口");
        }

        #endregion

        #region 退款查询

        /// <summary>
        /// 退款查询
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        public INotify RefundQuery(IAuxiliary auxiliary)
        {
            _gatewayAuxiliaryType = GatewayAuxiliaryType.RefundQuery;
            ValidateAuxiliary(auxiliary);

            if (this is IRefundQuery refundQuery)
            {
                return refundQuery.BuildRefundQuery(auxiliary);
            }

            throw new NotSupportedException($"{GetType()} 没有实现 IRefundQuery 接口");
        }

        #endregion

        #region 账单下载

        /// <summary>
        /// 账单下载
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        public void BillDownload(IAuxiliary auxiliary)
        {
            _gatewayAuxiliaryType = GatewayAuxiliaryType.BillDownload;
            ValidateAuxiliary(auxiliary);

            if (this is IBillDownload billDownload)
            {
                HttpUtil.Write(billDownload.BuildBillDownload(auxiliary));
                return;
            }

            throw new NotSupportedException($"{GetType()} 没有实现 IBillDownload 接口");
        }

        #endregion

        #endregion

        #endregion

        #region 事件

        /// <summary>
        /// 网关同步返回的支付通知验证失败时触发,仅针对支付宝和微信的条码支付
        /// </summary>
        public event Action<object, PaymentFailedEventArgs> PaymentFailed;

        /// <summary>
        /// 网关同步返回的支付通知验证成功时触发,仅针对支付宝和微信的条码支付
        /// </summary>
        public event Action<object, PaymentSucceedEventArgs> PaymentSucceed;

        #endregion
    }
}
