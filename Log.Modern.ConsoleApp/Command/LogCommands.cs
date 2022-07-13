using CommandDotNet;
using CRUDCommandHelper;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(MainCommand)]
public class LogCommands
    : Commands
{
    private const string MainCommand = "log";

    private readonly IReadCommand<LogFilterArgs> read;
    private readonly IInsertCommand<LogArg> insert;
    private readonly IUpdateCommand<LogArgUpdateReset> update;
    private readonly IDeleteCommand<DeleteArgs> delete;

    public LogCommands(
        IReadCommand<LogFilterArgs> read
        , IInsertCommand<LogArg> insert
        , IUpdateCommand<LogArgUpdateReset> update
        , IDeleteCommand<DeleteArgs> delete)
    {
        this.read = read;
        this.insert = insert;
        this.update = update;
        this.delete = delete;
    }

    [DefaultCommand()]
    public void Read(LogFilterArgs model)
    {
        read.Read(model);
    }

    [Command(InsertCmd)]
    public void Insert(LogArg model)
    {
        insert.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        read.Read(new LogFilterArgs());
    }

    [Command(UpdateCmd)]
    public void Update(LogArgUpdateReset model)
    {
        update.Update(model);
        ReadAfterChange();
    }

    [Command(DeleteCmd)]
    public void Delete(DeleteArgs model)
    {
        delete.Delete(model);
        ReadAfterChange();
    }
}