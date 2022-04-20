using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalterExercise.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HalterExercise.Controllers
{
	[ApiController]
	[Route( "[controller]" )]
	public class CowsController : ControllerBase
	{
		private readonly ICowAPI _cowApi;
		private readonly HalterContext _dbContext;
		private readonly ILogger<CowsController> _logger;
		private List<Cow> cows = new List<Cow>( );

		public CowsController( ICowAPI cowApi, HalterContext dbContext,
			ILogger<CowsController> logger )
		{
			_cowApi = cowApi;
			_dbContext = dbContext;
			_logger = logger;
		}

		[HttpGet]
		public async Task<List<CollarStatus>> Get( )
		{
			return await _cowApi.GetCows( "2" );
		}
		
		[HttpPost]
		public async Task<List<CollarStatus>> Post( )
		{
			return await _cowApi.GetCows( "2" );
		}
		
		[HttpPut]
		public async Task<List<CollarStatus>> Put( )
		{
			return await _cowApi.GetCows( "2" );
		}
	}
}