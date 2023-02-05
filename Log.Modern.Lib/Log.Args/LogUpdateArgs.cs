using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using DotNetExtension;
using ModelHelper;
using ALog = Log.Data.LogModel;

namespace Log.Modern.Lib;

[AtLeastOneProperty(
    nameof(ALog.TaskId)
    , nameof(ALog.Start)
    , nameof(ALog.End)
    , nameof(ALog.Description)
    , nameof(ALog.PlaceId)
    , nameof(ALog.TimeTicks)
    , "EndNow"
    , "StartNow"
    , "ResetStart"
    , "ResetEnd"
    , ErrorMessage = UpdateError)]
public class LogUpdateArgs 
    : Model
    , IArgumentModel
    , IId
{
    private const string UpdateError = 
        "You must supply TaskId or Start or End or" 
        + "Description or PlaceId or TimeTicks"
        + "or EndNow or StartNow or ResetStart or ResetEnd";

    [Operand(
        "id")
        , Required
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int Id { get; set; }

    [Option(
        't'
        , "taskId")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? TaskId { get; set; }

    [Option(
        's'
        , "start")]
    public DateTime? Start { get; set; }

    [Option(
        'e'
        , "end")]
    public DateTime? End { get; set; }

    [Option(
        'd'
        , "description")
        , MaxLength(DescriptionMax)]
    public string? Description { get; set; }

    [Option(
        'p'
        , "placeId")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? PlaceId { get; set; }

    [Option(
        'i'
        , "ticks")]
    public int? TimeTicks { get; set; }
}