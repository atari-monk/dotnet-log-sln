using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Log.Modern.Lib;

public class  LogInsertArgs 
    : Model
    , IArgumentModel
{
    [Operand(nameof(TaskId))
        , Required
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int TaskId { get; set; }

    [Operand(nameof(Description))
        , MaxLength(DescriptionMax)]
    public string? Description { get; set; }

    [Operand(nameof(PlaceId))
        , Required
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int PlaceId { get; set; } = 1;

    [Operand(nameof(Start)
        , Description = DateTimeFormat)]
    public DateTime? Start { get; set; } = DateTime.Now;

    [Operand(nameof(End)
        , Description = DateTimeFormat)]
    public DateTime? End { get; set; }
}