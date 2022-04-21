using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalterExercise.Controllers;
using HalterExercise.Models;

namespace HalterExercise.Services
{
	public class CollarStatusService : ICollarStatusService
	{
		private readonly ICowAPI _cowApi;

		public CollarStatusService( ICowAPI cowApi )
		{
			_cowApi = cowApi;
		}

		public async Task<List<CollarStatus>> GetCollarStatus( int collarId )
		{
			return await _cowApi.GetCollarStatusList( collarId.ToString( ) );
		}

		public async Task<CollarStatus> GetLatestCollarStatus( int collarId )
		{ 
			List<CollarStatus> collarStatusList = await _cowApi.GetCollarStatusList( collarId.ToString( ) );
			CollarStatus latestCollarStatus = collarStatusList.OrderByDescending( x => x.Timestamp ).FirstOrDefault( );
			return latestCollarStatus;
		}
	}
}