using Log.Data;
using Log.Modern.CliApp.TestApi;
using Xunit;
using XUnit.Helper;

namespace Log.Modern.CliApp.Tests;

[Collection(DbTests)]
[TestCaseOrderer(OrdererTypeName, OrdererAssemblyName)]
public class PlaceUpdateTests
    : OrderTest
    , IClassFixture<LogFixture>
{
    private LogFixture fixture;

    public PlaceUpdateTests(LogFixture fixture)
    {
        this.fixture = fixture;
    }

    [Theory]
    [MemberData(nameof(PlaceData.Insert01), MemberType= typeof(PlaceData))]
    public void Test01(params string[] cmd)
    {
        fixture.RunCmd(fixture.Booter, cmd);
        fixture.AssertPlaceCount(fixture.Uow, 1);
    }

    [Theory]
    [MemberData(nameof(PlaceData.Update01), MemberType= typeof(PlaceData))]
    public void Test02(params string[] cmd)
    {
        var place = fixture.GetPlace(fixture.Uow, elementIndex: 0);
        var command = new List<string>(cmd);
        SetValue(command, "placeid", place.Id.ToString());
        fixture.RunCmd(fixture.Booter, command.ToArray());
        place = fixture.GetPlace(fixture.Uow, elementIndex: 0);
        fixture.AssertPlace(
            new Place 
            { 
                Name = "wiśnicz"
                , Description = "small city"
            }
            , place);
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