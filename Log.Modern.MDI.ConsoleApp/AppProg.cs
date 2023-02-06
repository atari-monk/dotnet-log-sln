using CommandDotNet;
using CommandDotNet.Repl;
using CommandDotNet.MDI.Helper;
using Config.Wrapper;
using Serilog;

namespace Log.Modern.MDI.ConsoleApp;

[Command()]
public class AppProg
    : AppProgMDI<AppProg>
{
	private static bool inSession;

    [Subcommand()]
    public LogModelCommands? LogModel { get; set; }
    
    public AppProg(
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