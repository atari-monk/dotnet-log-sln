using CLIFramework;
using CLIWizardHelper;
using Log.Data;

namespace Log.Console.Lib;

public class CategoryUpdateCommand 
    : UpdateCommand<Category>
{
    public CategoryUpdateCommand(
        TextCommand textCommand
        , IUpdateWizard<Category> modelAUpdateWizard) 
            : base(textCommand
                , modelAUpdateWizard)
    {
    }
}