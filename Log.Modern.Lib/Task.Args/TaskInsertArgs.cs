using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Log.Modern.Lib;

public class  TaskInsertArgs
    : Model
    , IArgumentModel
{
    [Operand(nameof(CategoryId))
        , Required
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int CategoryId { get; set; }

    [Operand(nameof(Name))
        , Required
        , MaxLength(NameMax)]
    public string? Name { get; set; }

    [Operand(nameof(Description))
        , Required
        , MaxLength(DescriptionMax)]
    public string? Description { get; set; }
}