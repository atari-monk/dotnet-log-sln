using ModelHelper;

namespace Log.Data;

public class LogReset 
    : IUpdatable<LogModel>
{
    public bool? ResetStart { get; set; }

    public bool? ResetEnd { get; set; }

    public virtual void Update(LogModel model)
    {
        if (ResetStart.HasValue && ResetStart.Value)
        {
            model.Start = null;
        }
        if (ResetEnd.HasValue && ResetEnd.Value)
        {
            model.End = null;
        }
    }
}