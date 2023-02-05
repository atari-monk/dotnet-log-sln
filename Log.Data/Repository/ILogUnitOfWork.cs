using EFCore.Helper;

namespace Log.Data;

public interface ILogUnitOfWork 
	: IUnitOfWork
{
	IRepository<Category> Category { get; }
	IRepository<Place> Place { get; }
	IRepository<Task> Task { get; }
	ILogRepo Log { get; }
}