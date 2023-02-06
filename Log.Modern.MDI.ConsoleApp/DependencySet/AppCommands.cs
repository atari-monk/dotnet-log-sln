using CRUDCommandHelper;
using Log.Modern.Lib;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.MDI.ConsoleApp;

public class AppCommands 
    : DIHelper.MicrosoftDI.MDIDependencySet
{
    public AppCommands(
        IServiceCollection container) 
        : base(container)
    {
    }

    public override void Register()
    {
        Container.AddSingleton<IReadCommand<LogFilterArgs>, LogReadCommand>();
    }
}