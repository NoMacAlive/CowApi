using System.Threading.Tasks;

namespace CowApi.Repositories
{
	public interface IRepository<T>
	{
		Task<bool> Create( T newObject );
		Task<bool> Update( T updatedObject );
	}
}