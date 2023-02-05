using AutoMapper;
using Log.Data;
using Unity;
using Task = Log.Data.Task;

namespace Log.Modern.Lib.Unity;

public class AppMappings 
    : ModelHelper.AppMappings
{
    public AppMappings(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap() => 
        new (
        c =>
        {
            c.CreateMap<PlaceInsertArgs, Place>();
            c.CreateMap<CategoryInsertArgs, Category>();
            c.CreateMap<TaskInsertArgs, Task>();
            c.CreateMap<LogInsertArgs, LogModel>();

            c.CreateMap<PlaceUpdateArgs, PlaceUpdate>();
            c.CreateMap<CategoryUpdateArgs, CategoryUpdate>();
            c.CreateMap<TaskUpdateArgs, TaskUpdate>();
            c.CreateMap<LogUpdateResetArgs, LogUpdate>();
        });
}