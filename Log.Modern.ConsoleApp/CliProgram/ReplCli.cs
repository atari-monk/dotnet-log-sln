using CommandDotNet;
using CommandDotNet.Repl;
using CommandDotNet.Unity.Helper;
using Config.Wrapper;
using Serilog;

namespace Log.Modern.ConsoleApp;

public class ReplCli 
    : AppProgUnity<ReplCli>
{
	private static bool inSession;

    [Subcommand]
    public PlaceCommands? PlaceCommands { get; set; }

    [Subcommand]
    public CategoryCommands? CategoryCommands { get; set; }

    [Subcommand]
    public TaskCommands? TaskCommands { get; set; }

    [Subcommand]
    public LogCommands? LogCommands { get; set; }

    public ReplCli(
        ILogger log
        , IConfigReader config) 
            : base(log, config)
    {
    }

    [DefaultCommand()]
    public void StartSession(
        CommandContext context,
        ReplSession replSession)
    {
        if (inSession == false)
        {
            context.Console.WriteLine("start session");
            inSession = true;
            replSession.Start();
        }
        else
        {
            context.Console.WriteLine($"no session {inSession}");
            context.ShowHelpOnExit = true;
        }
    }
}