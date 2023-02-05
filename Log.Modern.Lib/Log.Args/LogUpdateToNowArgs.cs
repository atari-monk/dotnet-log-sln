using CommandDotNet;

namespace Log.Modern.Lib;

public class LogUpdateToNowArgs
    : LogUpdateArgs
{
    private bool? endNow;
    private bool? startNow;

    [Option(
        'n'
        , "endnow")]
    public bool? EndNow
    { 
        get => endNow; 
        set 
        {
            endNow = value;
            if(endNow.HasValue && endNow.Value)
                End = DateTime.Now;
        } 
    }

    [Option(
        'a'
        , "startnow")]
    public bool? StartNow
    {
        get => startNow;
        set
        {
            startNow = value;
            if (startNow.HasValue && startNow.Value)
                Start = DateTime.Now;
        }
    }
}