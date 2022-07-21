namespace Log.Modern.CliApp.Tests;

public class CategoryData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "do it yourself", "is the method of building, modifying, or repairing things by oneself" }
        };
    
    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
            new object[] { "category", "upd", "categoryid", "-n", "pay somebody to do it", "-d", "if you have money you can invest it" }
        };
}