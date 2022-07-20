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
            .RegisterSingleton<LogDbContext>()

            .RegisterSingleton<IRepository<Data.Category>, EFRepository<Data.Category, LogDbContext>>()
            .RegisterSingleton<IRepository<Data.Place>, EFRepository<Data.Place, LogDbContext>>()
            .RegisterSingleton<IRepository<Data.Task>, EFRepository<Data.Task, LogDbContext>>()
            .RegisterSingleton<ILogRepo, LogRepo>()

            .RegisterSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}