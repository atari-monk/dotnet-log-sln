using ModelHelper;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Log.Data;

public class Category 
    : Model 
    , IModelA
{
	public int Id { get; set; }

	[Required, MaxLength(NameMax)]
	public string? Name { get; set; }

	[Required, MaxLength(DescriptionMax)]
	public string? Description { get; set; }

    [ForeignKey(nameof(Category))]
	public int? ParentId { get; set; }

	public Category? Parent { get; set; }

	public IEnumerable<Category>? Children { get; set; }
}