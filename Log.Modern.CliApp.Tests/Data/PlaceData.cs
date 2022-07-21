namespace Log.Modern.CliApp.Tests;

public class PlaceData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { "place", "ins", "cracow", "city with 700k cheap labor" }
        };
    
    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
            new object[] { "place", "upd", "placeid", "-n", "wiśnicz", "-d", "small city" }
        };
}