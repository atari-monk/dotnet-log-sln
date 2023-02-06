using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Console.Lib;

public class LogReadCmd
    : ReadCommand<ILogUnitOfWork, LogModel, LogFilter>
{
    private readonly IFilterFactory<LogModel, LogFilter> filterFactory;

    public LogReadCmd(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<LogModel> textProvider
        , IFilterFactory<LogModel, LogFilter> filterFactory)
            : base(unitOfWork, output, log, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<LogModel> Get(LogFilter model)
    {
        return UnitOfWork.Log.GetLog(
            filterFactory.GetFilter(model)).ToList();
    }
}