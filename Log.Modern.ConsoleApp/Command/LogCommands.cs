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
  private readonly IReadCommand<LogFilterArgs> sumTime;
  private readonly IInsertCommand<LogInsertArgs> insert;
  private readonly IUpdateCommand<LogUpdateResetArgs> update;
  private readonly IDeleteCommand<DeleteArgs> delete;

  public LogCommands(
      IReadCommand<LogFilterArgs> read
      , ISumTimeCmd<LogFilterArgs> sumTime
      , IInsertCommand<LogInsertArgs> insert
      , IUpdateCommand<LogUpdateResetArgs> update
      , IDeleteCommand<DeleteArgs> delete)
  {
    this.read = read;
    this.sumTime = sumTime;
    this.insert = insert;
    this.update = update;
    this.delete = delete;
  }

  [DefaultCommand()]
  public void Read(LogFilterArgs model)
  {
    read.Read(model);
  }

  [Command("sumtime")]
  public void SumTime(LogFilterArgs model)
  {
    sumTime.Read(model);
  }

  [Command(InsertCmd)]
  public void Insert(LogInsertArgs model)
  {
    insert.Insert(model);
    ReadAfterChange();
  }

  private void ReadAfterChange()
  {
    read.Read(new LogFilterArgs());
  }

  [Command(UpdateCmd)]
  public void Update(LogUpdateResetArgs model)
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