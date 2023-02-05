using EFCore.Helper;
using System.Linq.Expressions;

namespace Log.Data;

public interface ILogRepo 
    : IRepository<LogModel>
{
	IEnumerable<LogModel> GetLog(
        Expression<Func<LogModel, bool>>? filter);
}