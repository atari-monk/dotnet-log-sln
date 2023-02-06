using CLIFramework;
using CLIWizardHelper;
using Task = Log.Data.Task;

namespace Log.Console.Lib;

public class TaskUpdateCommand 
	: DataCommand<Task>
        , IDataCommand
{
    private readonly IUpdateWizard<Task> updateWizard;
    private ICommandRunner? commandRunner;

	public TaskUpdateCommand(
		TextCommand textCommand
		, IUpdateWizard<Task> updateWizard)
		: base(textCommand)
	{
        this.updateWizard = updateWizard;
		ArgumentNullException.ThrowIfNull(this.updateWizard);
    }

	public void SetCommandRunner(ICommandRunner commandRunner)
	{
		this.commandRunner = commandRunner;
		ArgumentNullException.ThrowIfNull(this.commandRunner);
	}

	public override void Execute(object? parameter)
	{
		updateWizard.Update();
		commandRunner?.RunCommand(nameof(Task).ToLowerInvariant());
	}
}