using Log.Data;
using Xunit;
using Task = Log.Data.Task;

namespace Log.Modern.CliApp.TestApi;

public abstract class TaskTestApi
    : PlaceTestApi
{
    protected static IEnumerable<Task>? GetTasks(
        ILogUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Task?.Get();
    }

    public void AssertTaskCount(
        ILogUnitOfWork? repo
        , int expected)
    {
        var actual = GetTasks(repo)?.Count();
        Assert.True(expected == actual);
    }

    public Task GetTask(
        ILogUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetTasks(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public void AssertTask(
        Task expected
        , Task acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.CategoryId == expected.CategoryId);
        Assert.True(acctual?.Name == expected.Name);
        Assert.True(acctual?.Description == expected.Description);
    }
}