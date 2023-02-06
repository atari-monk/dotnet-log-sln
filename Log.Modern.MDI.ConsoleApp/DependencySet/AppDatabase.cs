using EFCore.Helper;
using Log.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class AppDatabase 
    : DIHelper.MicrosoftDI.MDIDependencySet
{
    public AppDatabase(
        IServiceCollection container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container.AddSingleton<LogDbContext>();

        Container.AddSingleton<IRepository<Category>, EFRepository<Category, LogDbContext>>();
        Container.AddSingleton<IRepository<Place>, EFRepository<Place, LogDbContext>>();
        Container.AddSingleton<IRepository<Data.Task>, EFRepository<Data.Task, LogDbContext>>();
        Container.AddSingleton<ILogRepo, LogRepo>();

        Container.AddSingleton<ILogUnitOfWork, LogUnitOfWork>();
    }
}