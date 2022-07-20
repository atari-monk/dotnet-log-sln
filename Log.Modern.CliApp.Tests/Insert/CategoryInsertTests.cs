using Log.Data;
using Log.Modern.CliApp.TestApi;
using Xunit;
using XUnit.Helper;

namespace Log.Modern.CliApp.Tests;

[Collection("Serial2")]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class CategoryInsertTests
    : OrderTest
    , IClassFixture<LogFixture>
{
    private LogFixture fixture;

    public CategoryInsertTests(LogFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(CategoryInsertData.Test01), MemberType= typeof(CategoryInsertData))]
    public void Test01(params string[] cmd)
    {
        fixture.AssertCategoryCount(fixture.Uow, 0);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertCategoryCount(fixture.Uow, 1);
        var data = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        fixture.AssertCategory(
            new Category 
            { 
                Name = "test"
                , Description = "test"
            }
            , data);
    }
}