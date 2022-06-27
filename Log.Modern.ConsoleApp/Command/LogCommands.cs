using CommandDotNet;
using CRUDCommandHelper;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(MainCommand)]
public class LogCommands : Commands
{
    private const string MainCommand = "log";

    private readonly IReadCommand<LogFilterArgs> readCommand;
    private readonly IInsertCommand<LogArg> insertCommand;
    private readonly IUpdateCommand<LogArgUpdateReset> updateCommand;

    public LogCommands(
        IReadCommand<LogFilterArgs> readCommand
        , IInsertCommand<LogArg> insertCommand
        , IUpdateCommand<LogArgUpdateReset> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;
    }

    [DefaultCommand()]
    public void Read(LogFilterArgs model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCmd)]
    public void Insert(LogArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new LogFilterArgs());
    }

    [Command(UpdateCmd)]
    public void Update(LogArgUpdateReset model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}