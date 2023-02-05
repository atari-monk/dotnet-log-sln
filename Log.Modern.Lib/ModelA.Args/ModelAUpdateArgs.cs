using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using DotNetExtension;
using ModelHelper;

namespace Log.Modern.Lib;

[AtLeastOneProperty(
    nameof(ModelA.Name)
    , nameof(ModelA.Description)
    , ErrorMessage=UpdateError)]
public abstract class  ModelAUpdateArgs 
    : Model
    , IArgumentModel
    , IId
{
    protected const string UpdateError = "You must supply Name or Description";

    [Operand(
        "id")
        , Required
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int Id { get; set; }

    [Option(
        'n'
        ,"name")
        , MaxLength(NameMax)]
    public string? Name { get; set; }

    [Option(
        'd'
        ,"description")
        , MaxLength(DescriptionMax)]
    public string? Description { get; set; }
}