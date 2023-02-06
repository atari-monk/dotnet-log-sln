using CLIFramework;
using CRUDCommandHelper;
using Log.Data;

namespace Log.Console.Lib;

public class CategoryReadCommand 
    : ReadCommand<Category>
{
    public CategoryReadCommand(
        TextCommand textCommand
        , IReadCommand<Category> readCommand) 
            : base(textCommand, readCommand)
    {
    }
}