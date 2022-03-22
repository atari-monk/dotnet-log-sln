using AutoMapper;
using Log.Data;
using Unity;

namespace Log.Modern.ConsoleApp;

public class AppMappings 
    : ModelHelper.AppMappings
{
    public AppMappings(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap()
    {
        var config = new MapperConfiguration(c => {
            c.CreateMap<Lib.PlaceArg, Place>();
            c.CreateMap<Lib.CategoryArg, Category>();
            c.CreateMap<Lib.TaskArg, Data.Task>();
            c.CreateMap<Lib.LogArg, LogModel>();

            c.CreateMap<Lib.PlaceArgUpdate, PlaceUpdate>();
            c.CreateMap<Lib.CategoryArgUpdate, CategoryUpdate>();
            c.CreateMap<Lib.TaskArgUpdate, TaskUpdate>();
            c.CreateMap<Lib.LogArgUpdateReset, LogUpdate>();
        });
        return config; 
    }
}