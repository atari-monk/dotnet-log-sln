using CLIHelper.MDI;
using CommandDotNet.MDI.Helper;
using Config.Wrapper.MDI;
using DIHelper;
using Log.Table.MDI;
using Microsoft.Extensions.DependencyInjection;
using Serilog.Wrapper.MDI;
using Log.Modern.Lib.MDI;

namespace Log.Modern.MDI.ConsoleApp;

public class MDIDependencySuite
    : DIHelper.MicrosoftDI.MDIDependencySuite
{
    public MDIDependencySuite(
        IServiceCollection container) 
        : base(container) 
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<SerilogSet>();
        RegisterSet<AppConfigSet>();
    }
    
    protected override void RegisterDatabase()=> 
        RegisterSet<AppDatabase>();

     protected override void RegisterConsoleInput() => 
        RegisterSet<CliIOSet>();

    protected override void RegisterConsoleOutput() => 
        RegisterSet<LogTableSet>();

    protected override void RegisterCommands()
    {
        RegisterSet<DataFilter>();
        RegisterSet<AppCommands>();
        Container.AddSingleton<AppProg>();
        Container.AddSingleton<LogModelCommands>();
    }

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<AppProg>>();

    protected override IServiceProvider? BuildServiceProvider() => 
        Container.BuildServiceProvider();

    protected override void RegisterWithServiceProvider()
    {
        ArgumentNullException.ThrowIfNull(ServiceProvider);
        var appProgRef = ServiceProvider.GetService<IAppProgram>();
        ArgumentNullException.ThrowIfNull(appProgRef);
        var appProg = (AppProgMDI<AppProg>)appProgRef;
        appProg.SetDIContainer(ServiceProvider);
    }
}