using CLIHelper;
using CRUDCommandHelper;
using Log.Data;
using Log.Table;
using Serilog;

namespace Log.Modern.Lib;

public class LogSumTimeCommand
    : ReadCommand<ILogUnitOfWork, LogModel, LogFilterArgs>
      , ISumTimeCmd<LogFilterArgs>
{
  private readonly IFilterFactory<LogModel, LogFilterArgs> filterFactory;

  public LogSumTimeCommand(
      ILogUnitOfWork unitOfWork
      , IOutput output
      , ILogger log
      , ILogTimeSumTable textProvider
      , IFilterFactory<LogModel, LogFilterArgs> filterFactory)
          : base(unitOfWork, output, log, textProvider)
  {
    this.filterFactory = filterFactory;
  }

  protected override List<LogModel> Get(LogFilterArgs model)
  {
    var logs = UnitOfWork.Log.GetLog(
        filterFactory.GetFilter(model)).ToList();
    var name = logs[0].Task?.Name;
    var start = logs[0].Start;
    var stop = logs.Last().Start;
    var timeSum = new TimeSpan(logs.Sum(l => l.Time.Ticks));
    return new List<LogModel> {
      new LogModel() {
        Start = start
        , End = stop
        ,Time = timeSum
        , Task = new Data.Task{ Name = name
          , Category = new Category { Name = "" } }
        , Place = new Place { Name = "" } } };
  }
}