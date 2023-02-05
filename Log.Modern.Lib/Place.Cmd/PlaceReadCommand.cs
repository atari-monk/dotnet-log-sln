using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class PlaceReadCommand
    : ReadCommand<ILogUnitOfWork, Data.Place, PlaceFilterArgs>
{
    public PlaceReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<Data.Place> textProvider) 
            : base(unitOfWork, output, log, textProvider)
    {
    }

    protected override List<Data.Place> Get(PlaceFilterArgs model) =>
        UnitOfWork.Place.Get().ToList();
}