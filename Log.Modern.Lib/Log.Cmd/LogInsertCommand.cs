using AutoMapper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class LogInsertCommand
    : InsertCommand<ILogUnitOfWork, LogModel, LogInsertArgs>
{
    public LogInsertCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override void InsertEntity(LogModel entity)
    {
        entity.SetTimeTicks();
        UnitOfWork.Log.Insert(entity);
    }
}