namespace Log.Modern.CliApp.Tests;

public class LogData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "big", "big size" }
        };

    public static IEnumerable<object[]> Insert02 =>
        new List<object[]>
        {
            new object[] { "task", "ins", "categoryid", "jogging", "running exercise" }
        };

    public static IEnumerable<object[]> Insert03 =>
        new List<object[]>
        {
            new object[] { "place", "ins", "test", "test" }
        };

    public static IEnumerable<object[]> Insert04 =>
        new List<object[]>
        {
            new object[] { "log", "ins", "taskid", "test", "placeid", "21.07.2022 17:00", "21.07.2022 18:00" }
        };
}