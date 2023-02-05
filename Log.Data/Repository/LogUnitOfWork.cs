using EFCore.Helper;

namespace Log.Data;

public class LogUnitOfWork
    : UnitOfWork
        , ILogUnitOfWork
{
    private readonly IRepository<Category> category;
    private readonly IRepository<Place> place;
    private readonly IRepository<Task> task;
    private readonly ILogRepo log;

    public IRepository<Category> Category => category;

    public IRepository<Place> Place => place;

    public IRepository<Task> Task => task;

    public ILogRepo Log => log;

    public LogUnitOfWork(
        LogDbContext context
        , IRepository<Category> category
        , IRepository<Place> place
        , IRepository<Task> task
        , ILogRepo log)
            : base(context)
    {
        this.category = category;
        ArgumentNullException.ThrowIfNull(this.category);
        this.place = place;
        ArgumentNullException.ThrowIfNull(this.place);
        this.task = task;
        ArgumentNullException.ThrowIfNull(this.task);
        this.log = log;
        ArgumentNullException.ThrowIfNull(this.log);
    }
}