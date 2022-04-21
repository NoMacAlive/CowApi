using System.Collections.Generic;
using System.Threading.Tasks;
using HalterExercise.Models;

namespace HalterExercise.Services
{
	public interface ICollarStatusService
	{
		Task<List<CollarStatus>> GetCollarStatus( int collarId );
		Task<CollarStatus> GetLatestCollarStatus( int collarId );
	}
}