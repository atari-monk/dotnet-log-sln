using DataToTable;
using Log.Data;

namespace Log.Table;

public abstract class LogToColumn : LogToText
{
  protected LogToColumn(
  ITableTextEditor tableTextEditor
  , IColumnCalculator<LogModel> columnCalculator)
    : base(tableTextEditor
      , columnCalculator)
  {
  }

  protected List<int> GetIdLengths(List<LogModel> models)
  {
    var rows = models.Select(m => GetId(m).Length).ToList();
    rows.Insert(0, nameof(LogModel.Id).Length);
    return rows;
  }

  protected List<int> GetTaskLengths(List<LogModel> models)
  {
    var rows = models.Select(m => GetTask(m).Length).ToList();
    rows.Insert(0, nameof(LogModel.Task).Length);
    return rows;
  }

  protected List<int> GetTaskIdLengths(List<LogModel> models)
  {
    var rows = models.Select(m => GetTaskId(m).Length).ToList();
    rows.Insert(0, nameof(LogModel.TaskId).Length);
    return rows;
  }

  protected List<int> GetCategoryLengths(List<LogModel> models)
  {
    var rows = models.Select(m => GetCategory(m).Length).ToList();
    rows.Insert(0, nameof(LogModel.Task.Category).Length);
    return rows;
  }

  protected List<int> GetCategoryIdLengths(List<LogModel> models)
  {
    var rows = models.Select(m => GetCategoryId(m).Length).ToList();
    rows.Insert(0, nameof(LogModel.Task.CategoryId).Length);
    return rows;
  }

  protected List<int> GetStartLengths(List<LogModel> models, string format)
  {
    var rows = models.Select(e => GetStart(e, format).Length).ToList();
    rows.Insert(0, nameof(LogModel.Start).Length);
    return rows;
  }

  protected List<int> GetEndLengths(List<LogModel> models, string format)
  {
    var rows = models.Select(m => GetEnd(m, format).Length).ToList();
    rows.Insert(0, nameof(LogModel.End).Length);
    return rows;
  }

  protected List<int> GetTimeLengths(List<LogModel> models, string format)
  {
    var rows = models.Select(m => GetTime(m, format).Length).ToList();
    rows.Insert(0, nameof(LogModel.Time).Length);
    return rows;
  }

  protected List<int> GetDescriptionLengths(List<LogModel> models)
  {
    var rows = models.Select(m => GetDescription(m).Length).ToList();
    rows.Insert(0, nameof(LogModel.Description).Length);
    return rows;
  }

  protected List<int> GetPlaceLengths(List<LogModel> models)
  {
    var rows = models.Select(m => GetPlace(m).Length).ToList();
    rows.Insert(0, nameof(LogModel.Place).Length);
    return rows;
  }
}