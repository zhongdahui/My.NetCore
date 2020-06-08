﻿#if NETCOREAPP3_1

namespace My.NetCore.Payment.Alipay.Notify
{
    /// <summary>
    /// 资金单据状态变更通知
    /// https://docs.open.alipay.com/msgapi_60/alipay.fund.trans.order.changed/
    /// </summary>
    public class AlipayFundTransOrderChangedNotify : AlipayFromNotify
    {
    }
}

#endif
