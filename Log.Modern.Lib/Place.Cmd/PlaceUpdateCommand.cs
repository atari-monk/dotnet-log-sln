using AutoMapper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class PlaceUpdateCommand
    : UpdateCommand<ILogUnitOfWork, Data.Place, PlaceUpdateArgs, Data.PlaceUpdate>
{
    public PlaceUpdateCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper)
            : base(unitOfWork, log, mapper)
    {
    }

    protected override Data.Place GetById(int id) =>
        UnitOfWork.Place.GetById(id) ?? new Place();
}