namespace Log.Modern.CliApp.Tests;

public class LogInsertData
    : TaskInsertData
{
    public static IEnumerable<object[]> Test03 =>
        new List<object[]>
        {
            new object[] { "place", "ins", "test", "test" }
        };

    public static IEnumerable<object[]> Test04 =>
        new List<object[]>
        {
            new object[] { "log", "ins", "taskid", "test", "placeid", "21.07.2022 17:00", "21.07.2022 18:00" }
        };
}