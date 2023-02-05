using ModelHelper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Log.Data;

public class Task 
	: Model
    , IModelA
{
	public int Id { get; set; }

	[Required, MaxLength(NameMax)]
	public string? Name { get; set; }

	[Required, MaxLength(DescriptionMax)]
	public string? Description { get; set; }

	[ForeignKey(nameof(Category))]
	public int CategoryId { get; set; }

	public Category? Category { get; set; }
}