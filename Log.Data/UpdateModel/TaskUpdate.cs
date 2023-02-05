using ModelHelper;

namespace Log.Data;

public class TaskUpdate 
    : ModelAUpdate
    , IUpdatable<Task>
{
    public int? CategoryId { get; set; }

    public void Update(Task model)
    {
        base.Update(model);
        if(CategoryId.HasValue 
            && CategoryId.Value != model.CategoryId)
                model.CategoryId = CategoryId.Value;
    }
}