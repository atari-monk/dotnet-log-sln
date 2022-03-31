using CLIHelper.Unity;
using CommandDotNet.Unity.Helper;
using Config.Wrapper.Unity;
using Log.Modern.Lib.Unity;
using Log.Table.Unity;
using Serilog.Wrapper.Unity;
using Unity;

namespace Log.Modern.ConsoleApp;

public class UnityDependencySuite 
    : DIHelper.Unity.UnityDependencySuite
{
    public UnityDependencySuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<AppLoggerSet>();
        RegisterSet<AppConfigSet>();
    }

    protected override void RegisterDatabase()=> 
        RegisterSet<AppDatabase>();

    protected override void RegisterConsoleInput() => 
        RegisterSet<CliIOSet>();

    protected override void RegisterConsoleOutput() => 
        RegisterSet<LogTableSet>();

    protected override void RegisterDataMappings()
    {
        RegisterSet<AppMappings>();
        RegisterSet<DataFilter>();        
    }

    protected override void RegisterCommands() => 
        RegisterSet<AppCommands>();

    protected override void RegisterProgram()
    {
        RegisterSet<AppProgSet<AppProg>>();
    }
}