using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalterExercise.Models;
using HalterExercise.Repositories;
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
		private readonly ICowRepository _cowRepository;
		private readonly ILogger<CowsController> _logger;
		private List<Cow> cows = new List<Cow>( );

		public CowsController( ICowAPI cowApi,ICowRepository cowRepository,
			ILogger<CowsController> logger )
		{
			_cowApi = cowApi;
			_cowRepository = cowRepository;
			_logger = logger;
		}

		[HttpGet]
		public async Task<Cow> Get( )
		{
			return _cowRepository.GetById( Guid.Empty );
			// return await _cowApi.GetCows( "2" );
		}
		
		[HttpPost]
		public void Post( )
		{
			_cowRepository.Create( new Cow( ){CowNumber = 12} );
		}
		
		[HttpPut]
		public async Task<List<CollarStatus>> Put( )
		{
			return await _cowApi.GetCows( "2" );
		}
	}
}