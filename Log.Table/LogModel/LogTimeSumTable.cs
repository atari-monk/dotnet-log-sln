using DataToTable;
using Log.Data;

namespace Log.Table;

public class LogTimeSumTable
  : LogTableProvider
    , ILogTimeSumTable
{
  public LogTimeSumTable(
    ITableTextEditor tableTextEditor
    , IColumnCalculator<LogModel> columnCalculator)
      : base(tableTextEditor, columnCalculator)
  {
    StartFormat = DateFormat;
    EndFormat = DateFormat;
  }

  protected override void CreateTableHeader()
  {
    AddColumns();
  }

  private void AddColumns()
  {
    Editor.AddColumn(GetColumnData(nameof(LogModel.Task)));
    Editor.AddColumn(GetColumnData(nameof(LogModel.Start)));
    Editor.AddColumn(GetColumnData(nameof(LogModel.End)));
    Editor.AddColumn(GetColumnData(nameof(LogModel.Time)));
  }

  protected override void CreateTableRow(LogModel l)
  {
    Editor.AddValue(GetColumnData(nameof(LogModel.Task)), GetTask(l));
    Editor.AddValue(GetColumnData(nameof(LogModel.Start)), GetStart(l, StartFormat));
    Editor.AddValue(GetColumnData(nameof(LogModel.End)), GetEnd(l, EndFormat));
    Editor.AddValue(GetColumnData(nameof(LogModel.Time)), GetTime(l, HoursFormat));
  }

  protected override void SetColumnsSize(List<LogModel> l)
  {
    SetColumn(nameof(LogModel.Task), GetTaskLengths(l));
    SetColumn(nameof(LogModel.Start), GetStartLengths(l, StartFormat));
    SetColumn(nameof(LogModel.End), GetEndLengths(l, EndFormat));
    SetColumn(nameof(LogModel.Time), GetTimeLengths(l, HoursFormat));
  }
}
