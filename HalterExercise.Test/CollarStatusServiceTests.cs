using System;
using System.Collections.Generic;
using HalterExercise.Controllers;
using HalterExercise.Models;
using HalterExercise.Services;
using Moq;
using Xunit;

namespace HalterExercise.Test
{
	public class CollarStatusServiceTests
	{
		private readonly Mock<ICowAPI> _cowApiMock = new Mock<ICowAPI>( );
		public CollarStatusServiceTests( )
		{
			_cowApiMock.Setup( x => x.GetCollarStatusList( It.IsAny<string>( ) ) ).ReturnsAsync( getMockCollarStatusList( ) );
		}
		
		[Fact]
		public async void Should_GetLatestCollarStatus_ReturnLatestLocation( )
		{
			//Arrange
			CollarStatusService unitUnderTest = new CollarStatusService( _cowApiMock.Object );
			
			//Act
			var result = await unitUnderTest.GetLatestCollarStatus( 0 );
			
			//Assert
			Assert.Equal( "3", result.SerialNumber );
		}

		private List<CollarStatus> getMockCollarStatusList( )
		{
			return new List<CollarStatus>( )
			{
				new CollarStatus( )
				{
					Id = Guid.NewGuid( ).ToString( ),
					SerialNumber = "1",
					Timestamp = DateTime.Parse( "2022-12-30" )
				},
				new CollarStatus( )
				{
					Id = Guid.NewGuid( ).ToString( ),
					SerialNumber = "2",
					Timestamp = DateTime.Parse( "2022-11-30" )
				},
				new CollarStatus( )
				{
					Id = Guid.NewGuid( ).ToString( ),
					SerialNumber = "3",
					Timestamp = DateTime.Parse( "2023-12-30" )
				}
			};
		}
	}
}