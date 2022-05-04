using System.Collections.Generic;
using System.Threading.Tasks;
using CowApi.Models;

namespace CowApi.Services
{
	public interface ICollarStatusService
	{
		Task<List<CollarStatus>> GetCollarStatus( int collarId );
		Task<CollarStatus> GetLatestCollarStatus( int collarId );
	}
}