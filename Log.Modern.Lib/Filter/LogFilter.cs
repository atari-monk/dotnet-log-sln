using System.Linq.Expressions;
using Log.Data;

namespace Log.Modern.Lib;

public class LogFilter 
    : IFilterFactory<LogModel, LogFilterArgs>
{
    private LogFilterArgs? filterArgs;
    private DateTime dateFilter;

    private LogFilterArgs FilterArgs
    {
        get
        {
            ArgumentNullException.ThrowIfNull(filterArgs);
            return filterArgs;
        }
    }

    private int FilterTaskId
    {
        get
        {
            ArgumentNullException.ThrowIfNull(FilterArgs.TaskId);
            return FilterArgs.TaskId.Value;
        }
    }

    private int FilterCategoryId
    {
        get
        {
            ArgumentNullException.ThrowIfNull(FilterArgs.CategoryId);
            return FilterArgs.CategoryId.Value;
        }
    }

    public Expression<Func<LogModel, bool>>? GetFilter(
        LogFilterArgs filterArgs)
    {
        SetFilter(filterArgs);
        if(IsToDoFilterOn())
            return GetToDoFilter();
        if(IsTaskFiltered())
            return GetFilterByTask();
        SetStartFilterValue();
        return IsCategoryFiltered() ?
            GetFilterByStartAndCategory()
            : GetFilterByStart();
    }

    private void SetFilter(LogFilterArgs filterArgs)
    {
        this.filterArgs = filterArgs;
    }

    private bool IsToDoFilterOn()
    {
        return FilterArgs.ToDoLogs;
    }

    private Expression<Func<LogModel, bool>>? GetToDoFilter()
    {
        return l => l.Start.HasValue == false && l.End.HasValue == false;
    }

    private void SetStartFilterValue()
    {
        dateFilter = FilterArgs.Start.HasValue ?
            FilterArgs.Start.Value.Date 
            : DateTime.Now.Date;
    }

    private bool IsTaskFiltered()
    {
        return FilterArgs.TaskId.HasValue;
    } 

    private Expression<Func<LogModel, bool>>? GetFilterByTask()
    {
        return l => l.TaskId == FilterTaskId;
    }

    private bool IsCategoryFiltered()
    {
        return FilterArgs.CategoryId.HasValue;
    }

    private Expression<Func<LogModel, bool>> GetFilterByStartAndCategory()
    {
        return l => l.Start.HasValue
            && l.Start.Value.Date.Equals(dateFilter)
            && l.Task!.CategoryId == FilterCategoryId;
    }

    private Expression<Func<LogModel, bool>> GetFilterByStart()
    {
        return l => l.Start.HasValue
            && l.Start.Value.Date.Equals(dateFilter);
    }    
}