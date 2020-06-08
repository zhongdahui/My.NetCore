namespace My.NetCore.Framework.IOC.Models {
  public class DependencyTreeModel {

    public DependencyTreeModel ParentDependencyTree { get; set; }


    public DependencyModel Dependency { get; set; }

  }
}
