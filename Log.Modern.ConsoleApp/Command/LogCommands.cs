using CommandDotNet;
using CRUDCommandHelper;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(MainCommand)]
public class LogCommands : Commands
{
    private const string MainCommand = "log";

    private readonly IReadCommand<LogArgFilter> readCommand;
    private readonly IInsertCommand<LogArg> insertCommand;
    private readonly IUpdateCommand<LogArgUpdate> updateCommand;

    public LogCommands(
        IReadCommand<LogArgFilter> readCommand
        , IInsertCommand<LogArg> insertCommand
        , IUpdateCommand<LogArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;
    }

    [DefaultCommand()]
    public void Read(LogArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(LogArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new LogArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(LogArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}