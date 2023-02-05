using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class LogReadCommand
    : ReadCommand<ILogUnitOfWork, LogModel, LogFilterArgs>
{
    private readonly IFilterFactory<LogModel, LogFilterArgs> filterFactory;

    public LogReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<LogModel> textProvider
        , IFilterFactory<LogModel, LogFilterArgs> filterFactory)
            : base(unitOfWork, output, log, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<LogModel> Get(LogFilterArgs model)
    {
        return UnitOfWork.Log.GetLog(
            filterFactory.GetFilter(model)).ToList();
    }
}