namespace Log.Modern.CliApp.Tests;

public class TaskInsertData
{
    public static IEnumerable<object[]> Test01 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "test", "test" }
        };

    public static IEnumerable<object[]> Test02 =>
        new List<object[]>
        {
            new object[] { "task", "ins", "categoryid", "test", "test" }
        };
}