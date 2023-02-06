using EFCore.Helper;
using Log.Data;
using Unity;

namespace Log.Modern.Wizard.ConsoleApp;

public class AppDatabase 
    : DIHelper.Unity.UnityDependencySet
{
    public AppDatabase(
        IUnityContainer container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container.RegisterSingleton<LogDbContext>();

        Container.RegisterSingleton<IRepository<Data.Category>, EFRepository<Data.Category, LogDbContext>>();
        Container.RegisterSingleton<IRepository<Data.Place>, EFRepository<Data.Place, LogDbContext>>();
        Container.RegisterSingleton<IRepository<Data.Task>, EFRepository<Data.Task, LogDbContext>>();
        Container.RegisterSingleton<ILogRepo, LogRepo>();

        Container.RegisterSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}