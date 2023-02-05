using CommandDotNet;
using ModelHelper;
using System.ComponentModel.DataAnnotations;

namespace Log.Modern.Lib;

public class TaskFilterArgs
    : Model
    , IArgumentModel
{
    [Option(
        'c'
        , nameof(CategoryId))
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }

    [Option(
        'n'
        , nameof(Name))
        , MaxLength(NameMax)]
    public string? Name { get; set; }
}