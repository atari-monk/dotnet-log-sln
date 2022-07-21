using Log.Data;
using Log.Modern.CliApp.TestApi;
using Xunit;
using XUnit.Helper;

namespace Log.Modern.CliApp.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class CategoryUpdateTests
    : OrderTest
    , IClassFixture<LogFixture>
{
    private LogFixture fixture;

    public CategoryUpdateTests(LogFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(CategoryData.Insert01), MemberType= typeof(CategoryData))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertCategoryCount(fixture.Uow, 1);
    }

    [Theory]
    [MemberData(nameof(CategoryData.Update01), MemberType= typeof(CategoryData))]
    public void Test02(params string[] cmd)
    {
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "categoryid", category.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        fixture.AssertCategory(
            new Category 
            { 
                Name = "pay somebody to do it"
                , Description = "if you have money you can invest it"
            }
            , category);
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