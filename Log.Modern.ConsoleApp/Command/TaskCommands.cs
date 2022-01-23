using CLI.Core.Lib;
using CommandDotNet;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(MainCommand)]
public class TaskCommands : Commands
{
    private const string MainCommand = "task";

    private readonly IReadCommand<TaskArgFilter> readCommand;
    private readonly IInsertCommand<TaskArg> insertCommand;
    private readonly IUpdateCommand<TaskArgUpdate> updateCommand;

    public TaskCommands(
        IReadCommand<TaskArgFilter> readCommand
        , IInsertCommand<TaskArg> insertCommand
        , IUpdateCommand<TaskArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;
    }

    [DefaultCommand()]
    public void Read(TaskArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(TaskArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new TaskArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(TaskArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}