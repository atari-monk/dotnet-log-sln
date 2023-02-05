using AutoMapper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class TaskUpdateCommand
    : UpdateCommand<ILogUnitOfWork, Data.Task, TaskUpdateArgs, Data.TaskUpdate>
{
    public TaskUpdateCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override Data.Task GetById(int id) =>
        UnitOfWork.Task.GetById(id) ?? new Data.Task();
}