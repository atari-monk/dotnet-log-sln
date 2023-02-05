using AutoMapper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class TaskInsertCommand
    : InsertCommand<ILogUnitOfWork, Data.Task, TaskInsertArgs>
{
    public TaskInsertCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override void InsertEntity(Data.Task entity) =>
        UnitOfWork.Task.Insert(entity);
}