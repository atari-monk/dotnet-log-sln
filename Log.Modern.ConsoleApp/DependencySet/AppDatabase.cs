using DIHelper.Unity;
using EFCoreHelper;
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

            .RegisterSingleton<IGenericRepository<Data.Category>, EFGenericRepository<Data.Category, LogContext>>()
            .RegisterSingleton<IGenericRepository<Data.Place>, EFGenericRepository<Data.Place, LogContext>>()
            .RegisterSingleton<IGenericRepository<Data.Task>, EFGenericRepository<Data.Task, LogContext>>()
            .RegisterSingleton<ILogRepo, LogRepo>()

            .RegisterSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}