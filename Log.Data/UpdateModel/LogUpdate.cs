namespace Log.Data;

public class LogUpdate 
    : LogReset
{
    public int? TaskId { get; set; }

    public DateTime? Start { get; set; }

    public DateTime? End { get; set; }

    public string? Description { get; set; }

    public int? PlaceId { get; set; }

    public override void Update(LogModel model)
    {
        base.Update(model);
        if (TaskId.HasValue
            && TaskId.Value != model.TaskId)
                model.TaskId = TaskId.Value;
        if (Start.HasValue
            && Start.Value != model.Start)
                model.Start = Start.Value;
        if (End.HasValue
            && End.Value != model.End)
                model.End = End.Value;
        if (string.IsNullOrWhiteSpace(Description) == false
            && Description.Trim() != model.Description?.Trim())
                model.Description = Description;
        if (PlaceId.HasValue
            && PlaceId.Value != model.PlaceId)
                model.PlaceId = PlaceId.Value;
        model.SetTimeTicks();
    }
}