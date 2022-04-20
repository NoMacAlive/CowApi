using System;
using System.Linq;
using HalterExercise.Models;

namespace HalterExercise.Repositories
{
	public class CowRepository : ICowRepository
	{
		private readonly HalterContext _dbContext;

		public CowRepository( HalterContext dbContext )
		{
			_dbContext = dbContext;
		}

		public Cow GetById( Guid id )
		{
			return _dbContext.Cows.FirstOrDefault( x => x.Id == id );
		}

		public bool Create( Cow newObject )
		{
			_dbContext.Cows.Add( newObject );
			_dbContext.SaveChanges( );
			return true;
		}

		public bool Update( Cow updatedObject )
		{
			_dbContext.Cows.Update( updatedObject );
			_dbContext.SaveChanges( );
			return true;
		}

		public bool DeleteById( Guid id )
		{
			_dbContext.Cows.Remove( GetById( id ) );
			return true;
		}

		public Cow GetByNumber( int cowNumber )
		{
			return _dbContext.Cows.FirstOrDefault( x => x.CowNumber == cowNumber );
		}
	}
}