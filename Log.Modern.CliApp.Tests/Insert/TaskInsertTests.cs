using Log.Modern.CliApp.TestApi;
using Xunit;
using XUnit.Helper;
using Task = Log.Data.Task;

namespace Log.Modern.CliApp.Tests;

[Collection("Serial2")]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class TaskInsertTests
    : OrderTest
    , IClassFixture<LogFixture>
{
    private LogFixture fixture;

    public TaskInsertTests(LogFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(TaskInsertData.Test01), MemberType= typeof(TaskInsertData))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
    }

    [Theory]
    [MemberData(nameof(TaskInsertData.Test02), MemberType= typeof(TaskInsertData))]
    public void Test02(params string[] cmd)
    {
        fixture.AssertTaskCount(fixture.Uow, 0);
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        fixture.AssertTaskCount(fixture.Uow, 1);
        var data = fixture.GetTask(fixture.Uow, elementIndex: 0);
        fixture.AssertTask(
            new Task 
            {
                CategoryId = category.Id
                , Name = "test"
                , Description = "test"
            }
            , data);
    }

    private void SetValue(
        List<string> cmd
        , string key
        , string value)
    {
        cmd[GetIndex(cmd, key)] = value;
    }

    private int GetIndex(List<string> cmd, string value)
    {
        return cmd.IndexOf(value);
    }
}