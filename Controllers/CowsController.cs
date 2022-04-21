using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HalterExercise.Models;
using HalterExercise.Models.RequestModels;
using HalterExercise.Repositories;
using HalterExercise.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace HalterExercise.Controllers
{
	[ApiController]
	[Route( "[controller]" )]
	public class CowsController : ControllerBase
	{
		private readonly ICowRepository _cowRepository;
		private readonly ICollarStatusService _collarStatusService;
		private readonly ILogger<CowsController> _logger;

		public CowsController( ICowRepository cowRepository, ICollarStatusService collarStatusService ,ILogger<CowsController> logger )
		{
			_cowRepository = cowRepository;
			_collarStatusService = collarStatusService;
			_logger = logger;
		}

		[HttpGet("{id}")]
		public async Task<Cow> Get( Guid id )
		{
			Cow cow = await _cowRepository.GetById( id );
			CollarStatus collarStatus = await _collarStatusService.GetLatestCollarStatus( cow.CollarId );
			cow.Latitude = (int)Math.Round(Decimal.Parse(collarStatus.Lat));
			cow.Longitude = (int)Math.Round(Decimal.Parse(collarStatus.Lng));

			return cow;
		}
		
		[HttpGet]
		public async Task<IList<Cow>> Get( )
		{
			IList<Cow> cows = await _cowRepository.GetAllCows( );
			foreach ( var cow in cows )
			{
				CollarStatus collarStatus = await _collarStatusService.GetLatestCollarStatus( cow.CollarId );
				cow.Latitude = (int)Math.Round(Decimal.Parse(collarStatus.Lat));
				cow.Longitude = (int)Math.Round(Decimal.Parse(collarStatus.Lng));
			}

			return cows;
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
		
		[HttpPut("{id}")]
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