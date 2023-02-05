using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using ModelHelper;

namespace Log.Modern.Lib;

public abstract class ModelAInsertArgs
    : Model
    , IArgumentModel
{
    [Operand(nameof(Name))
        , Required
        , MaxLength(NameMax)]
    public string? Name { get; set; }

    [Operand(nameof(Description))
        , Required
        , MaxLength(DescriptionMax)]
    public string? Description { get; set; }
}