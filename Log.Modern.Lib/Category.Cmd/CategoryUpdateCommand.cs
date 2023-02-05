using AutoMapper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class CategoryUpdateCommand
    : UpdateCommand<ILogUnitOfWork, Data.Category, CategoryUpdateArgs, Data.CategoryUpdate>
{
    public CategoryUpdateCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper) 
            : base(unitOfWork, log, mapper)
    {
    }

    protected override Data.Category GetById(int id) =>
        UnitOfWork.Category.GetById(id) ?? new Category();
}