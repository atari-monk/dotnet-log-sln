using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Console.Lib;

public class PlaceReadCmd
    : ReadCommand<ILogUnitOfWork, Place, Place>
{
    public PlaceReadCmd(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<Place> textProvider) 
            : base(unitOfWork, output, log, textProvider)
    {
    }

    protected override List<Place> Get(Place model) =>
        UnitOfWork.Place.Get().ToList();
}