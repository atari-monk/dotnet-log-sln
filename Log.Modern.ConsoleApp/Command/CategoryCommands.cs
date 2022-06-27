using CommandDotNet;
using CRUDCommandHelper;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(Main)]
public class CategoryCommands
    : Commands
{
    private const string Main = "category";

    private readonly IReadCommand<CategoryArgFilter> read;
    private readonly IInsertCommand<CategoryArg> insert;
    private readonly IUpdateCommand<CategoryArgUpdate> update;
    private readonly IDeleteCommand<DeleteArgs> delete;

    public CategoryCommands(
        IReadCommand<CategoryArgFilter> read
        , IInsertCommand<CategoryArg> insert
        , IUpdateCommand<CategoryArgUpdate> update
        , IDeleteCommand<DeleteArgs> delete)
    {
        this.read = read;
        this.insert = insert;
        this.update = update;
        this.delete = delete;
    }

    [DefaultCommand()]
    public void Read(CategoryArgFilter model)
    {
        read.Read(model);
    }

    [Command(InsertCmd)]
    public void Insert(CategoryArg model)
    {
        insert.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        read.Read(new CategoryArgFilter());
    }

    [Command(UpdateCmd)]
    public void Update(CategoryArgUpdate model)
    {
        update.Update(model);
        ReadAfterChange();
    }

    [Command(DeleteCmd)]
    public void Delete(DeleteArgs model)
    {
        delete.Delete(model);
        ReadAfterChange();
    }
}