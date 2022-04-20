namespace HalterExercise.Repositories
{
	public interface IRepository<T>
	{
		bool Create( T newObject );
		bool Update( T updatedObject );
	}
}