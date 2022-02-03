using CRUDCommandHelper;
using DIHelper.Unity;
using Log.Modern.Lib;
using Unity;

namespace Log.Modern.ConsoleApp;

public class AppCommands 
    : UnityDependencySuite
{
    public AppCommands(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        RegisterReadCommands();
        RegisterInsertCommands();
        RegisterUpdateCommands();
    }

    private void RegisterReadCommands()
    {
        Container.RegisterSingleton<IReadCommand<PlaceArgFilter>, PlaceReadCommand>();
        Container.RegisterSingleton<IReadCommand<CategoryArgFilter>, CategoryReadCommand>();
        Container.RegisterSingleton<IReadCommand<TaskArgFilter>, TaskReadCommand>();
        Container.RegisterSingleton<IReadCommand<LogArgFilter>, LogReadCommand>();
    }

    private void RegisterInsertCommands()
    {
        Container.RegisterSingleton<IInsertCommand<PlaceArg>, PlaceInsertCommand>();
        Container.RegisterSingleton<IInsertCommand<CategoryArg>, CategoryInsertCommand>();
        Container.RegisterSingleton<IInsertCommand<Lib.TaskArg>, TaskInsertCommand>();
        Container.RegisterSingleton<IInsertCommand<Lib.LogArg>, LogInsertCommand>();
    }

    private void RegisterUpdateCommands()
    {
        Container.RegisterSingleton<IUpdateCommand<PlaceArgUpdate>, PlaceUpdateCommand>();
        Container.RegisterSingleton<IUpdateCommand<CategoryArgUpdate>, CategoryUpdateCommand>();
        Container.RegisterSingleton<IUpdateCommand<TaskArgUpdate>, TaskUpdateCommand>();
        Container.RegisterSingleton<IUpdateCommand<LogArgUpdate>, LogUpdateCommand>();
    }
}