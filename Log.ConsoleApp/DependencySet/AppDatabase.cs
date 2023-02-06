using EFCore.Helper;
using Log.Data;
using Unity;
using Task = Log.Data.Task;

namespace Log.ConsoleApp;

public class AppDatabase 
    : DIHelper.Unity.UnityDependencySuite
{
    public AppDatabase(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container
            .RegisterInstance(Container.Resolve<LogDbContext>(), InstanceLifetime.Singleton)

            .RegisterSingleton<IRepository<Category>, EFRepository<Category, LogDbContext>>()
            .RegisterSingleton<IRepository<Place>, EFRepository<Place, LogDbContext>>()
            .RegisterSingleton<IRepository<Task>, EFRepository<Task, LogDbContext>>()
            .RegisterSingleton<ILogRepo, LogRepo>();

        var unitOfWork = Container.Resolve<LogUnitOfWork>();
        Container
            .RegisterInstance<IUnitOfWork>(unitOfWork, InstanceLifetime.Singleton)
            .RegisterInstance<ILogUnitOfWork>(unitOfWork, InstanceLifetime.Singleton);
    }
}