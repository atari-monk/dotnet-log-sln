using DataToTable;
using DataToTable.MDI;
using Log.Data;
using Microsoft.Extensions.DependencyInjection;
using Task = Log.Data.Task;

namespace Log.Table.MDI;

public class LogTableSet 
    : DataToTableSet
{
    public LogTableSet(
        IServiceCollection container) 
            : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container
            .AddSingleton<IColumnCalculator<Category>, ColumnCalculator<Category>>()
            .AddSingleton<IColumnCalculator<Place>, ColumnCalculator<Place>>()
            .AddSingleton<IColumnCalculator<Task>, ColumnCalculator<Task>>()
            .AddSingleton<IColumnCalculator<LogModel>, ColumnCalculator<LogModel>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .AddSingleton<ITableTextEditor, TableTextEditor>()
            .AddSingleton<IDataToText<Category>, ModelATable<Category>>()
            .AddSingleton<IDataToText<Place>, ModelATable<Place>>()
            .AddSingleton<IDataToText<Task>, TaskTableProvider>()
            .AddSingleton<IDataToText<LogModel>, LogTableProvider>();
    }
}