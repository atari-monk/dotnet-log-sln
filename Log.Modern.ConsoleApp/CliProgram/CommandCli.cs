using CommandDotNet;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Log.Modern.ConsoleApp;

public class CommandCli 
    : AppProgUnity<CommandCli>
{
    [Subcommand]
    public PlaceCommands? PlaceCommands { get; set; }

    [Subcommand]
    public CategoryCommands? CategoryCommands { get; set; }

    [Subcommand]
    public TaskCommands? TaskCommands { get; set; }

    [Subcommand]
    public LogCommands? LogCommands { get; set; }

    public CommandCli(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }
}