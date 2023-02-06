using CLIFramework;
using CLIHelper.Unity;
using CLIReader;
using Config.Wrapper.Unity;
using Log.Table.Unity;
using Serilog.Wrapper.Unity;
using Unity;

namespace Log.ConsoleApp;

public class UnityDependencySuite
    : CLIFramework.UnityDependencySuite
{
    public UnityDependencySuite(
        IUnityContainer container) 
        : base(container) 
    {
    }

    protected override void RegisterAppData()
    {
        RegisterSet<SerilogSet>();
        RegisterSet<AppConfigSet>();
        RegisterSet<AppData>();
        Container.RegisterSingleton<ISwitcher, Switcher>("LoopSwitch");
        RegisterSet<DataFilter>();
    }

    protected override void RegisterDatabase() => 
        RegisterSet<AppDatabase>();
        
    protected override void RegisterConsoleInput()
    {
        RegisterSet<CliIOSet>();
        RegisterSet<CLIReaderSet>();
    }

    protected override void RegisterConsoleOutput() => 
        RegisterSet<LogTableSet>();

    protected override void RegisterCommands() => 
        RegisterSet<AppCommands2>();
    
    protected override void RegisterCommandSystem() => 
		RegisterSet<AppCommandSystem<ParamCommandParser>>();
}