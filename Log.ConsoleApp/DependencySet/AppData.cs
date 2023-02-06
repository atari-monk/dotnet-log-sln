using CLIFramework;
using Unity;

namespace Log.ConsoleApp;

public class AppData 
    : CLIFramework.AppData
{
    public AppData(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void SetAppConfigData()
    {
        Config["AppName"] = "Log";
        Config["CommandParser"] = nameof(ParamCommandParser);
    }
}