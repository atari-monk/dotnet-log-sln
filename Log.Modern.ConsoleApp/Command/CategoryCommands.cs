using CommandDotNet;
using CRUDCommandHelper;
using Log.Modern.Lib;

namespace Log.Modern.ConsoleApp;

[Command(Main)]
public class CategoryCommands
    : Commands
{
    private const string Main = "category";

    private readonly IReadCommand<CategoryFilterArgs> read;
    private readonly IInsertCommand<CategoryInsertArgs> insert;
    private readonly IUpdateCommand<CategoryUpdateArgs> update;
    private readonly IDeleteCommand<DeleteArgs> delete;

    public CategoryCommands(
        IReadCommand<CategoryFilterArgs> read
        , IInsertCommand<CategoryInsertArgs> insert
        , IUpdateCommand<CategoryUpdateArgs> update
        , IDeleteCommand<DeleteArgs> delete)
    {
        this.read = read;
        this.insert = insert;
        this.update = update;
        this.delete = delete;
    }

    [DefaultCommand()]
    public void Read(CategoryFilterArgs model)
    {
        read.Read(model);
    }

    [Command(InsertCmd)]
    public void Insert(CategoryInsertArgs model)
    {
        insert.Insert(model);
        ReadAfterChange();
    }

    private void ReadAfterChange()
    {
        read.Read(new CategoryFilterArgs());
    }

    [Command(UpdateCmd)]
    public void Update(CategoryUpdateArgs model)
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