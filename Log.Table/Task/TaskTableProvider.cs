using DataToTable;

namespace Log.Table;

public class TaskTableProvider 
	: TaskToColumn
{
	public TaskTableProvider(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Data.Task> columnCalculator)
			: base(tableTextEditor
				, columnCalculator)
    {
    }

	protected override void CreateTableHeader()
	{
		AddColumns();
	}

	private void AddColumns()
	{
		Editor.AddColumn(GetColumnData(nameof(Data.Task.Id)));
		Editor.AddColumn(GetColumnData(nameof(Data.Task.Name)));
		Editor.AddColumn(GetColumnData(nameof(Data.Task.Category)));
		Editor.AddColumn(GetColumnData(nameof(Data.Task.CategoryId)));
		Editor.AddColumn(GetColumnData(nameof(Data.Task.Description)));
	}

	protected override void CreateTableRow(Data.Task t)
	{
		Editor.AddValue(GetColumnData(nameof(Data.Task.Id)), GetId(t));
		Editor.AddValue(GetColumnData(nameof(Data.Task.Name)), GetName(t));
		Editor.AddValue(GetColumnData(nameof(Data.Task.Category)), GetCategory(t));
		Editor.AddValue(GetColumnData(nameof(Data.Task.CategoryId)), GetCategoryId(t));
		Editor.AddValue(GetColumnData(nameof(Data.Task.Description)), GetDescription(t));
	}

	protected override void SetColumnsSize(List<Data.Task> items)
	{
		SetColumn(nameof(Data.Task.Id), GetIdLengths(items));
		SetColumn(nameof(Data.Task.Name), GetNameLengths(items));
		SetColumn(nameof(Data.Task.Category), GetCategoryLengths(items));
		SetColumn(nameof(Data.Task.Category), GetCategoryLengths(items));
		SetColumn(nameof(Data.Task.CategoryId), GetCategoryIdLengths(items));
		SetColumn(nameof(Data.Task.Description), GetDescriptionLengths(items));
	}
}