using CLI.Core.Lib;
using CommandDotNet;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(MainCommand)]
public class PlaceCommands : Commands
{
    private const string MainCommand = "place";

    private readonly IReadCommand<PlaceArgFilter> readCommand;
    private readonly IInsertCommand<PlaceArg> insertCommand;
    private readonly IUpdateCommand<PlaceArgUpdate> updateCommand;

    public PlaceCommands(
        IReadCommand<PlaceArgFilter> readCommand
        , IInsertCommand<PlaceArg> insertCommand
        , IUpdateCommand<PlaceArgUpdate> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;
    }

    [DefaultCommand()]
    public void Read(PlaceArgFilter model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCommand)]
    public void Insert(PlaceArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new PlaceArgFilter());
    }

    [Command(UpdateCommand)]
    public void Update(PlaceArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}