using System;
using System.ComponentModel.DataAnnotations;

namespace Log.Console.Lib;

#nullable enable
public class TaskFilter
{
    private const string IdError = "Id must be greater than zero";

    [Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }

    [MaxLength(25)]
    public string? Name { get; set; }
}
