using CLIFramework;
using CRUDCommandHelper;
using Log.Data;

namespace Log.Console.Lib;

public class PlaceReadCommand 
    : ReadCommand<Place>
{
    public PlaceReadCommand(
        TextCommand textCommand
        , IReadCommand<Place> entityReadCommand) 
            : base(textCommand, entityReadCommand)
    {
    }
}