using System.ComponentModel.DataAnnotations;
using CommandDotNet;
using DotNetExtension;
using ModelHelper;
using Task = Log.Data.Task;

namespace Log.Modern.Lib;

[AtLeastOneProperty(nameof(Task.CategoryId)
    , nameof(Task.Name)
    , nameof(Task.Description)
    , ErrorMessage = UpdateError)]
public class  TaskUpdateArgs 
    : ModelAUpdateArgs
        , IArgumentModel
        , IId
{
    protected new const string UpdateError = "You must supply Name or Description or CategoryId";

    [Option(
        'c'
        ,"categoryId")
        , Range(IdMin, IdMax, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }
}