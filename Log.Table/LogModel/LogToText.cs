using DataToTable;
using Log.Data;

namespace Log.Table;

public abstract class LogToText
    : TextTable<LogModel>
{
  protected const string DateTimeFormat = "dd.MM.yyyy HH:mm";
  protected const string DateFormat = "dd.MM.yyyy";
  protected const string TimeFormat = "HH:mm";
  protected const string HoursFormat = "0.0";

  protected LogToText(
  ITableTextEditor tableTextEditor
  , IColumnCalculator<LogModel> columnCalculator)
    : base(tableTextEditor
      , columnCalculator)
  {
  }

  protected string GetId(LogModel m) =>
    m.Id.ToString();

  protected string GetTask(LogModel m)
  {
    ArgumentNullException.ThrowIfNull(m.Task);
    ArgumentNullException.ThrowIfNull(m.Task.Name);
    return m.Task.Name;
  }

  protected string GetTaskId(LogModel m) =>
  m.TaskId.ToString();

  protected string GetCategory(LogModel m)
  {
    ArgumentNullException.ThrowIfNull(m.Task);
    ArgumentNullException.ThrowIfNull(m.Task.Category);
    ArgumentNullException.ThrowIfNull(m.Task.Category.Name);
    return m.Task.Category.Name;
  }

  protected string GetCategoryId(LogModel m)
  {
    ArgumentNullException.ThrowIfNull(m.Task);
    return m.Task.CategoryId.ToString();
  }

  protected string GetStart(LogModel m, string format) =>
  m.Start.HasValue ?
    m.Start.Value.ToString(format) : "";

  protected string GetEnd(LogModel m, string format) =>
  m.End.HasValue ?
    m.End.Value.ToString(format) : "";

  protected string GetTime(LogModel m, string format) =>
  $"{m.Time.TotalHours.ToString(format)}";

  protected string GetDescription(LogModel m) =>
    string.IsNullOrWhiteSpace(m.Description) == false ?
      m.Description : "";

  protected string GetPlace(LogModel m)
  {
    ArgumentNullException.ThrowIfNull(m.Place);
    ArgumentNullException.ThrowIfNull(m.Place.Name);
    return m.Place.Name;
  }
}