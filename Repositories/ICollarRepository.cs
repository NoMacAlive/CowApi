using HalterExercise.Models;

namespace HalterExercise.Repositories
{
	public interface ICollarRepository : IRepository<Collar>
	{
		bool DeleteById( int id );
	}
}