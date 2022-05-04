using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using CowApi.Models;
using CowApi.Models.RequestModels;
using CowApi.Repositories;
using CowApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CowApi.Controllers
{
	[ApiController]
	[Route( "[controller]" )]
	public class CowsController : ControllerBase
	{
		private readonly ICowRepository _cowRepository;
		private readonly ICollarStatusService _collarStatusService;
		private readonly IDistributedCache _distributedCache;
		private readonly ILogger<CowsController> _logger;

		public CowsController( ICowRepository cowRepository, ICollarStatusService collarStatusService, IDistributedCache distributedCache, ILogger<CowsController> logger )
		{
			_cowRepository = cowRepository;
			_collarStatusService = collarStatusService;
			_distributedCache = distributedCache;
			_logger = logger;
		}

		[HttpGet( "{id}" )]
		public async Task<GetCowsResponse> Get( Guid id )
		{
			Cow cow = await _cowRepository.GetById( id );
			CollarStatus collarStatus = await _collarStatusService.GetLatestCollarStatus( cow.CollarId );
			cow.Latitude = ( int )Math.Round( Decimal.Parse( collarStatus.Lat ) );
			cow.Longitude = ( int )Math.Round( Decimal.Parse( collarStatus.Lng ) );

			GetCowsResponse response = new GetCowsResponse( )
			{
				Id = cow.Id,
				CollarId = cow.CollarId,
				CowNumber = cow.CowNumber,
				CollarStatus = collarStatus.Healthy?Enums.CollarStatus.Healthy:Enums.CollarStatus.Broken,
				LastLocation = new Location( )
				{
					Latitude = cow.Latitude,
					Longitude = cow.Longitude
				}
			};
			return response;
		}

		[HttpGet]
		public async Task<IList<GetCowsResponse>> Get( )
		{
			List<GetCowsResponse> responses = new List<GetCowsResponse>( );
			var cacheKey = "cows";
			string serializedCowsList;
			var cowsResponsesList = new List<GetCowsResponse>();
			var redisCowResponsesList = await _distributedCache.GetAsync(cacheKey);

			if ( redisCowResponsesList != null )
			{
				serializedCowsList = Encoding.UTF8.GetString(redisCowResponsesList);
				responses = JsonConvert.DeserializeObject<List<GetCowsResponse>>(serializedCowsList);
			}
			else
			{
				IList<Cow> cows = await _cowRepository.GetAllCows( );
				foreach ( var cow in cows )
				{
					CollarStatus collarStatus = await _collarStatusService.GetLatestCollarStatus( cow.CollarId );
					cow.Latitude = ( int )Math.Round( Decimal.Parse( collarStatus.Lat ) );
					cow.Longitude = ( int )Math.Round( Decimal.Parse( collarStatus.Lng ) );
					GetCowsResponse response = new GetCowsResponse( )
					{
						Id = cow.Id,
						CollarId = cow.CollarId,
						CowNumber = cow.CowNumber,
						CollarStatus = collarStatus.Healthy?Enums.CollarStatus.Healthy:Enums.CollarStatus.Broken,
						LastLocation = new Location( )
						{
							Latitude = cow.Latitude,
							Longitude = cow.Longitude
						}
					};
					responses.Add( response );
				}
				//cache in redis
				serializedCowsList = JsonConvert.SerializeObject( responses );
				redisCowResponsesList = Encoding.UTF8.GetBytes( serializedCowsList );
				var options = new DistributedCacheEntryOptions( )
					.SetAbsoluteExpiration( DateTime.Now.AddMinutes( 10 ) )
					.SetSlidingExpiration( TimeSpan.FromMinutes( 2 ) );
				await _distributedCache.SetAsync( cacheKey, redisCowResponsesList, options );
			}
			
			return responses;
		}

		[HttpPost]
		public async Task<ActionResult> Post( CreateNewCowRequest request )
		{
			if ( Int32.Parse(request.CollarId) > 50 || Int32.Parse(request.CollarId) <= 0)
			{
				return BadRequest( "Collar Id have to be in the range of 1-50" );
			}
			bool success = await _cowRepository.Create( new Cow( )
			{
				CollarId = Int32.Parse( request.CollarId ),
				CowNumber = Int32.Parse( request.CowNumber )
			} );

			return success?( ActionResult )Ok( ):BadRequest( "Something went wrong and the cow was not created" );
		}

		[HttpPut( "{id}" )]
		public async Task<ActionResult> Put( UpdateCowRequest request, Guid id )
		{
			Cow cowToUpdate = await _cowRepository.GetById( id );
			cowToUpdate.CollarId = request.CollarId;
			cowToUpdate.CowNumber = request.CowNumber;

			_cowRepository.Update( cowToUpdate );
			return Ok( );
		}
	}
}