using System.ComponentModel.DataAnnotations;

namespace Log.Console.Lib;

public class LogFilter 
{
    private const string IdError = "Id must be greater than zero";

    public DateTime? Start { get; set; }

    [Range(1, int.MaxValue, ErrorMessage = IdError)]
    public int? CategoryId { get; set; }
}