using AutoMapper;
using Log.Data;
using Unity;

namespace Log.Modern.ConsoleApp;

public class AppMappings 
    : DIHelper.Unity.AppMappings
{
    public AppMappings(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override MapperConfiguration CreateMap()
    {
        var config = new MapperConfiguration(cfg => {
            cfg.CreateMap<Lib.PlaceArg, Place>();
            cfg.CreateMap<Lib.CategoryArg, Category>();
            cfg.CreateMap<Lib.TaskArg, Data.Task>();
            cfg.CreateMap<Lib.LogArg, LogModel>();

            cfg.CreateMap<Lib.PlaceArgUpdate, PlaceUpdate>();
            cfg.CreateMap<Lib.CategoryArgUpdate, CategoryUpdate>();
            cfg.CreateMap<Lib.TaskArgUpdate, TaskUpdate>();
            cfg.CreateMap<Lib.LogArgUpdateReset, LogUpdate>();
        });
        return config; 
    }
}