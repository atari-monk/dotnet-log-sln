namespace Log.Modern.CliApp.Tests;

public class TaskData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "big", "big size" }
            , new object[] { "category", "ins", "small", "small size" }
        };

    public static IEnumerable<object[]> Insert02 =>
        new List<object[]>
        {
            new object[] { "task", "ins", "categoryid", "jogging", "running exercise" }
        };

    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
            new object[] { "task", "upd", "taskid", "-c", "categoryid", "-n", "taking shower", "-d", "showering in walk in shower" }
        };
}