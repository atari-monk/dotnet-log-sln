using DIHelper.Unity;
using Log.Data;
using Unity;

namespace Log.ConsoleApp;

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
        Container
            .RegisterSingleton<
                Console.Lib.IFilterFactory<LogModel, Log.Console.Lib.LogFilter>
                , Console.Lib.LogFiltrator>()
            .RegisterSingleton<
                Console.Lib.IFilterFactory<Data.Task, Console.Lib.TaskFilter>
                , Console.Lib.TaskFiltrator>();
    }
}