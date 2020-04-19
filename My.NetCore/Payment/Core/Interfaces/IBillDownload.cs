﻿using System.IO;

namespace My.NetCore.Payment.Core.Interfaces
{
    /// <summary>
    /// 账单下载
    /// </summary>
    public interface IBillDownload
    {
        /// <summary>
        /// 生成账单下载订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        FileStream BuildBillDownload(IAuxiliary auxiliary);

        /// <summary>
        /// 初始化账单下载订单参数
        /// </summary>
        /// <param name="auxiliary">辅助参数</param>
        void InitBillDownload(IAuxiliary auxiliary);
    }
}
