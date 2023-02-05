using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Log.Modern.Lib;

public class LogFilterArgs
    : Model
    , IArgumentModel
{
    [Option(
        shortName: 's'
        , longName: "start")]
    public DateTime? Start { get; set; }

    [Option(
        shortName: 'c'
        , longName: "category")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }

    [Option(
        shortName: 't'
        , longName: "task")
    , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? TaskId { get; set; }

    [Option(longName: "todo")]
    public bool ToDoLogs { get; set; }
}