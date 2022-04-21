using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalterExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace HalterExercise.Repositories
{
	public class CowRepository : ICowRepository
	{
		private readonly HalterContext _dbContext;

		public CowRepository( HalterContext dbContext )
		{
			_dbContext = dbContext;
		}

		public async Task<Cow> GetById( Guid id )
		{
			return await _dbContext.Cows.FirstOrDefaultAsync( x => x.Id == id );
		}

		public async Task<bool> Create( Cow newObject )
		{
			var entityEntry = _dbContext.Cows.Add( newObject );
			await _dbContext.SaveChangesAsync( );
			return entityEntry is null ? false : true;
		}

		public async Task<bool> Update( Cow updatedObject )
		{
			_dbContext.Cows.Update( updatedObject );
			await _dbContext.SaveChangesAsync( );
			return true;
		}

		public async Task<bool> DeleteById( Guid id )
		{
			_dbContext.Cows.Remove( await GetById( id ) );
			return true;
		}

		public async Task<IList<Cow>> GetAllCows( )
		{
			return await _dbContext.Cows.ToListAsync( );
		}

		public async Task<Cow> GetByNumber( int cowNumber )
		{
			return await _dbContext.Cows.FirstOrDefaultAsync( x => x.CowNumber == cowNumber );
		}
	}
}