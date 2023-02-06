using CLIFramework;
using CRUDCommandHelper;
using Task = Log.Data.Task;

namespace Log.Console.Lib;

public class TaskReadCommand 
	: DataCommand<Task>
{
    private readonly IReadCommand<TaskFilter> readCommand;

    public TaskReadCommand(
		TextCommand textCommand
		, IReadCommand<TaskFilter> readCommand)
			: base(textCommand)
	{
        this.readCommand = readCommand;
		ArgumentNullException.ThrowIfNull(this.readCommand);
    }

	public override void Execute(object? parameter)
	{
		readCommand.Read(new TaskFilter());
	}
}