using CommandDotNet.Unity.Helper;
using Unity;

namespace Log.Modern.ConsoleApp;

public class CommandCliSuite 
    : LogSuite
{
    public CommandCliSuite(
        IUnityContainer container)
        : base(container)
    {
    }

    protected override void RegisterProgram() =>
        RegisterSet<AppProgSet<CommandCli>>();
}