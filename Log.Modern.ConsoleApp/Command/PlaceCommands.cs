using CommandDotNet;
using CRUDCommandHelper;
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

    [Command(InsertCmd)]
    public void Insert(PlaceArg model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new PlaceArgFilter());
    }

    [Command(UpdateCmd)]
    public void Update(PlaceArgUpdate model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}