using DIHelper.Unity;
using Log.Modern.Lib;
using Unity;

namespace Log.Modern.ConsoleApp;

public class DataFilter 
    : UnityDependencySet
{
    public DataFilter(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container.RegisterSingleton<
            IFilterFactory<Data.Task, TaskArgFilter>
            , TaskFilter>();
    }
}