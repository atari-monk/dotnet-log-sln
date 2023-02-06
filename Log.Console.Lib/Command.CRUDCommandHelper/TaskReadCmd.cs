using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Console.Lib;

public class TaskReadCmd
    : ReadCommand<ILogUnitOfWork, Data.Task, TaskFilter>
{
    private readonly IFilterFactory<Data.Task, TaskFilter> filterFactory;

    public TaskReadCmd(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<Data.Task> textProvider
        , IFilterFactory<Data.Task, TaskFilter> filterFactory) 
            : base(unitOfWork, output, log, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<Data.Task> Get(TaskFilter model)
    {
        return UnitOfWork.Task.Get(
            filterFactory.GetFilter(model)
            , orderBy: t => t.OrderBy(p => p.Category!.Name)
            , includeProperties: "Category").ToList();
    }
}