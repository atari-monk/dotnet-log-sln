using CLIHelper;
using CRUDCommandHelper;
using DataToTable;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class CategoryReadCommand 
    : ReadCommand<ILogUnitOfWork, Data.Category, CategoryFilterArgs>
{
    public CategoryReadCommand(
        ILogUnitOfWork unitOfWork
        , IOutput output
        , ILogger log
        , IDataToText<Data.Category> textProvider) 
            : base(unitOfWork, output, log, textProvider)
    {
    }

    protected override List<Data.Category> Get(CategoryFilterArgs model) =>
        UnitOfWork.Category.Get().ToList();
}