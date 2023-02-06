using System.Linq.Expressions;
using Log.Data;

namespace Log.Console.Lib;

public class LogFiltrator 
    : IFilterFactory<LogModel, LogFilter>
{
    public Expression<Func<LogModel, bool>>? GetFilter(
        LogFilter filter)
    {
        var dateFilter = filter.Start.HasValue ? 
            filter.Start.Value.Date : DateTime.Now.Date;

        if(filter.CategoryId.HasValue)
        {
            return l => 
                l.Start.HasValue ? 
                    l.Start.Value.Date.Equals(dateFilter)  
                        && l.Task!.CategoryId == filter.CategoryId.Value : 
                    l.Task!.CategoryId == filter.CategoryId.Value;
        }
        return l => 
            l.Start.HasValue ? 
                l.Start.Value.Date.Equals(dateFilter) : true;
    }
}