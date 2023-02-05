using DIHelper.MicrosoftDI;
using Log.Data;
using Microsoft.Extensions.DependencyInjection;

namespace Log.Modern.Lib.MDI;

public class DataFilter 
    : MDIDependencySet
{
    public DataFilter(
        IServiceCollection container) 
            : base(container)
    {
    }

    public override void Register()
    {
        Container
            .AddSingleton<
                IFilterFactory<LogModel, LogFilterArgs>
                , LogFilter>()
            .AddSingleton<
                IFilterFactory<Data.Task, TaskFilterArgs>
                , TaskFilter>();
    }
}