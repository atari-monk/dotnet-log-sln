using DataToTable;

namespace Log.Table;

public abstract class TaskToColumn
    : TaskToText
{
    protected TaskToColumn(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Data.Task> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

	protected List<int> GetIdLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => GetId(m).Length).ToList();
		rows.Insert(0, nameof(Data.Task.Id).Length);
		return rows;
	}

	protected List<int> GetNameLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => GetName(m).Length).ToList();
		rows.Insert(0, nameof(Data.Task.Name).Length);
		return rows;
	}

	protected List<int> GetCategoryLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => GetCategory(m).Length).ToList();
		rows.Insert(0, nameof(Data.Task.Category).Length);
		return rows;
	}

	protected List<int> GetCategoryIdLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => GetCategoryId(m).Length).ToList();
		rows.Insert(0, nameof(Data.Task.CategoryId).Length);
		return rows;
	}

	protected List<int> GetDescriptionLengths(List<Data.Task> models)
	{
		var rows = models.Select(m => GetDescription(m).Length).ToList();
		rows.Insert(0, nameof(Data.Task.Description).Length);
		return rows;
	}
}