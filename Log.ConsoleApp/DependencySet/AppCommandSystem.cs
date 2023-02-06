using CLIFramework;
using Log.Console.Lib;
using Unity;

namespace Log.ConsoleApp;

public class AppCommandSystem<TParser> 
    : CLIFramework.AppCommandSystem<TParser>
        where TParser : ICommandParser
{
    private ICommandRunner? commandRunner;

    public AppCommandSystem(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void SetCommandDependencies()
    {
        commandRunner = Container.Resolve<ICommandRunner>();
        ArgumentNullException.ThrowIfNull(commandRunner);
        SetCommandRunner<PlaceInsertCommand>("insert place");
        SetCommandRunner<PlaceUpdateCommand>("update place");
        SetCommandRunner<CategoryInsertCommand>("insert category");
        SetCommandRunner<CategoryUpdateCommand>("update category");
        SetCommandRunner<TaskInsertCommand>("insert task");
        SetCommandRunner<TaskUpdateCommand>("update task");
        SetCommandRunner<LogInsertCommand>("insert log");
        SetCommandRunner<LogUpdateCommand>("update log");
    }

    private void SetCommandRunner<TCmdType>(string key)
        where TCmdType : class, IDataCommand
    {
        var cmd = Container.Resolve<IAppCommand>(key) as TCmdType;
        ArgumentNullException.ThrowIfNull(cmd);
        cmd.SetCommandRunner(commandRunner!);
    }
}