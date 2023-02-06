using CLIFramework;
using CLIWizardHelper;
using Log.Data;

namespace Log.Console.Lib;

public class PlaceUpdateCommand 
    : UpdateCommand<Place>
{
    public PlaceUpdateCommand(
        TextCommand textCommand
        , IUpdateWizard<Place> modelAUpdateWizard) 
            : base(textCommand, modelAUpdateWizard)
    {
    }
}