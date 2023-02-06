using CLIFramework;
using CLIWizardHelper;
using Log.Data;

namespace Log.Console.Lib;

public class CategoryInsertCommand 
    : InsertCommand<Category>
{
    public CategoryInsertCommand(
        TextCommand textCommand
        , IInsertWizard<Category> categoryWizard)
            : base(textCommand, categoryWizard)
    {
    }
}