using CommandDotNet;
using CRUDCommandHelper;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(MainCommand)]
public class TaskCommands : Commands
{
    private const string MainCommand = "task";

    private readonly IReadCommand<TaskFilterArgs> readCommand;
    private readonly IInsertCommand<TaskInsertArgs> insertCommand;
    private readonly IUpdateCommand<TaskUpdateArgs> updateCommand;

    public TaskCommands(
        IReadCommand<TaskFilterArgs> readCommand
        , IInsertCommand<TaskInsertArgs> insertCommand
        , IUpdateCommand<TaskUpdateArgs> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;
    }

    [DefaultCommand()]
    public void Read(TaskFilterArgs model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCmd)]
    public void Insert(TaskInsertArgs model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new TaskFilterArgs());
    }

    [Command(UpdateCmd)]
    public void Update(TaskUpdateArgs model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}