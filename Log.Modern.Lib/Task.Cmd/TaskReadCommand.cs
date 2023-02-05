using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class TaskReadCommand 
    : ReadCommand<ILogUnitOfWork, Data.Task, TaskFilterArgs>
{
    private readonly IFilterFactory<Data.Task, TaskFilterArgs> filterFactory;

    public TaskReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<Data.Task> textProvider
        , IFilterFactory<Data.Task, TaskFilterArgs> filterFactory) 
            : base(unitOfWork, output, log, textProvider)
    {
        this.filterFactory = filterFactory;
    }

    protected override List<Data.Task> Get(TaskFilterArgs model)
    {
        return UnitOfWork.Task.Get(
            filterFactory.GetFilter(model)
            , orderBy: t => t.OrderBy(p => p.Category!.Name)
            , includeProperties: nameof(Data.Task.Category)).ToList();
    }
}