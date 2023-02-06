using CLIFramework;
using CLIWizardHelper;
using Log.Data;

namespace Log.Console.Lib;

public class PlaceInsertCommand 
    : InsertCommand<Place>
{
    public PlaceInsertCommand(
        TextCommand textCommand
        , IInsertWizard<Place> modelAInsertCommand) 
            : base(textCommand, modelAInsertCommand)
    {
    }
}