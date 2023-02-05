using EFCore.Helper;
using System.Linq.Expressions;

namespace Log.Data;

public class LogRepo 
    : EFRepository<LogModel, LogDbContext>
    , ILogRepo
{
    public LogRepo(LogDbContext context) : base(context)
    {
    }

    public IEnumerable<LogModel> GetLog(
        Expression<Func<LogModel, bool>>? filter)
    {
        return Get(
            filter
            , orderBy: (l) => l.OrderBy((ls) => ls.Start)
                .ThenBy((le) => le.End)
            , includeProperties: "Task,Place,Task.Category");
    }
}