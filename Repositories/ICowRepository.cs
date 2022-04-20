using System;
using HalterExercise.Models;

namespace HalterExercise.Repositories
{
	public interface ICowRepository : IRepository<Cow>
	{
		Cow GetByNumber( int cowNumber );
		Cow GetById( Guid id );
		bool DeleteById( Guid id );
	}
}