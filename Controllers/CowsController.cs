using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalterExercise.Models;
using HalterExercise.Models.RequestModels;
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

		public CowsController( ICowAPI cowApi,ICowRepository cowRepository,
			ILogger<CowsController> logger )
		{
			_cowApi = cowApi;
			_cowRepository = cowRepository;
			_logger = logger;
		}

		[HttpGet]
		public async Task<Cow> Get( Guid id )
		{
			return await _cowRepository.GetById( id );
		}
		
		[HttpGet]
		public async Task<IList<Cow>> Get( )
		{
			return await _cowRepository.GetAllCows( );
		}
		
		[HttpPost]
		public ActionResult Post( CreateNewCowRequest request )
		{
			_cowRepository.Create( new Cow( )
			{
				CollarId = request.CollarId,
				CowNumber = request.CowNumber
			} );

			return Ok( );
		}
		
		[HttpPut("/{id}")]
		public async Task<ActionResult> Put( UpdateCowRequest request, Guid id)
		{
			Cow cowToUpdate = await _cowRepository.GetById( id );
			cowToUpdate.CollarId = request.CollarId;
			cowToUpdate.CowNumber = request.CowNumber;
			
			_cowRepository.Update( cowToUpdate );
			return Ok( );
		}
	}
}