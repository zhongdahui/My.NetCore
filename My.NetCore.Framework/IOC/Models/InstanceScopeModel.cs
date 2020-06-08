﻿namespace My.NetCore.Framework.IOC.Models {
  public class InstanceScopeModel {

    /// <summary>
    /// 实例
    /// </summary>
    public object Instance { get; set; }

    /// <summary>
    /// 父级
    /// </summary>
    public InstanceScopeModel ParentInstanceScope { get; set; }
  }
}