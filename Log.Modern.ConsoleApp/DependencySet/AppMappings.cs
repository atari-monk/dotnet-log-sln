using AutoMapper;
using Log.Data;
using Log.Modern.Lib;
using Unity;
using Task = Log.Data.Task;

namespace Log.Modern.ConsoleApp;

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
            c.CreateMap<PlaceArg, Place>();
            c.CreateMap<CategoryArg, Category>();
            c.CreateMap<TaskArg, Task>();
            c.CreateMap<LogArg, LogModel>();

            c.CreateMap<PlaceArgUpdate, PlaceUpdate>();
            c.CreateMap<CategoryArgUpdate, CategoryUpdate>();
            c.CreateMap<TaskArgUpdate, TaskUpdate>();
            c.CreateMap<LogArgUpdateReset, LogUpdate>();
        });
}