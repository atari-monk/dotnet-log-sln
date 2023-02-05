using DataToTable;

namespace Log.Table;

public abstract class TaskToText
    : ModelATable<Data.Task>
{
    protected TaskToText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Data.Task> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

	protected string GetId(Data.Task t) => 
		t.Id.ToString();
    
    protected string GetName(Data.Task t)
    {
        ArgumentNullException.ThrowIfNull(t.Name);
        return t.Name.ToString();
    }

    protected string GetDescription(Data.Task t)
    {
        ArgumentNullException.ThrowIfNull(t.Description);
        return t.Description.ToString();
    }

    protected string GetCategory(Data.Task t)
    {
        ArgumentNullException.ThrowIfNull(t.Category);
        ArgumentNullException.ThrowIfNull(t.Category.Name);
        return t.Category.Name.ToString();
    }

    protected string GetCategoryId(Data.Task t) => 
		t.CategoryId.ToString();
}