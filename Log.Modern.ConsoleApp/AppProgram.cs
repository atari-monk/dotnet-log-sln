using CommandDotNet;
using CommandDotNet.Repl;
using Unity;

namespace Log.Modern.ConsoleApp;

public class AppProgram : Console.Modern.Lib.AppProgramUnity<AppProgram>
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

    public AppProgram(
        IUnityContainer container) 
            : base(container)
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

    protected override void RegisterCommandClasses(AppRunner appRunner)
    {
        var commandClassTypes = appRunner.GetCommandClassTypes();
        var registeredExplicitly = new Type[] 
        {
            // typeof()
        };
        foreach (var type in commandClassTypes)
        {
            if(registeredExplicitly.Contains(type.type)) continue;
            Container.RegisterSingleton(type.type);
        }
    }
}