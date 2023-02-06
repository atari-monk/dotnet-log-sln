using CLIFramework;
using CLIHelper;
using CLIReader;
using CLIWizardHelper;
using CRUDCommandHelper;
using Log.Console.Lib;
using Log.Data;
using Log.Wizard.Lib;
using Serilog;
using Unity;
using Unity.Injection;
using Task = Log.Data.Task;

namespace Log.ConsoleApp;

public class AppCommands2 : AppCommands
{
    public AppCommands2(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterCommands()
    {
        base.RegisterCommands();
        RegisterTaskCommands();
        RegisterLogCommands();
    }

    private void RegisterTaskCommands()
    {
        RegisterCommand<HelpCommand<Task>, Task>(
            "Help Task".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , new string[]
            {
                nameof(Task.Name)
                , nameof(Task.Description)
                , nameof(Task.CategoryId)
            });

        Container.RegisterSingleton<IReadCommand<Console.Lib.TaskFilter>, TaskReadCmd>();

        RegisterCommand<TaskReadCommand, Task>(
            "Task".ToLowerInvariant()
            , Container.Resolve<IReadCommand<Console.Lib.TaskFilter>>());

       Container.RegisterSingleton<IInsertWizard<Task>, TaskInsertWizard>(
            nameof(TaskInsertWizard)
            , new InjectionConstructor( new object[] {
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            }));

        RegisterCommand<TaskInsertCommand, Task>(
            "Insert Task".ToLowerInvariant()
            , Container.Resolve<IInsertWizard<Task>>(
                nameof(TaskInsertWizard)));

          Container.RegisterSingleton<IUpdateWizard<Task>, TaskUpdateWizard>(
            nameof(TaskUpdateWizard)
            , new InjectionConstructor( new object[] {
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
            }));

        RegisterCommand<TaskUpdateCommand, Task>(
            "Update Task".ToLowerInvariant()
            , Container.Resolve<IUpdateWizard<Task>>(nameof(TaskUpdateWizard))
            );
    }

    private void RegisterLogCommands()
    {
        RegisterCommand<HelpCommand<LogModel>, LogModel>(
            "Help Log".ToLowerInvariant()
            , Container.Resolve<IOutput>()
            , new string[]
            {
                nameof(LogModel.TaskId)
                , nameof(LogModel.Start)
                , nameof(LogModel.Description)
                , nameof(LogModel.PlaceId)
            });

        Container.RegisterSingleton<IReadCommand<Console.Lib.LogFilter>, LogReadCmd>();

        RegisterCommand<LogReadCommand, LogModel>(
            "Log".ToLowerInvariant()
            , Container.Resolve<IReadCommand<Console.Lib.LogFilter>>()
            , Container.Resolve<IOutput>());

         Container.RegisterSingleton<IInsertWizard<LogModel>, LogInsertWizard>(
            nameof(LogInsertWizard)
            , new InjectionConstructor( new object[] {
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<IReader<string>>(nameof(OptionalTextReader))
                , Container.Resolve<ILogger>()
                , Container.Resolve<IReader<DateTime>>(nameof(RequiredDateTimeReader))
                , Container.Resolve<IReader<DateTime?>>(nameof(OptionalDateTimeReader))
            }));

        RegisterCommand<LogInsertCommand, LogModel>(
            "Insert LogModel".ToLowerInvariant()
            , Container.Resolve<IInsertWizard<LogModel>>(
                nameof(LogInsertWizard)));

          Container.RegisterSingleton<IUpdateWizard<LogModel>, LogUpdateWizard>(
            nameof(LogUpdateWizard)
            , new InjectionConstructor( new object[] {
                Container.Resolve<ILogUnitOfWork>()
                , Container.Resolve<IReader<string>>(nameof(RequiredTextReader))
                , Container.Resolve<ILogger>()
                , Container.Resolve<IReader<string>>(nameof(OptionalTextReader))
                , Container.Resolve<IReader<DateTime>>(nameof(RequiredDateTimeReader))
                , Container.Resolve<IReader<DateTime?>>(nameof(OptionalDateTimeReader))
            }));

        RegisterCommand<LogUpdateCommand, LogModel>(
            "Update LogModel".ToLowerInvariant()
            , Container.Resolve<IUpdateWizard<LogModel>>(nameof(LogUpdateWizard))
            );
    }
}