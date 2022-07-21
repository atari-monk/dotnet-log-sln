using Log.Data;
using Log.Modern.CliApp.TestApi;
using Xunit;
using XUnit.Helper;

namespace Log.Modern.CliApp.Tests;

[Collection(DbTests)]
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
    [MemberData(nameof(CategoryData.Insert01), MemberType= typeof(CategoryData))]
    public void Test01(params string[] cmd)
    {
        fixture.AssertCategoryCount(fixture.Uow, 0);
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertCategoryCount(fixture.Uow, 1);
        var category = fixture.GetCategory(fixture.Uow, elementIndex: 0);
        fixture.AssertCategory(
            new Category 
            { 
                Name = "do it yourself"
                , Description = "is the method of building, modifying, or repairing things by oneself"
            }
            , category);
    }
}