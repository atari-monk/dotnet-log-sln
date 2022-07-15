using CommandDotNet;
using CRUDCommandHelper;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(MainCommand)]
public class PlaceCommands : Commands
{
    private const string MainCommand = "place";

    private readonly IReadCommand<PlaceFilterArgs> readCommand;
    private readonly IInsertCommand<PlaceInsertArgs> insertCommand;
    private readonly IUpdateCommand<PlaceUpdateArgs> updateCommand;

    public PlaceCommands(
        IReadCommand<PlaceFilterArgs> readCommand
        , IInsertCommand<PlaceInsertArgs> insertCommand
        , IUpdateCommand<PlaceUpdateArgs> updateCommand)
    {
        this.readCommand = readCommand;
        this.insertCommand = insertCommand;
        this.updateCommand = updateCommand;
    }

    [DefaultCommand()]
    public void Read(PlaceFilterArgs model)
    {
        readCommand.Read(model);
    }

    [Command(InsertCmd)]
    public void Insert(PlaceInsertArgs model)
    {
        insertCommand.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        readCommand.Read(new PlaceFilterArgs());
    }

    [Command(UpdateCmd)]
    public void Update(PlaceUpdateArgs model)
    {
        updateCommand.Update(model);
        ReadAfterChange();
    }
}