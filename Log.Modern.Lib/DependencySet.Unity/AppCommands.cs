using CRUDCommandHelper;
using DIHelper.Unity;
using Unity;

namespace Log.Modern.Lib.Unity;

public class AppCommands 
    : UnityDependencySet
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
        RegisterDeleteCommands();
    }

    private void RegisterReadCommands()
    {
        Container
            .RegisterSingleton<IReadCommand<PlaceFilterArgs>, PlaceReadCommand>()
            .RegisterSingleton<IReadCommand<CategoryFilterArgs>, CategoryReadCommand>()
            .RegisterSingleton<IReadCommand<TaskFilterArgs>, TaskReadCommand>()
            .RegisterSingleton<IReadCommand<LogFilterArgs>, LogReadCommand>()
            .RegisterSingleton<ISumTimeCmd<LogFilterArgs>, LogSumTimeCommand>();
    }

    private void RegisterInsertCommands()
    {
        Container
            .RegisterSingleton<IInsertCommand<PlaceInsertArgs>, PlaceInsertCommand>()
            .RegisterSingleton<IInsertCommand<CategoryInsertArgs>, CategoryInsertCommand>()
            .RegisterSingleton<IInsertCommand<Lib.TaskInsertArgs>, TaskInsertCommand>()
            .RegisterSingleton<IInsertCommand<Lib.LogInsertArgs>, LogInsertCommand>();
    }

    private void RegisterUpdateCommands()
    {
        Container
            .RegisterSingleton<IUpdateCommand<PlaceUpdateArgs>, PlaceUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<CategoryUpdateArgs>, CategoryUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<TaskUpdateArgs>, TaskUpdateCommand>()
            .RegisterSingleton<IUpdateCommand<LogUpdateResetArgs>, LogUpdateCommand>();
    }

    private void RegisterDeleteCommands()
    {
        Container
            .RegisterSingleton<IDeleteCommand<DeleteArgs>, CategoryDeleteCommand>()
            .RegisterSingleton<IDeleteCommand<DeleteArgs>, LogDeleteCommand>();
    }
}