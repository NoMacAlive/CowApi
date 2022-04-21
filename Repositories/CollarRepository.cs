using System.Threading.Tasks;
using HalterExercise.Models;

namespace HalterExercise.Repositories
{
	public class CollarRepository : ICollarRepository
	{
		public async Task<bool> Create( Collar newObject )
		{
			throw new System.NotImplementedException( );
		}

		public async Task<bool> Update( Collar updatedObject )
		{
			throw new System.NotImplementedException( );
		}

		public bool DeleteById( int id )
		{
			throw new System.NotImplementedException( );
		}
	}
}