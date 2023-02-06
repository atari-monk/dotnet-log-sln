using CLIFramework;
using CLIWizardHelper;
using Log.Data;

namespace Log.Console.Lib;

public class LogUpdateCommand 
	: DataCommand<LogModel>
        , IDataCommand
{
    private readonly IUpdateWizard<LogModel>? updateWizard;
    private ICommandRunner? commandRunner;

	public LogUpdateCommand(
		TextCommand textCommand
		, IUpdateWizard<LogModel> updateWizard)
			: base(textCommand)
	{
		ArgumentNullException.ThrowIfNull(updateWizard);

        this.updateWizard = updateWizard;
    }

	public void SetCommandRunner(ICommandRunner commandRunner)
	{
		ArgumentNullException.ThrowIfNull(commandRunner);
		this.commandRunner = commandRunner;
	}

	public override void Execute(object? parameter)
	{
		updateWizard?.Update();
		commandRunner?.RunCommand("log");
	}
}