using DataToTable;
using Log.Data;
using Log.Modern.Lib;
using Unity;

namespace Log.Modern.ConsoleApp;

public class AppOutput 
    : CLIHelper.Unity.AppOutput
{
    public AppOutput(
        IUnityContainer container) 
            : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container
            .RegisterSingleton<IColumnCalculator<LogModel>, ColumnCalculator<LogModel>>()
            .RegisterSingleton<IColumnCalculator<Data.Task>, ColumnCalculator<Data.Task>>()
            .RegisterSingleton<IColumnCalculator<Data.Category>, ColumnCalculator<Data.Category>>()
            .RegisterSingleton<IColumnCalculator<Data.Place>, ColumnCalculator<Data.Place>>();
    }
    
    protected override void RegisterTableProviders()
    {
        Container
            .RegisterType<ITableTextEditor, TableTextEditor>()
            .RegisterSingleton<IDataToText<LogModel>, LogTableProvider>()
            .RegisterSingleton<IDataToText<Data.Task>, TaskTableProvider>()
            .RegisterSingleton<IDataToText<Data.Category>, ModelATable<Data.Category>>()
            .RegisterSingleton<IDataToText<Data.Place>, ModelATable<Data.Place>>();
    }
}