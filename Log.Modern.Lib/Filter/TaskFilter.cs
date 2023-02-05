using System.Linq.Expressions;
using Task = Log.Data.Task;

namespace Log.Modern.Lib;

public class TaskFilter 
    : IFilterFactory<Task, TaskFilterArgs>
{
    public Expression<Func<Task, bool>>? GetFilter(
        TaskFilterArgs filter)
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