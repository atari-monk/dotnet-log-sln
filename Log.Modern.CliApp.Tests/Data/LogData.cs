namespace Log.Modern.CliApp.Tests;

public class LogData
{
    public static IEnumerable<object[]> Insert01 =>
        new List<object[]>
        {
            new object[] { "category", "ins", "big", "big size" }
            , new object[] { "place", "ins", "Kraków", "Polska" }
            , new object[] { "place", "ins", "Wiśnicz", "Polska" }
        };

    public static IEnumerable<object[]> Insert02 =>
        new List<object[]>
        {
            new object[] { "task", "ins", "categoryid", "jogging", "running exercise" }
            , new object[] { "task", "ins", "categoryid", "biking", "ride a bike" }
        };

    public static IEnumerable<object[]> Insert03 =>
        new List<object[]>
        {
            new object[] { "log", "ins", "taskid", "test", "placeid", "21.07.2022 17:00", "21.07.2022 18:00" }
        };
    
    public static IEnumerable<object[]> Update01 =>
        new List<object[]>
        {
            new object[] { "log", "upd", "logid", "-t" ,"taskid", "-d", "moddified", "-p", "placeid", "-s", "22.07.2022 21:00", "-e", "22.07.2022 21:15" }
        };
}