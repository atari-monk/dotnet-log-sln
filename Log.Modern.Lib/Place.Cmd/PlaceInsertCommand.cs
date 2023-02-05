using AutoMapper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class PlaceInsertCommand
    : InsertCommand<ILogUnitOfWork, Data.Place, PlaceInsertArgs>
{
    public PlaceInsertCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override void InsertEntity(Data.Place entity) =>
        UnitOfWork.Place.Insert(entity);
}