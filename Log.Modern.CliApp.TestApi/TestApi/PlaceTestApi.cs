using Log.Data;
using Xunit;

namespace Log.Modern.CliApp.TestApi;

public abstract class PlaceTestApi
    : CategoryTestApi
{
    protected static IEnumerable<Place>? GetPlaces(
        ILogUnitOfWork? unitOfWork)
    {
        return unitOfWork?.Place?.Get();
    }

    public void AssertPlaceCount(
        ILogUnitOfWork? repo
        , int expected)
    {
        var actual = GetPlaces(repo)?.Count();
        Assert.True(expected == actual);
    }

    public Place GetPlace(
        ILogUnitOfWork? repo
        , int elementIndex)
    {
        var data = GetPlaces(repo)?.ElementAt(elementIndex);
        ArgumentNullException.ThrowIfNull(data);
        return data;
    }

    public void AssertPlace(
        Place expected
        , Place acctual)
    {
        Assert.True(acctual?.Id > 0);
        Assert.True(acctual?.Name == expected.Name);
        Assert.True(acctual?.Description == expected.Description);
    }
}