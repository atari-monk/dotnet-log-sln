using DIHelper.Unity;
using EFCore.Helper;
using Log.Data;
using Unity;

namespace Log.Modern.ConsoleApp;

public class AppDatabase 
    : UnityDependencySet
{
    public AppDatabase(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterSingleton<LogContext>()

            .RegisterSingleton<IRepository<Data.Category>, EFRepository<Data.Category, LogContext>>()
            .RegisterSingleton<IRepository<Data.Place>, EFRepository<Data.Place, LogContext>>()
            .RegisterSingleton<IRepository<Data.Task>, EFRepository<Data.Task, LogContext>>()
            .RegisterSingleton<ILogRepo, LogRepo>()

            .RegisterSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}