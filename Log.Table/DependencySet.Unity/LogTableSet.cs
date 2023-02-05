using DataToTable;
using DataToTable.Unity;
using Log.Data;
using Unity;
using Task = Log.Data.Task;

namespace Log.Table.Unity;

public class LogTableSet
    : DataToTableSet
{
  public LogTableSet(
      IUnityContainer container)
      : base(container)
  {
  }

  protected override void RegisterColumnCalculators()
  {
    Container
      .RegisterSingleton<IColumnCalculator<Category>, ColumnCalculator<Category>>()
      .RegisterSingleton<IColumnCalculator<Place>, ColumnCalculator<Place>>()
      .RegisterSingleton<IColumnCalculator<Task>, ColumnCalculator<Task>>()
      .RegisterSingleton<IColumnCalculator<LogModel>, ColumnCalculator<LogModel>>();
  }

  protected override void RegisterTableProviders()
  {
    Container
      .RegisterType<ITableTextEditor, TableTextEditor>()
      .RegisterSingleton<IDataToText<Category>, ModelATable<Category>>()
      .RegisterSingleton<IDataToText<Place>, ModelATable<Place>>()
      .RegisterSingleton<IDataToText<Task>, TaskTableProvider>()
      .RegisterSingleton<IDataToText<LogModel>, LogTableProvider>()
      .RegisterSingleton<ILogTimeSumTable, LogTimeSumTable>();
  }
}