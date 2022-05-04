using System;
using CowApi.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CowApi.Repositories
{
	public interface ICowRepository : IRepository<Cow>
	{
		Task<Cow> GetByNumber( int cowNumber );
		Task<Cow> GetById( Guid id );
		Task<bool> DeleteById( Guid id );
		Task<IList<Cow>> GetAllCows( );
	}
}