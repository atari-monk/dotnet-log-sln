using System.Linq.Expressions;

namespace Log.Console.Lib;

public class TaskFiltrator 
    : IFilterFactory<Data.Task, TaskFilter>
{
    public Expression<Func<Data.Task, bool>>? GetFilter(
        TaskFilter filter)
    {
        if(filter.CategoryId.HasValue 
            && string.IsNullOrWhiteSpace(filter.Name) == false)
        {
            return task => 
                task.CategoryId == filter.CategoryId.Value
                && string.IsNullOrWhiteSpace(task.Name) == false
                && task.Name.Contains(filter.Name);
        }
        if(filter.CategoryId.HasValue)
            return task => task.CategoryId == filter.CategoryId.Value;
        if(string.IsNullOrWhiteSpace(filter.Name) == false)
            return task =>
                string.IsNullOrWhiteSpace(task.Name) == false
                && task.Name.Contains(filter.Name);
        return default;
    }
}