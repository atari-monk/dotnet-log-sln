using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Console.Lib;

public class CategoryReadCmd 
    : ReadCommand<ILogUnitOfWork, Category, Category>
{
    public CategoryReadCmd(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<Category> textProvider) 
            : base(unitOfWork, output, log, textProvider)
    {
    }

    protected override List<Category> Get(Category model) =>
        UnitOfWork.Category.Get().ToList();
}