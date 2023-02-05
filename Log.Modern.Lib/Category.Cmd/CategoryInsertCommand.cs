using AutoMapper;
using CRUDCommandHelper;
using Log.Data;
using Serilog;

namespace Log.Modern.Lib;

public class CategoryInsertCommand
    : InsertCommand<ILogUnitOfWork, Data.Category, CategoryInsertArgs>
{
    public CategoryInsertCommand(
        ILogUnitOfWork unitOfWork
        , ILogger log
        , IMapper mapper) 
            : base(unitOfWork, log, mapper)
    {
    }

    protected override void InsertEntity(Data.Category entity) =>
        UnitOfWork.Category.Insert(entity);
}