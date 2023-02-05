using CLIHelper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class CategoryDeleteCommand
    : DeleteCommand<ILogUnitOfWork, Data.Category, DeleteArgs>
{
    public CategoryDeleteCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IInput input) 
            : base(unitOfWork, log, input)
    {
    }

    protected override void DeleteEntity(Category entity)
    {
        UnitOfWork.Category.Delete(entity);
    }

    protected override Data.Category GetById(int id) =>
        UnitOfWork.Category.GetById(id) ?? new Category();
}